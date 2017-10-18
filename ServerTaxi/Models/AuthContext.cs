using Microsoft.AspNet.Identity.EntityFramework;
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

        public DbSet<UserModel> UsersT { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

       
    }
}