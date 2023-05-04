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
using System.Windows.Media.Animation;
using Newtonsoft.Json.Linq;

namespace VisualChatBot
{
    /// <summary>
    /// Interaction logic for VisualChat.xaml
    /// </summary>
    public partial class VisualChat : Window
    {
        VisualChatViewModel _visualChatViewModel;
        private string UserConfigPath = $"{System.Environment.CurrentDirectory}//UserConfig.json";
        public VisualChat()
        {
            InitializeComponent();
            _visualChatViewModel = new VisualChatViewModel();
            this.DataContext = _visualChatViewModel;
            if (_visualChatViewModel.UserConfig.EnableDarkMode)
            {
                ModeSwitch_Click(null,null);
            }
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
            ModeSwitch.Content = "\xe687";
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
            if (OpenSettingBtn.IsChecked == true)
            {
                OpenSettingBtn.IsChecked = false;
                DoubleAnimation animation2 = new DoubleAnimation(90, 0, TimeSpan.FromSeconds(0.2));
                ConfigBorder.BeginAnimation(HeightProperty, animation2);
            }
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OpenSettingBtn.IsChecked == true)
            {
                OpenSettingBtn.IsChecked = false;
                DoubleAnimation animation2 = new DoubleAnimation(90, 0, TimeSpan.FromSeconds(0.2));
                ConfigBorder.BeginAnimation(HeightProperty, animation2);
            }
        }

        /// <summary>
        /// 模型改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionalModelsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (File.Exists(UserConfigPath))
            {
                string json = File.ReadAllText(UserConfigPath);
                JObject configObject = JObject.Parse(json);
                configObject["model"] = _visualChatViewModel.UserConfig.Model;
                json = JsonConvert.SerializeObject(configObject);
                File.WriteAllText(UserConfigPath, json);
            }
            else
            {
                Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.UserConfig.Model },
                    { "objectDegree",  _visualChatViewModel.UserConfig.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.UserConfig.MaxTokens.ToString() },
                    { "APIKey",  _visualChatViewModel.UserConfig.Apikey },
                    { "EnableDarkMode", _visualChatViewModel.UserConfig.EnableDarkMode.ToString() }
                };
                var jsonStr = JsonConvert.SerializeObject(UserConfig);
                File.WriteAllText(UserConfigPath, jsonStr);
            }
        }

        /// <summary>
        /// 主客观改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObjectDegreeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (File.Exists(UserConfigPath))
            {
                string json = File.ReadAllText(UserConfigPath);
                JObject configObject = JObject.Parse(json);
                configObject["objectDegree"] = _visualChatViewModel.UserConfig.ObjectDegree;
                json = JsonConvert.SerializeObject(configObject);
                File.WriteAllText(UserConfigPath, json);
            }
            else
            {
                Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.UserConfig.Model },
                    { "objectDegree",  _visualChatViewModel.UserConfig.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.UserConfig.MaxTokens.ToString() },
                    { "APIKey",  _visualChatViewModel.UserConfig.Apikey },
                    { "EnableDarkMode", _visualChatViewModel.UserConfig.EnableDarkMode.ToString() }
                };
                var jsonStr = JsonConvert.SerializeObject(UserConfig);
                File.WriteAllText(UserConfigPath, jsonStr);
            }
        }

        /// <summary>
        /// maxTokenss改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxTokensTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (File.Exists(UserConfigPath))
            {
                string json = File.ReadAllText(UserConfigPath);
                JObject configObject = JObject.Parse(json);
                configObject["maxTokens"] = _visualChatViewModel.UserConfig.MaxTokens;
                json = JsonConvert.SerializeObject(configObject);
                File.WriteAllText(UserConfigPath, json);
            }
            else
            {
                Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.UserConfig.Model },
                    { "objectDegree",  _visualChatViewModel.UserConfig.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.UserConfig.MaxTokens.ToString() },
                    { "APIKey",  _visualChatViewModel.UserConfig.Apikey },
                    { "EnableDarkMode", _visualChatViewModel.UserConfig.EnableDarkMode.ToString() }
                };
                var jsonStr = JsonConvert.SerializeObject(UserConfig);
                File.WriteAllText(UserConfigPath, jsonStr);
            }
        }


        /// <summary>
        /// 黑暗模式切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModeSwitch_Click(object sender, RoutedEventArgs e)
        {
            BrushConverter converter = new BrushConverter();
            //如果当前是明亮模式
            if (ModeSwitch.Foreground == Brushes.White)
            {
                ModeSwitch.Foreground = Brushes.Black;
                //AppTitle
                AppTitle.Background = Application.Current.Resources["BackgroundColor"] as SolidColorBrush;
                miniBtn.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                closeBtn.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                MenuToggleBtn.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                OpenSettingBtn.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                sideMenu.Background = Application.Current.Resources["BackgroundColor"] as SolidColorBrush;
                MenuHistory.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                MenuOpenAI.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                MenuAbout.Foreground = Application.Current.Resources["ForegroundColor"] as SolidColorBrush;
                ConfigBorder.Background = Brushes.LightGray;
                OptionalModelsComboBox.Background = Brushes.White;
                ObjectDegreeCombobox.Background = Brushes.White;
                systemMessageTextbox.Background = Brushes.White;
                MaxTokensTextbox.Background = Brushes.White;
                ApiKeyTextbox.Background = Brushes.White;
                //AppBody
                AppBody.Background = Application.Current.Resources["BackgroundColor"] as SolidColorBrush;
                ChatArea.Background = Application.Current.Resources["TextBoxBackgroundColor"] as SolidColorBrush;
                loadingSignal.Foreground = Application.Current.Resources["LabelForegroundColor"] as SolidColorBrush;
                //AppButtom
                AppButtom.Background = Application.Current.Resources["BackgroundColor"] as SolidColorBrush;
                InputBox.Background = Application.Current.Resources["TextBoxBackgroundColor"] as SolidColorBrush;
                InputBox.Foreground = Application.Current.Resources["TextBoxForegroundColor"] as SolidColorBrush;
                SendBtn.Background = Application.Current.Resources["ButtonBackgroundColor"] as SolidColorBrush;
                //生成的对话框
                foreach (Border border in ChatArea.Children.OfType<Border>())
                {
                    if (border.Tag.ToString() == "respondbox")
                    {
                        border.Background = Brushes.White;
                        (border.Child as TextBox).Foreground = Brushes.Black;
                    }
                }
                _visualChatViewModel.UserConfig.EnableDarkMode = false;
            }
            //如果当前是黑暗模式
            else if(ModeSwitch.Foreground == Brushes.Black)
            {
                ModeSwitch.Foreground = Brushes.White;
                //AppTitle
                AppTitle.Background = Application.Current.Resources["DarkBackgroundColor"] as SolidColorBrush;
                miniBtn.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                closeBtn.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                MenuToggleBtn.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                OpenSettingBtn.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                sideMenu.Background = Application.Current.Resources["DarkBackgroundColor"] as SolidColorBrush;
                MenuHistory.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                MenuOpenAI.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                MenuAbout.Foreground = Application.Current.Resources["DarkForegroundColor"] as SolidColorBrush;
                ConfigBorder.Background = (Brush)converter.ConvertFromString("#36454f");
                OptionalModelsComboBox.Background = (Brush)converter.ConvertFromString("#e3dac9");
                ObjectDegreeCombobox.Background = (Brush)converter.ConvertFromString("#e3dac9");
                systemMessageTextbox.Background = (Brush)converter.ConvertFromString("#e3dac9");
                MaxTokensTextbox.Background = (Brush)converter.ConvertFromString("#e3dac9");
                ApiKeyTextbox.Background = (Brush)converter.ConvertFromString("#e3dac9");
                //AppBody
                AppBody.Background = Application.Current.Resources["DarkBackgroundColor"] as SolidColorBrush;
                ChatArea.Background = Application.Current.Resources["DarkTextBoxBackgroundColor"] as SolidColorBrush;
                loadingSignal.Foreground = Application.Current.Resources["DarkLabelForegroundColor"] as SolidColorBrush;
                //AppButtom
                AppButtom.Background = Application.Current.Resources["DarkBackgroundColor"] as SolidColorBrush;
                InputBox.Background = Application.Current.Resources["DarkTextBoxBackgroundColor"] as SolidColorBrush;
                InputBox.Foreground = Application.Current.Resources["DarkTextBoxForegroundColor"] as SolidColorBrush;
                SendBtn.Background = Application.Current.Resources["DarkButtonBackgroundColor"] as SolidColorBrush;
                //生成的对话框
                foreach (Border border in ChatArea.Children.OfType<Border>())
                {
                    if (border.Tag.ToString() == "respondbox")
                    {
                        border.Background = (Brush)converter.ConvertFromString("#2a52be");
                        (border.Child as TextBox).Foreground = Brushes.White;
                    }
                }
                _visualChatViewModel.UserConfig.EnableDarkMode = true;

            }
            Dictionary<string, string> UserConfig = new()
                {
                    { "model", _visualChatViewModel.UserConfig.Model },
                    { "objectDegree",  _visualChatViewModel.UserConfig.ObjectDegree.ToString() },
                    { "maxTokens",  _visualChatViewModel.UserConfig.MaxTokens.ToString() },
                    { "APIKey",  _visualChatViewModel.UserConfig.Apikey },
                    { "EnableDarkMode", _visualChatViewModel.UserConfig.EnableDarkMode.ToString() }
                };
            var jsonStr = JsonConvert.SerializeObject(UserConfig);
            File.WriteAllText(UserConfigPath, jsonStr);
        }

        /// <summary>
        /// 打开设置菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSettingBtn_Checked(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0,90,TimeSpan.FromSeconds(0.2));
            DoubleAnimation animation2 = new DoubleAnimation(90, 0, TimeSpan.FromSeconds(0.2));
            if (OpenSettingBtn.IsChecked == true)
            {
                ConfigBorder.BeginAnimation(HeightProperty, animation);
            }
            else if(OpenSettingBtn.IsChecked == false)
            {
                ConfigBorder.BeginAnimation(HeightProperty, animation2);
            }
        }
    }
}
