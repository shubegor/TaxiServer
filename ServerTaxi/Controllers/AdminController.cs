using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataModel.Data;
using DataModel.Entity;
using DataModel.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ServerTaxi.Controllers
{
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        [Route("EditUser")]
        [HttpPost]
        public IHttpActionResult EditUser(User UpUser)
        {
            try
            {
                var a = DBAccess.AdminRequests.EditUser(UpUser, User.Identity.Name);
                if (a != true) return BadRequest("Нет доступа");
                else return Ok();
            }
            catch { return BadRequest("Изменения не применены"); }
            
        }


        [Route("DeleteUser")]
        [HttpGet]
        public IHttpActionResult DeleteUser(string phone)
        {
            try
            {
                var a = DBAccess.AdminRequests.DeleteUser(phone, User.Identity.Name);
                if (a != true) return BadRequest("Нет доступа");
                else return Ok();
            }
            catch { return BadRequest("Изменения не применены"); }
        }


        [Route("NewUser")]
        [HttpPost]
        public async Task<IHttpActionResult> NewUser(User Nuser)
        {
            try
            {
                using (var db = new DB())
                {
                    if (db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 0)
                        return BadRequest("Ошибка доступа");
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

        [Route("AllUser")]
        [HttpGet]
        public List<UsersModel> AllUser()
        {
                List<UsersModel> list = null;
            try
            {
                list = DBAccess.AdminRequests.AllUser(User.Identity.Name);
            }
            catch { }
                return list;
        }

        [Route("Orders")]
        public List<OrderModel> Orders()
        {
            List<OrderModel> s = null;
            try
            {
                s = DBAccess.AdminRequests.Orders(User.Identity.Name);
            } catch { }
            return s;
        }


    }
}
