using VisualChatBot.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualChatBot.Models
{
    class HttpGetModel
    {
        /// <summary>
        /// Api_Key是否有效
        /// </summary>
        [JsonIgnore]
        public static bool IsValidApiKey { get; set; } = true;
        /// <summary>
        /// 请求是否成功
        /// </summary>
        [JsonIgnore]
        public static bool IsRequestSuccess { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("object")]
        public string? Object { get; set; }

        [JsonProperty("created")]
        public string? Created { get; set; }

        [JsonProperty("model")]
        public string? Model { get; set; }

        [JsonProperty("choices")]
        public List<Choices>? Choicese { get; set; }

        [JsonProperty("usage")]
        public Usage? Usages { get; set; }

        [JsonProperty("error")]
        public ErrorInfo? error { get; set; }

        public class Choices
        {
            [JsonProperty("message")]
            public Message MessageDetail { get; set; }
            [JsonProperty("finish_reason")]
            public string Finish_reason { get; set; }
            [JsonProperty("index")]
            public int index { get; set; }
        }
        public class Usage
        {
            [JsonProperty("prompt_tokens")]
            public string? Prompt_tokens { get; set; }
            [JsonProperty("completion_tokens")]
            public string? Completion_tokens { get; set; }
            [JsonProperty("total_tokens")]
            public string? Total_tokens { get; set; }
        }
        public class ErrorInfo
        {
            [JsonProperty("message")]
            public string? message { get; set; }

            [JsonProperty("type")]
            public string? type { get; set; }

            [JsonProperty("param")]
            public string? param { get; set; }

            [JsonProperty("code")]
            public string? code { get; set; }
        }
    }
}
