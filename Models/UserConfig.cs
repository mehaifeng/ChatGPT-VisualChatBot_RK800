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
        [ObservableProperty, JsonProperty("systemOrder")]
        string? systemOrder;
        [ObservableProperty, JsonProperty("presence_penalty")]//新话题分支 -2-2
        double presence_penalty = 1;
        [ObservableProperty, JsonProperty("frequency_penalty")]//降低重复行 -2-2
        double frequency_penalty = 1;
        [ObservableProperty, JsonProperty("temperature")]//创新分散和准确集中 0-2
        string temperature = "1";
        [ObservableProperty]
        bool enableDarkMode;
    }
}
