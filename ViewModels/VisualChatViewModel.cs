using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using VisualChatBot.Tools;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using VisualChatBot.Models;
using System.Reflection.Metadata;
using System.IO;
using System.Windows.Input;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Windows.Data;
using VisualChatBot.Converters;
using System.Windows.Media.Effects;
using System.Threading;

namespace VisualChatBot.ViewModels
{
    public partial class VisualChatViewModel : ObservableObject, INotifyPropertyChanged
    {
        string configPath = $"{System.Environment.CurrentDirectory}//UserConfig.json";
        string urlAddress = $"https://api.openai.com/v1/chat/completions";
        Tools.WebRequest request;
        public VisualChatViewModel()
        {
            UserConfig = new UserConfig();
            messageList = new List<Message>();
            request = new Tools.WebRequest();
            InitLoad();
        }

        void InitLoad()
        {
            string configJson = File.ReadAllText(configPath);
            UserConfig = JsonConvert.DeserializeObject<UserConfig>(configJson);
        }

        /// <summary>
        /// 消息对象集合
        /// </summary>
        public List<Message> messageList { get; set; }

        [ObservableProperty]
        private UserConfig userConfig;

        /// <summary>
        /// 输入消息
        /// </summary>
        [ObservableProperty]
        private string myInput;

        /// <summary>
        /// 收到的消息（暂存）
        /// </summary>
        public string? respondTemp;

        /// <summary>
        /// 接收到的消息
        /// </summary>
        [ObservableProperty]
        public string respondContent;

        /// <summary>
        /// 是否滚动到底部
        /// </summary>
        [ObservableProperty]
        private bool isScrollToButtom;

        /// <summary>
        /// 加载标识
        /// </summary>
        [ObservableProperty]
        private string loadSignText = "////////////////////";

        /// <summary>
        /// 发送+以及接收到消息
        /// </summary>
        /// <param name="o"></param>
        [RelayCommand]
        async void Send(StackPanel o)
        {
            if (!string.IsNullOrEmpty(UserConfig.Apikey)&&!string.IsNullOrEmpty(MyInput))
            {
                #region 控件生成流
                BrushConverter converter = new BrushConverter();
                Border sendbox = new Border()
                {
                    Tag = "sendbox",
                    //阴影
                    Effect = new DropShadowEffect()
                    {
                        Color = Colors.Black,
                        Direction = 0,
                        ShadowDepth = 0,
                        Opacity = 0.5,
                        BlurRadius = 5,
                    },
                    Margin = new Thickness(5, 0, 5, 5),
                    HorizontalAlignment = HorizontalAlignment.Right,
                    CornerRadius = new CornerRadius(7),
                    Background = (Brush)converter.ConvertFromString("#95EC69")
                };
                TextBox sendMessage = new TextBox()
                {
                    Style = (Style)Application.Current.FindResource("NoBorderTextBox"),
                    BorderBrush = Brushes.Transparent,
                    Background = Brushes.Transparent,
                    MaxWidth = o.ActualWidth,
                    TextWrapping = TextWrapping.Wrap,
                    Foreground = Brushes.Black,
                    Margin = new Thickness(5,10,5,10),
                    IsReadOnly = true,
                    Text = MyInput.ToString(),
                };
                sendbox.Child = sendMessage;
                o.Children.Add(sendbox);
                IsScrollToButtom = true;
                IsScrollToButtom = false;
                #endregion
                #region 发送处理流
                messageList.Add(
                    new Message
                    {
                        role = "user",
                        content = MyInput
                    }
                );
                var input = new
                {
                    model = UserConfig.Model,
                    messages = messageList
                };
                MyInput = string.Empty;
                string inputJson = JsonConvert.SerializeObject(input);
                StringContent requestContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                var getApiRespond = GetAPIRespond(requestContent);
                await Task.WhenAny(getApiRespond, LoadingEffect(tokenSource));
                if (getApiRespond.IsCompleted)
                {
                    tokenSource.Cancel();
                    LoadSignText = "////////////////////";
                }
                respondTemp = getApiRespond.Result;
                //将生成的回复加入到下一次入参
                messageList.Add(new Message
                {
                    role = "assistant",
                    content = respondTemp
                });
                MyInput = string.Empty;
                #endregion
                #region 接收处理流
                ReceivedViewModel receivedViewModel = new ReceivedViewModel();
                Border border = new Border()
                {
                    Tag = "respondbox",
                    //阴影
                    Effect = new DropShadowEffect()
                    {
                        Color = Colors.Black,
                        Direction = 0,
                        ShadowDepth = 0,
                        Opacity = 0.5,
                        BlurRadius = 5,
                    },
                    Margin = new Thickness(5, 0, 5, 5),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    CornerRadius = new CornerRadius(7),
                    Background = UserConfig.EnableDarkMode ? (Brush)converter.ConvertFromString("#2a52be") : Brushes.White
                };
                //设置绑定
                Binding binding = new Binding();
                //绑定到数据源
                binding = new Binding(nameof(receivedViewModel.Content)) { Source = receivedViewModel };
                //设置绑定触发机制
                binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                TextBox respondbox = new TextBox()
                {
                    Style = (Style)Application.Current.FindResource("NoBorderTextBox"),
                    BorderBrush = Brushes.Transparent,
                    Background = Brushes.Transparent,
                    MaxWidth = o.ActualWidth,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5, 10, 5, 10),
                    IsReadOnly = true,
                    Foreground = UserConfig.EnableDarkMode ? Brushes.White : Brushes.Black
                };
                respondbox.SetBinding(TextBox.TextProperty, binding);
                border.Child = respondbox;
                o.Children.Add(border);
                //逐字显示
                ShowGenerateText(receivedViewModel);
                #endregion
            }
        }
        async Task LoadingEffect(CancellationTokenSource cancellationToken)
        {
            LoadSignText = string.Empty;
            while (!cancellationToken.IsCancellationRequested)
            {
                if(LoadSignText.Length==0)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (cancellationToken.IsCancellationRequested) { return; }
                        LoadSignText += "/";
                        await Task.Delay(80);
                    }
                }
                if(LoadSignText.Length==20 && !cancellationToken.IsCancellationRequested)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (cancellationToken.IsCancellationRequested) { return; }
                        LoadSignText = LoadSignText.Substring(0, LoadSignText.Length - 1);
                        await Task.Delay(80);
                    }
                }
            }
        }

        /// <summary>
        /// 接收API返回
        /// </summary>
        /// <param name="apikey"></param>
        /// <param name="url"></param>
        /// <param name="requestContent"></param>
        /// <returns></returns>
        async Task<string> GetAPIRespond(StringContent requestContent)
        {
            return await request.WebRequestMethon(userConfig.Apikey, urlAddress, requestContent);
        }
        /// <summary>
        /// 显示回复
        /// </summary>
        async void ShowGenerateText(ReceivedViewModel receivedViewModel)
        {
            if (respondTemp != null)
            {
                for (int i = 0; i < respondTemp.Length; i++)
                {
                    await Task.Delay(50);
                    receivedViewModel.Content += respondTemp[i];
                }
            }
        }

        [RelayCommand]
        void ClearAll(StackPanel o)
        {
            o.Children.Clear();
        }

        void CreateSend(StackPanel o)
        {

        }
    }
}
