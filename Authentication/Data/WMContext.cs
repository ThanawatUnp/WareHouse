using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Authentication.Data
{
    public class WMContext : IdentityDbContext
    {
        public WMContext(DbContextOptions<WMContext> options)
            : base(options)
        {
        }

        public DbSet<Authentication.Models.Customer> Customer { get; set; }
        public DbSet<Authentication.Models.Supplier> Supplier { get; set; }
        public DbSet<Authentication.Models.Item> Item { get; set; }
        public DbSet<Authentication.Models.ItemCategory> ItemCategory { get; set; }
        public DbSet<Authentication.Models.Location> Location { get; set; }
        public DbSet<Authentication.Models.LocationCategory> LocationCategory { get; set; }
        public DbSet<Authentication.Models.Province> Province { get; set; }
        public DbSet<Authentication.Models.District> District { get; set; }
        public DbSet<Authentication.Models.SubDistrict> SubDistrict { get; set; }
        public DbSet<Authentication.Models.UserMangement> UserMangement { get; set; }
        public DbSet<Authentication.Models.QueueType> QueueType { get; set; }
        public DbSet<Authentication.Models.OrderType> OrderType { get; set; }
        public DbSet<Authentication.Models.InboundOrder> InboundOrder { get; set; }
        public DbSet<Authentication.Models.InboundItem> InboundItem { get; set; }
        public DbSet<Authentication.Models.StatusInboundOrder> StatusInboundOrder { get; set; }
        public DbSet<Authentication.Models.ItemReceived> ItemReceived { get; set; }
        public DbSet<Authentication.Models.ItemReceivedState> ItemReceivedState { get; set; }
        public DbSet<Authentication.Models.Inventory> Inventory { get; set; }
        public DbSet<Authentication.Models.OutboundOrder> OutboundOrder { get; set; }
        public DbSet<Authentication.Models.OutboundItem> OutboundItem { get; set; }
        public DbSet<Authentication.Models.StatusOutboundOrder> StatusOutboundOrder { get; set; }
    }
}
