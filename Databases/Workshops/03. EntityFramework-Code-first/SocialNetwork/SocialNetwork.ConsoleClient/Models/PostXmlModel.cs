using System;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.Models
{
    [Serializable]
    [XmlType("Post")]
    public class PostXmlModel
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}
