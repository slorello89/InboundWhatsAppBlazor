using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Nexmo.Api.Utility;
using WhatsAppBlazorInboundEntity.Shared;

namespace WhatsAppBlazorInboundEntity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly WhatsAppContext _db;
        public WhatsAppController(WhatsAppContext db)
        {
            _db = db;
        }
        [Route("/webhooks/inbound-message")]
        [HttpPost]
        public ActionResult InboundWhatsAppMessage()
        {
            var inbound = WebhookParser.ParseWebhook<JObject>
                (Request.Body, Request.ContentType);
            var message = new WhatsAppMessage
            {
                MessageId = inbound["message_uuid"].ToString(),
                From = inbound["from"]["number"].ToString(),
                To = inbound["to"]["number"].ToString(),
                Text = inbound["message"]["content"]["text"].ToString()
            };
            _db.Messages.Add(message);
            _db.SaveChanges();
            return Ok();
        }

        [Route("getMessages")]
        [HttpGet]
        public ActionResult GetMessages()
        {
            return Ok(_db.Messages.Take(10));
        }
    }
}
