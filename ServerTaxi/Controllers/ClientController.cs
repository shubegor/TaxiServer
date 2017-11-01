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
using ServerTaxi.Data.Entity;
using System.IO;
using System.Xml.Linq;

namespace ServerTaxi.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        
        [Route("MyOrders")]
        [HttpGet]

        public IHttpActionResult All()
        {
            
            List<OrderClientModel> s = null;
            using (var db = new DB())
            {

                     if(db.Users.FirstOrDefault(x => x.Phone == User.Identity.Name).RoleId != 1);
                     s = db.Orders
                    .Include(l => l.Client)
                    .Include(l => l.Driver)
                    .Where(l => l.Phone_client == User.Identity.Name)
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
                    .OrderBy(x=> x.OrderDate)
                    .ToList();
                
                
                return Ok(s);
            }
        }

        [Route("NewOrder")]
        [HttpGet]
        public IHttpActionResult New(string a1, string a2)
        {
            Order order = new Order();
            try
            {
                using (var db = new DB())
                {
                    order.Id = Guid.NewGuid();
                    order.Address1 = a1;
                    order.Address2 = a2;
                    order.Phone_client = User.Identity.Name;
                    order.Price = GetDistance(a1, a2) / 33;
                    order.OrderDate = DateTime.Now;
                    order.Status = Status.Active;
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }
            catch { return BadRequest("Ошибка добавления заказа"); }
            return Ok();
        }


        [Route("CancelOrder")]
        [HttpGet]
        public IHttpActionResult CancelOrder(Guid id)
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
                        return Ok();
                    }
                               
            }
            return BadRequest("Отменить заказ невозможно");
        }


        public static int GetDistance(string start, string finish)
        {
            start = "Томск, " + start;
            finish = "Томск, " + finish;
            string ApiKey = "AIzaSyAKOmWFijEq8Ew0e81Wfb_Kb1srTpNQ-54";
            string url = string.Format(
                "https://maps.googleapis.com/maps/api/distancematrix/xml?origins={0}&destinations={1}&key={2}",
                    start, finish, ApiKey);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            XDocument xm = XDocument.Load(new StringReader(reader.ReadToEnd()));
            try
            {
                return int.Parse(xm.Root.Element("row").Element("element").Element("distance").Element("value").Value);
            }
            catch { return 0; }
        }

    }
}
