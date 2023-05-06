using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace VisualChatBot.Models
{
    public partial class UserConfig : ObservableObject
    {
        [ObservableProperty, JsonProperty("APIKey")]
        string? apikey;
        [ObservableProperty, JsonProperty("model")]
        string? model;
        [ObservableProperty, JsonProperty("maxTokens")]
        string? maxTokens;
        [ObservableProperty, JsonProperty("objectDegree")]
        string? objectDegree;
        [ObservableProperty, JsonProperty("systemOrder")]
        string? systemOrder;
        [ObservableProperty]
        bool enableDarkMode;
    }
}
