using DataModel.Data;
using DataModel.Entity;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var a = DBAccess.DriverReqests.TakeOrder(id, User.Identity.Name);
                if (a == true) return Ok();
                else
                    return BadRequest("Нет доступа");
            }
            catch
            {
                return BadRequest("Ошибка");
            }
        }


        [Route("ConfirmOrder")]
        [HttpGet]
        public IHttpActionResult ConfirmOrder(Guid id)
        {
            try
            {
                var a = DBAccess.DriverReqests.ConfirmOrder(id, User.Identity.Name);
                if (a == true) return Ok();
                else
                    return BadRequest("Нет доступа");
            }
            catch { return BadRequest("Ошибка"); }
            
        }

        [Route("MyOrders")]
        [HttpGet]

        public IHttpActionResult All()
        {

            List<OrderModel> s = null;
            try
            {
                s = DBAccess.DriverReqests.All(User.Identity.Name);
                if (s != null) return Ok(s);
                else return BadRequest("Нет доступа");
            }
            catch { return BadRequest("Ошибка"); }
            
        }

        [Route("Orders")]
        [HttpGet]
        public IHttpActionResult Orders()
        {

            List<OrderModel> s = null;
            try
            {
                s = DBAccess.DriverReqests.Orders(User.Identity.Name);
                if (s != null) return Ok(s);
                else return BadRequest("Нет доступа");
            }
            catch { return BadRequest("Ошибка"); }

        }


    }
}
