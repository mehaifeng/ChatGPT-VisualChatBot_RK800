using CommunityToolkit.Mvvm.ComponentModel;

namespace VisualChatBot.Models
{
    public partial class Message : ObservableObject
    {
        public string? role;
        public string? content;
    }
}
