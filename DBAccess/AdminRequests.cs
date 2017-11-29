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
        public static bool EditUser(User UpUser, string phone)
        {
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 0)
                    return false;
                db.Entry(UpUser).State = EntityState.Modified;
                db.SaveChanges();
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
