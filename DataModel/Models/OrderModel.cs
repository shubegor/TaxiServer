using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataModel.Models
{
    public class OrderModel
    {
        [Key]
       
        public Guid Id { get; set; }
        public string Phone_client { get; set; }
        public string Phone_driver { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}