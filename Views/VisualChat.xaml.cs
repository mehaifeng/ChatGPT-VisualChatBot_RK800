using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisualChatBot.Models;
using VisualChatBot.ViewModels;
using System.IO;
using VisualChatBot.Tools;
using Newtonsoft.Json;

namespace VisualChatBot
{
    /// <summary>
    /// Interaction logic for VisualChat.xaml
    /// </summary>
    public partial class VisualChat : Window
    {
        VisualChatViewModel _visualChatViewModel;
        ReadWriteJson readReadJson = new();
        private string userConfigPath = $"{System.Environment.CurrentDirectory}//UserConfig.json";
        public VisualChat()
        {
            InitializeComponent();
            _visualChatViewModel = new VisualChatViewModel();
            this.DataContext = _visualChatViewModel;
            OptionalModelsComboBox.ItemsSource = new[]
            {
                "gpt-3.5-turbo",
                "gpt-3.5-turbo-0301",
            };
            ObjectDegreeCombobox.ItemsSource = new[]
            {
                0,
                0.1,
                0.2,
                0.3,
                0.4,
                0.5,
                0.6,
                0.7,
                0.8,
                0.9
            };
        }

        private void MiniOrReSize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MoveWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ( _visualChatViewModel.ConfigGridHeight >= 60)
            {
                _visualChatViewModel.SettingBtnContent = "\xe799";
                Timer timer = new Timer(1);
                timer.Elapsed += (sender, e) =>
                {
                    _visualChatViewModel.ConfigGridHeight--;
                    if (_visualChatViewModel.ConfigGridHeight == 0)
                    {
                        timer.Stop();
                    }
                };
                timer.Start();
            }
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_visualChatViewModel.ConfigGridHeight >= 60)
            {
                _visualChatViewModel.SettingBtnContent = "\xe799";
                Timer timer = new Timer(1);
                timer.Elapsed += (sender, e) =>
                {
                    _visualChatViewModel.ConfigGridHeight--;
                    if (_visualChatViewModel.ConfigGridHeight == 0)
                    {
                        timer.Stop();
                    }
                };
                timer.Start();
            }
        }

        /// <summary>
        /// 模型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionalModelsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (File.Exists(userConfigPath))
            {
                string json = readReadJson.ReadJson(userConfigPath, null);
                readReadJson.WriteJson(json,"model", _visualChatViewModel.Modelstype);
            }
            else
            {
                Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.Modelstype },
                    { "objectDegree",  _visualChatViewModel.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.MaxToken.ToString() },
                    { "APIKey",  _visualChatViewModel.ApiKey }
                };
                var jsonStr = JsonConvert.SerializeObject(UserConfig);
                File.WriteAllText(userConfigPath, jsonStr);
            }
        }

        /// <summary>
        /// 主客观改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjectDegreeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (File.Exists(userConfigPath))
            {
                string json = readReadJson.ReadJson(userConfigPath, null);
                readReadJson.WriteJson(json, "objectDegree", _visualChatViewModel.ObjectDegree.ToString());
            }
            else
            {
                Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.Modelstype },
                    { "objectDegree",  _visualChatViewModel.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.MaxToken.ToString() },
                    { "APIKey",  _visualChatViewModel.ApiKey }
                };
                var jsonStr = JsonConvert.SerializeObject(UserConfig);
                File.WriteAllText(userConfigPath, jsonStr);
            }
        }

        /// <summary>
        /// MaxTokens改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxTokensTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (File.Exists(userConfigPath))
            {
                string json = readReadJson.ReadJson(userConfigPath, null);
                readReadJson.WriteJson(json, "maxTokens", _visualChatViewModel.MaxToken.ToString());
            }
            else
            {
                Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.Modelstype },
                    { "objectDegree",  _visualChatViewModel.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.MaxToken.ToString() },
                    { "APIKey",  _visualChatViewModel.ApiKey }
                };
                var jsonStr = JsonConvert.SerializeObject(UserConfig);
                File.WriteAllText(userConfigPath, jsonStr);
            }
        }
    }
}
