using Microsoft.AspNet.Identity.EntityFramework;
using DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServerTaxi.Models
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext", throwIfV1Schema: false)
        {
        }


        public static AuthContext Create()
        {
            return new AuthContext();
        }

        public DbSet<User> UsersT { get; set; }
        public DbSet<Order> Orders { get; set; }

       
    }
}