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

namespace VisualChatBot.ViewModels
{
    public partial class VisualChatViewModel: ObservableObject
    {
        public VisualChatViewModel()
        {
            for(int i = 0; i < 80; i++)
            {
                placeholder += "-";
            }
        }
        /// <summary>
        /// 模型
        /// </summary>
        [ObservableProperty]
        private string modelstype = "text-davinci-003";

        /// <summary>
        /// 主客观值
        /// </summary>
        [ObservableProperty]
        private double objectDegree = 0.5;

        /// <summary>
        /// 最大token数
        /// </summary>
        [ObservableProperty]
        private int maxToken = 1024;

        /// <summary>
        /// 展示对话输出
        /// </summary>
        [ObservableProperty]
        private string? showOutput;

        /// <summary>
        /// 我的输入
        /// </summary>
        [ObservableProperty]
        private string? myInput;

        /// <summary>
        /// 配置栏高度
        /// </summary>
        [ObservableProperty]
        private int configGridHeight = 0;

        /// <summary>
        /// 配置按钮图标
        /// </summary>
        [ObservableProperty]
        private string settingBtnContent = "\xe799";

        /// <summary>
        /// 菜单按钮图标
        /// </summary>
        [ObservableProperty]
        private string menuToggleBtnContent = "\xe863";


        /// <summary>
        /// Api-Key
        /// </summary>
        [ObservableProperty]
        private string apiKey = "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";

        private string prompt;
        private string model;
        private double temperature;
        private int max_tokens;
        private double top_p = 1;
        private double frequency_penalty = 1;
        private double presence_penalty = 0.4;
        private string requestUrl = "https://api.openai.com/v1/completions";

        private string lastChatRecoder;
        private string placeholder = "-";

        [RelayCommand]
        private async void Send(TextBox o)
        {
            if (!string.IsNullOrWhiteSpace(MyInput))
            {
                var input = new
                {
                    prompt = MyInput,
                    model = Modelstype,
                    max_tokens = MaxToken,
                    top_p,
                    frequency_penalty,
                    presence_penalty,
                    temperature
                };
                var json = JsonConvert.SerializeObject(input);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                Tools.WebRequest webRequest = new Tools.WebRequest();
                if (string.IsNullOrWhiteSpace(lastChatRecoder))
                {
                    ShowOutput = $"你：\n\n{MyInput}";
                    o.ScrollToEnd();
                    MyInput = "";
                    ShowOutput = $"{ShowOutput}\n\nRK800：{await webRequest.WebRequestMethon(apiKey, requestUrl, content)}\n\n{placeholder}";
                    lastChatRecoder = ShowOutput;
                    o.ScrollToEnd();
                }
                else
                {
                    ShowOutput = $"{ShowOutput}\n\n你：\n\n{MyInput}";
                    o.ScrollToEnd();
                    MyInput = "";
                    ShowOutput = $"{ShowOutput}\n\nRK800：{await webRequest.WebRequestMethon(apiKey, requestUrl, content)}\n\n{placeholder}";
                    lastChatRecoder += ShowOutput;
                    o.ScrollToEnd();
                }
            }
        }
        [RelayCommand]
        private void ClickAbout()
        {
            ShowOutput += $"\n                ———————————————————————\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                            RK800_V0.1                                 ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                    通用API:  OpenAI.com                         ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            showOutput += $"                 ||                                                                                ||\n";
            ShowOutput += $"                ———————————————————————\n";
        }

        /// <summary>
        /// 开启Or关闭配置栏
        /// </summary>
        /// <param name="o"></param>
        [RelayCommand]
        private void OpenOrCloseConfig(Grid o)
        {
            //如果是关闭的
            if ( ConfigGridHeight < 60)
            {
                SettingBtnContent = "\xe797";
                Timer timer = new(1);
                timer.Elapsed += (sender,e) =>
                {
                    ConfigGridHeight++;
                    if(ConfigGridHeight >= 60)
                    {
                        timer.Stop();
                    }
                };
                timer.Start();
            }
            //如果是打开的
            if ( ConfigGridHeight >= 60)
            {
                SettingBtnContent = "\xe799";
                Timer timer = new Timer(1);
                timer.Elapsed += (sender, e) =>
                {
                    ConfigGridHeight--;
                    if (ConfigGridHeight == 0)
                    {
                        timer.Stop();
                    }
                };
                timer.Start();
            }
        }
    }
}
