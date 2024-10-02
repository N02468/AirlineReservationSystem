using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ARS.Models
{
    public class ContextCS : DbContext
    {

        public ContextCS() : base("cs")
        {

        }


        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserAccount> UserLogins { get; set; }
        public DbSet<AeroPlaneInfo> PlaneInfo { get; set; }
        public DbSet<Flightbooking> Flightbookings { get; set; }
        public DbSet<TicketReserve_tbl> TicketReserve_tbl { get; set; } // Keep only one reference to TicketReserve_tbl
        
        // Updated casing

    } 
}