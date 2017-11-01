using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerTaxi.Data.Entity;
using ServerTaxi.Data;
using System.Data.Entity;
using ServerTaxi.Models;
using ServerTaxi.Controllers;
using System.Threading.Tasks;

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
                using (var db = new DB())
                {
                    if (db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 0)
                        return BadRequest("Ошибка доступа");
                    db.Entry(UpUser).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return Ok();
            }
            catch { return BadRequest("Изменения не применены"); }
            
        }


        [Route("DeleteUser")]
        [HttpGet]
        public IHttpActionResult DeleteUser(string phone)
        {
            try
            {
                using (var db = new DB())
                {
                    if (db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 0)
                        return BadRequest("Ошибка доступа");
                    db.Users.Remove(db.Users.FirstOrDefault(l => l.Phone == phone));
                    db.SaveChanges();
                }
                return Ok();
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

                using (var db = new DB())
                {
                if (db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 0)
                    return list;
                list = db.Users
                        .Select(l => new UsersModel()
                        {
                            Phone = l.Phone,
                            FIO = l.FIO,
                            Email = l.Email,
                            Auto = l.Auto,
                            AutoNumber = l.AutoNumber,
                            RegistrationDate = l.RegistrationDate,
                            Password = l.Password,
                            RoleId = l.RoleId

                        }).ToList();
                    
                }
                return list;
        }

        [Route("Orders")]
        public List<OrderModel> Orders()
        {
            List<OrderModel> s = null;
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 0)
                    return s;
                s = db.Orders
                    .Include(l => l.Client)
                    .Include(l => l.Driver)
                    .Select(l => new OrderModel
                    {
                        Id = l.Id,
                        OrderDate = l.OrderDate,
                        Address1 = l.Address1,
                        Address2 = l.Address2,
                        Phone_client = l.Client.Phone,
                        Phone_driver = l.Driver.Phone,
                        Price = l.Price,
                        Status = l.Status
                    }).ToList();
            }
            return s;
        }


    }
}
