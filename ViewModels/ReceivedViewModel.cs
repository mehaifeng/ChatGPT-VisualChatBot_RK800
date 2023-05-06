using CommunityToolkit.Mvvm.ComponentModel;

namespace VisualChatBot.ViewModels
{
    public partial class ReceivedViewModel : ObservableObject
    {
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }
    }
}
