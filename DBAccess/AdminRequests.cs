using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.Models;
using DataModel.Entity;
using DataModel.Data;
using System.Data.Entity;

namespace DBAccess
{
    public class AdminRequests
    {
        public static bool EditUser(UsersModel UpUser, string phone)
        {
           
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 0)
                    return false;

                db.Users.FirstOrDefault(x => x.Phone == UpUser.Phone).Auto = UpUser.Auto;
                db.Users.FirstOrDefault(x => x.Phone == UpUser.Phone).AutoNumber = UpUser.AutoNumber;
                db.Users.FirstOrDefault(x => x.Phone == UpUser.Phone).Email = UpUser.Email;
                db.Users.FirstOrDefault(x => x.Phone == UpUser.Phone).FIO = UpUser.FIO;
                db.Users.FirstOrDefault(x => x.Phone == UpUser.Phone).RoleId = UpUser.RoleId;

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                
                return true;
            }
        }

        public static bool DeleteUser(string Uphone, string phone)
        {
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 0)
                    return false;
                
                db.Users.Remove(db.Users.FirstOrDefault(l => l.Phone == Uphone));
                db.SaveChanges();
            }
            return true;
        }

        public static List<UsersModel> AllUser(string phone)
        {
            List<UsersModel> list = null;
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 0)
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
                return list;
            }
        
        }

        public static List<OrderModel> Orders(string phone)
        {
            List<OrderModel> s = null;
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 0)
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
