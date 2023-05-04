using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualChatBot.Models
{
    public partial class UserConfig :ObservableObject
    {
        [ObservableProperty,JsonProperty("APIKey")]
        string? apikey;
        [ObservableProperty,JsonProperty("model")]
        string? model;
        [ObservableProperty,JsonProperty("maxTokens")]
        string? maxTokens;
        [ObservableProperty,JsonProperty("objectDegree")]
        string? objectDegree;
        [ObservableProperty]
        bool enableDarkMode;
    }
}
