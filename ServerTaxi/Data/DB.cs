using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ServerTaxi.Models;

namespace ServerTaxi.Data
{
    public class DB : DbContext
    {
        public DB() : base("AuthContext")
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
       
    }
}