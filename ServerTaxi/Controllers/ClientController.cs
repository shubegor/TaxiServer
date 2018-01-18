using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Threading.Tasks;
using DataModel.Data;
using DataModel.Entity;
using DataModel.Models;
using System.IO;
using System.Xml.Linq;
using DataModel;

namespace ServerTaxi.Controllers
{
    [RoutePrefix("api/client")]
    public class ClientController : ApiController
    {
        private IClientRequests repo;
        public ClientController(IClientRequests repo)
        {
            this.repo = repo;
        }

        [Route("MyOrders")]
        [HttpGet]

        public IHttpActionResult All()
        {
            List<OrderClientModel> s = null;
            try
            {
                s = repo.AllStat(User.Identity.Name);
                if (s != null) return Ok(s);
                else return BadRequest();
            }
            catch { return BadRequest(); }
            
            
        }

        [Route("NewOrder")]
        [HttpGet]
        public IHttpActionResult New(string a1, string a2)
        {
            try
            {
               repo.NewStat(a1, a2, GetDistance(a1, a2), User.Identity.Name);
            }
            catch { return BadRequest("Ошибка добавления заказа"); }
            return Ok();
        }


        [Route("CancelOrder")]
        [HttpDelete]
        public IHttpActionResult CancelOrder(Guid id)
        {

            try
            {
                repo.CancelOrderStat(id);
            }
            catch { return BadRequest("Ошибка добавления заказа"); }
            return Ok();
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
