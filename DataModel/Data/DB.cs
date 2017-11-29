using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataModel.Entity;
using System.Data.Entity;
using System.Configuration;

namespace DataModel.Data
{
    public class DB : DbContext
    {
       
        public DB() : base("name = AuthContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
       
    }
}