using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models
{
    public class OrderClientModel
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone_driver { get; set; }
        public string Car { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}