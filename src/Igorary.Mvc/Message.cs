using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covalition.Igorary.Mvc
{
    public class Message
    {
        public MessageType MessageType { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Jeżeli True, traktuje tekst jako kod HTML.
        /// </summary>
        public bool AsHtml { get; set; }
    }
}