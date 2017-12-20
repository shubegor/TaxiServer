using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.Models;
using DataModel.Entity;
using DataModel.Data;
using DataModel;
using System.Data.Entity;
namespace DBAccess
{
    public class ClientRequests : IClientRequests
    {
        public List<OrderClientModel> AllStat(string phone)
        {
            return All(phone);
        }

        public void CancelOrderStat(Guid id)
        {
            CancelOrder(id);
        }

        public void NewStat(string a1, string a2, int distance, string phone)
        {
            New(a1, a2, distance, phone);
        }


        public static List<OrderClientModel> All(string phone)
        {
            List<OrderClientModel> s = null;
            using (var db = new DB())
            {
                if (db.Users.FirstOrDefault(x => x.Phone == phone).RoleId != 1) return s;

                s = db.Orders
               .Include(l => l.Client)
               .Include(l => l.Driver)
               .Where(l => l.Phone_client == phone)
               .Select(l => new OrderClientModel
               {
                   Id = l.Id,
                   OrderDate = l.OrderDate,
                   Address1 = l.Address1,
                   Address2 = l.Address2,
                   Phone_driver = l.Driver.Phone,
                   Car = l.Driver.Auto + " " + l.Driver.AutoNumber,
                   Price = l.Price,
                   Status = l.Status
               })
               .OrderBy(x => x.OrderDate)
               .ToList();

                return s;
            }
        }

        public static void New(string a1, string a2, int distance, string phone)
        {
            Order order = new Order();
            using (var db = new DB())
            {
                order.Id = Guid.NewGuid();
                order.Address1 = a1;
                order.Address2 = a2;
                order.Phone_client = phone;
                order.Price = distance / 33;
                order.OrderDate = DateTime.Now;
                order.Status = Status.Active;
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public static void CancelOrder(Guid id)
        {
            using (var db = new DB())
            {
                var query = (from a in db.Orders
                             where a.Id == id
                             select a).SingleOrDefault();

                if (query.Driver == null &&
                    query.Status == Status.Active)
                {
                    query.Status = Status.Canceled;
                    db.SaveChanges();
                }

            }
        }
    }

}
