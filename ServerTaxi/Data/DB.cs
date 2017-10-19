using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServerTaxi.Data.Entity;

namespace ServerTaxi.Data
{
    public class DB : DbContext
    {
        public DB() : base("AuthContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
       
    }
}