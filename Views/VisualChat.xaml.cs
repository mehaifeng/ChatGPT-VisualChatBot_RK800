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
using VisualChatBot.ViewModels;

namespace VisualChatBot
{
    /// <summary>
    /// Interaction logic for VisualChat.xaml
    /// </summary>
    public partial class VisualChat : Window
    {
        VisualChatViewModel _visualChatViewModel;
        public VisualChat()
        {
            InitializeComponent();
            _visualChatViewModel = new VisualChatViewModel();
            this.DataContext = _visualChatViewModel;
            OptionalModelsComboBox.ItemsSource = new[]
            {
                "text-davinci-001",
                "text-davinci-002",
                "text-davinci-003"
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
    }
}
