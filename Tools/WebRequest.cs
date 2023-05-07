using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VisualChatBot.Models;

namespace VisualChatBot.Tools
{
    public class WebRequest
    {
        public async Task<string?> WebRequestMethon(string? apikey, string? requestUrl, StringContent? input)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apikey}");
                var response = await client.PostAsync(requestUrl, input);
                var responseContent = await response.Content.ReadAsStringAsync();
                var responType = new HttpGetModel();
                responType = JsonConvert.DeserializeObject<HttpGetModel>(responseContent);
                if (response.IsSuccessStatusCode == false)
                {
                    HttpGetModel.IsRequestSuccess = false;
                    if (responType.error.code == "invalid_api_key")
                    {
                        HttpGetModel.IsValidApiKey = false;
                        return $"#Api_Key无效";
                    }
                    else if (responType.error.message == "you must provide a model parameter")
                    {
                        HttpGetModel.IsValidApiKey = true;
                    }
                    string errorInfo = $"#错误类型：{responType.error.type}\n#错误内容：{responType.error.message}";
                    return errorInfo;
                }
                else
                {
                    HttpGetModel.IsRequestSuccess = true;
                    HttpGetModel.IsValidApiKey = true;
                    // 返回接收到的内容
                    return await Task.FromResult(result: responType?.Choicese?.First().MessageDetail.content);
                }
            }
            catch (Exception ex)
            {
                HttpGetModel.IsRequestSuccess = false;
                return $"#未经处理的异常：\n{ex.ToString().Substring(0,280)}";
            }
        }
    }
}
