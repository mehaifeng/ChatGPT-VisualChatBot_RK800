using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualChatBot.Models
{
    public partial class Message : ObservableObject
    {
        public string role;
        public string content;
    }
}
