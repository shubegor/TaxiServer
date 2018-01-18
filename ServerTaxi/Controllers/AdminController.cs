using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataModel.Data;
using DataModel.Entity;
using DataModel.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace ServerTaxi.Controllers
{
    
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        private IAdminRequests repo;
        public AdminController(IAdminRequests repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [Route("EditUser")]
        [HttpPost]
        public IHttpActionResult EditUser(UsersModel UpUser)
        {
            try
            {
                var a = repo.EditUserStat(UpUser, User.Identity.Name);
                if (a != true) return BadRequest("Нет доступа");
                else return Ok();
            }
            catch { return BadRequest("Изменения не применены"); }

        }

        [Authorize]
        [Route("DeleteUser")]
        [HttpGet]
        public IHttpActionResult DeleteUser(string phone)
        {
            try
            {
                AccountController account = new AccountController();         
                var a = repo.DeleteUserStat(phone, User.Identity.Name);
                if (a != true) return BadRequest("Нет доступа");
                else return Ok();
            }
                catch { return BadRequest("Изменения не применены");}
        }

        [AllowAnonymous]
        [Route("NewUser")]
        [HttpPost]
        public async Task<IHttpActionResult> NewUser(User Nuser)
        {
            try
            {
                using (var db = new DB())
                {
                    //if (db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 0)
                    //    return BadRequest("Ошибка доступа");
                    AccountController a = new AccountController();
                    await a.Register(Nuser);
                }
            }
            catch
            {
                return BadRequest("Ошибка созания пользователя");
            }
            
                return Ok();
        }

        [Authorize]
        [Route("AllUser")]
        [HttpGet]
        public List<UsersModel> AllUser()
        {
                List<UsersModel> list = null;
            try
            {
                list = repo.AllUserStat(User.Identity.Name);
                
            }
            catch { }
                return list;
        }

        [Authorize]
        [Route("Orders")]
        [HttpGet]
        public List<OrderModel> Orders()
        {
            List<OrderModel> s = null;
            try
            {
                s = repo.OrdersStat(User.Identity.Name);
            } catch { }
            return s;
        }


    }
}
