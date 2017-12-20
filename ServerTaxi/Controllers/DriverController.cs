using DataModel.Data;
using DataModel.Entity;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using DataModel;

namespace ServerTaxi.Controllers
{
    [Authorize(Roles = "Driver")]
    [RoutePrefix("api/Driver")]
    public class DriverController : ApiController
    {
        private IDriverRequests repo;
        public DriverController(IDriverRequests repo)
        {
            this.repo = repo;
        }

        [Route("TakeOrder")]
        [HttpGet]
        public IHttpActionResult TakeOrder(Guid id)
        {
            try
            {
                var a = repo.TakeOrderStat(id, User.Identity.Name);
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
                var a = repo.ConfirmOrderStat(id, User.Identity.Name);
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
                s = repo.AllStat(User.Identity.Name);
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
                s = repo.OrdersStat(User.Identity.Name);
                if (s != null) return Ok(s);
                else return BadRequest("Нет доступа");
            }
            catch { return BadRequest("Ошибка"); }

        }


    }
}
