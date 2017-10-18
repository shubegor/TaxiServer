using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using ServerTaxi.Models;
using System.Threading.Tasks;
using ServerTaxi.Data;

namespace ServerTaxi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        [Route("All")]
        [HttpGet]
        public IHttpActionResult All()
        {
            using (var db = new DB())
            {
                
                List<OrderModelModel> s = db.Orders
                    .Include(l => l.Client)
                    .Include(l => l.Driver)
                    .Where(l => l.Phone_client == User.Identity.Name)
                    .Select(l => new OrderModelModel

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
                    
                    .ToList();

                return Ok(s);
            }
        }

        [Route("New")]
        public IHttpActionResult New(OrderModel order)
        {
            using (var db = new DB())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
            return Ok();
        }


    }
}
