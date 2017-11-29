using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataModel.Entity;
using ServerTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ServerTaxi.Utilites
{
    public class AuthRepository : IDisposable
    {
        private AuthContext authContext;
        private UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            authContext = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(authContext));
        }

        public async Task<IdentityResult> RegisterUser(User userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Phone
            };
            var result = await userManager.CreateAsync(user, userModel.Password);
           
                

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            return await userManager.FindAsync(userName, password);
        }

        public void Dispose()
        {
            authContext.Dispose();
            userManager.Dispose();
        }
    }
}