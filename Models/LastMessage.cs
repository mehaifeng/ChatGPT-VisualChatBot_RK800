using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualChatBot.Models
{
    public class LastMessage
    {
        /// <summary>
        /// 上次的所有对话
        /// </summary>
        public static List<Message> AllMessage { get; set; } = new List<Message>();
    }
}
