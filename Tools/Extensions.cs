using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace VisualChatBot.Tools
{
    public static class Extensions
    {
        public static string ToXAMLString(this UIElement element)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
            XamlWriter.Save(element, xmlWriter);
            return stringWriter.ToString();
        }
    }
}
