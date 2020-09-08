using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppBlazorInboundEntity.Shared;

namespace WhatsAppBlazorInboundEntity.Server
{
    public class WhatsAppContext : DbContext
    {
        public DbSet<WhatsAppMessage> Messages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=VonageWhatsApp.db");
    }
}
