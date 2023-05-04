using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualChatBot.ViewModels
{
    public partial class ReceivedViewModel:ObservableObject
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
                if(_content != value)
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }
    }
}
