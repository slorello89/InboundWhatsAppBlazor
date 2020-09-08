using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhatsAppBlazorInboundEntity.Shared
{
    public class WhatsAppMessage
    {
        [Key]
        public string MessageId { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Text { get; set; }
    }

}
