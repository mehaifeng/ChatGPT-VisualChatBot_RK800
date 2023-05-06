using System.Collections.Generic;

namespace VisualChatBot.Models
{
    public class HistoryMessage
    {
        /// <summary>
        /// 上次的所有对话
        /// </summary>
        public List<Message> AllMessage { get; set; } = new List<Message>();
        /// <summary>
        /// 对话标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 控件构造
        /// </summary>
        public string ControlStruct { get; set; }
    }
}
