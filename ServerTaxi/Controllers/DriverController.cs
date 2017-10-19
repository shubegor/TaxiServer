using ServerTaxi.Data;
using ServerTaxi.Data.Entity;
using ServerTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;


namespace ServerTaxi.Controllers
{
    [Authorize(Roles = "Driver")]
    [RoutePrefix("api/Driver")]
    public class DriverController : ApiController
    {
        [Route("TakeOrder")]
        [HttpGet]
        public IHttpActionResult TakeOrder(Guid id)
        {
            using (var db = new DB())
            {
                var query = (from a in db.Orders
                             where a.Id == id
                             select a).SingleOrDefault();

                if (query.Driver == null &&
                    query.Status == Status.Active)
                {
                    query.Status = Status.InProgress;
                    query.Driver = db.Users.FirstOrDefault(l => l.Phone == User.Identity.Name);
                    db.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest("Ошибка");
        }


        [Route("ConfirmOrder")]
        [HttpGet]
        public IHttpActionResult ConfirmOrder(Guid id)
        {
            using (var db = new DB())
            {
                var query = (from a in db.Orders
                             where a.Id == id
                             select a).SingleOrDefault();

                if (query.Driver.Phone == User.Identity.Name  &&
                    query.Status == Status.InProgress)
                {
                    query.Status = Status.Done;
                    db.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest("Ошибка");
        }

        [Route("MyOrders")]
        [HttpGet]

        public IHttpActionResult All()
        {
            List<OrderModel> s = null; //todo поменять модель для таксиста
            using (var db = new DB())
            {
                s = db.Orders
                .Include(l => l.Client)
                .Include(l => l.Driver)
                .Where(l => l.Phone_driver == User.Identity.Name)
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


                return Ok(s);
            }
        }

    }
}
