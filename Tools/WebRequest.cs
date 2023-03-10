using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VisualChatBot.Models;

namespace VisualChatBot.Tools
{
    public class WebRequest
    {
        public async Task<string?> WebRequestMethon(string? apikey,string? requestUrl,StringContent? input)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apikey}");
                    var response = await client.PostAsync(requestUrl, input);
                    response.Content.Headers.ContentLength = 1024;
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responType = new HttpGetModel();
                    responType = JsonConvert.DeserializeObject<HttpGetModel>(responseContent);
                    if (response.IsSuccessStatusCode == false)
                    {
                        if(responType.error.code== "invalid_api_key")
                        {
                            HttpGetModel.IsValidApiKey = false;
                            return $"\n\nApi_Key无效，请在下方输入正确的Api_Key，并点击发送";
                        }
                        else if(responType.error.message == "you must provide a model parameter")
                        {
                            HttpGetModel.IsValidApiKey = true;
                        }
                        string errorInfo = $"\n错误类型：{responType.error.type}\n错误内容：{responType.error.message}\n\n";
                        return errorInfo;
                    }
                    HttpGetModel.IsValidApiKey = true;
                    // 返回接收到的内容
                    return await Task.FromResult(result: responType?.Choicese?.First().Text);
                }
            }
            catch(Exception ex)
            {
                return $"\n错误：\n{ex}\n";
            }
        }
    }
}
