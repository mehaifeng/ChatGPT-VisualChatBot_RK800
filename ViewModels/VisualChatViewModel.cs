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

namespace VisualChatBot.ViewModels
{
    public partial class VisualChatViewModel: ObservableObject , INotifyPropertyChanged
    {
        ReadWriteJson readWriteJson = new();
        public VisualChatViewModel()
        {
            if (File.Exists(userConfigPath))
            {
                Modelstype = readWriteJson.ReadJson(userConfigPath, "model");
                ObjectDegree = Convert.ToDouble(readWriteJson.ReadJson(userConfigPath, "objectDegree"));
                MaxToken = Convert.ToInt32(readWriteJson.ReadJson(userConfigPath, "maxTokens"));
                ApiKey = readWriteJson.ReadJson(userConfigPath, "APIKey");
            }
            else if(string.IsNullOrEmpty(readWriteJson.ReadJson(userConfigPath, "APIKey")))
            {
                ShowOutput = $"初次使用需要填写API_key，你可以在https://openai.com/api/获取API key\n请在下方输入你的API_key，并点击发送";
                HttpGetModel.IsValidApiKey = false;
            }
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
        private string? apiKey;

        private string? prompt;
        private string? model;
        private double? temperature;
        private int? max_tokens;
        private double top_p = 1;
        private double frequency_penalty = 1;
        private double presence_penalty = 0.4;
        private string requestUrl = "https://api.openai.com/v1/completions";
        private string userConfigPath = $"{System.Environment.CurrentDirectory}//UserConfig.json";
        private string? lastChatRecoder;
        private string placeholder = "-";

        [RelayCommand]
        private async void Send(TextBox o)
        {
            Tools.WebRequest webRequest = new Tools.WebRequest();
            if (!string.IsNullOrWhiteSpace(MyInput)&&HttpGetModel.IsValidApiKey==true)
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

                if (string.IsNullOrWhiteSpace(lastChatRecoder))
                {
                    ShowOutput = $"你：\n\n{MyInput}";
                    o.ScrollToEnd();
                    MyInput = "";
                    ShowOutput = $"{ShowOutput}\n\nRK800：{await webRequest.WebRequestMethon(ApiKey, requestUrl, content)}\n\n{placeholder}";
                    lastChatRecoder = ShowOutput;
                    o.ScrollToEnd();
                }
                else
                {
                    ShowOutput = $"{ShowOutput}\n\n你：\n\n{MyInput}";
                    o.ScrollToEnd();
                    MyInput = "";
                    ShowOutput = $"{ShowOutput}\n\nRK800：{await webRequest.WebRequestMethon(ApiKey, requestUrl, content)}\n\n{placeholder}";
                    lastChatRecoder += ShowOutput;
                    o.ScrollToEnd();
                }
            }
            else if(HttpGetModel.IsValidApiKey == false)
            {
                if (!string.IsNullOrWhiteSpace(MyInput))
                {
                    ApiKey= MyInput;
                    if (ApiKey.Contains('-'))
                    {
                        ShowOutput = $"{ApiKey.Split('-')[0]}******\n\n请稍等...\n\n";
                        MyInput = "";
                        await webRequest.WebRequestMethon(ApiKey, requestUrl, null);
                        if(HttpGetModel.IsValidApiKey == true)
                        {
                            ShowOutput = $"{ShowOutput}API Key可用！enjoy！";
                            if (!File.Exists(userConfigPath))
                            {
                                InitialOpreate();
                            }
                            else
                            {
                                string json = readWriteJson.ReadJson(userConfigPath, null);
                                readWriteJson.WriteJson(json, "APIKey", ApiKey);
                            }
                        }
                        else
                        {
                            ShowOutput = $"{ShowOutput}API Key无效！";
                        }
                    }
                    else
                    {
                        ShowOutput = $"API Key不正确";
                        MyInput = "";
                    }
                }
            }
        }
        /// <summary>
        /// 初始操作
        /// </summary>
        void InitialOpreate()
        {
            Dictionary<string, string> UserConfig = new()
            {
                { "model", Modelstype },
                { "objectDegree", ObjectDegree.ToString() },
                { "maxTokens", MaxToken.ToString() },
                { "APIKey", ApiKey }
            };
            var jsonStr = JsonConvert.SerializeObject(UserConfig);
            File.WriteAllText(userConfigPath, jsonStr);
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
