using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.Models;
using DataModel.Entity;
using DataModel.Data;
using System.Data.Entity;
using DataModel;
namespace DBAccess
{
    public class DriverReqests : IDriverRequests
    {
        public static List<OrderModel> All(string phone)
        {
            List<OrderModel> s = null;
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 2)
                    return s;
                s = db.Orders
                .Include(l => l.Client)
                .Include(l => l.Driver)
                .Where(l => l.Phone_driver == phone)
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
                return s;
            }
        }

        public static bool TakeOrder(Guid id, string phone)
        {
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 2)
                    return false;

                var query = (from a in db.Orders
                             where a.Id == id
                             select a).SingleOrDefault();
                if (query.Driver == null &&
                    query.Status == Status.Active)
                {
                    query.Status = Status.InProgress;
                    query.Driver = db.Users.FirstOrDefault(l => l.Phone == phone);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool ConfirmOrder(Guid id, string phone)
        {
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 2)
                    return false;
                var query = (from a in db.Orders
                             where a.Id == id
                             select a).SingleOrDefault();

                if (query.Driver.Phone == phone &&
                    query.Status == Status.InProgress)
                {
                    query.Status = Status.Done;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static List<OrderModel> Orders(string phone)
        {
            List<OrderModel> s = null;
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 2)
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
                    })
                    .Where(l=> l.Status == Status.Active)
                    .ToList();
            }
            return s;
        }

        public List<OrderModel> AllStat(string phone)
        {
            return All(phone);
        }

        public bool TakeOrderStat(Guid id, string phone)
        {
            return TakeOrder(id, phone);
        }

        public bool ConfirmOrderStat(Guid id, string phone)
        {
            return ConfirmOrder(id, phone);
        }

        public List<OrderModel> OrdersStat(string phone)
        {
            return Orders(phone);
        }
    }
}
