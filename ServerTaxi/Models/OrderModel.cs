using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServerTaxi.Models
{
    [Table("Orders")]
    public class OrderModel
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }


        [Column("Client")]
        public string Phone_client { get; set; }

        [ForeignKey("Phone_client")]
        public UserModel Client { get; set; }



        [Column("Driver")]
        public string Phone_driver { get; set; }

        [ForeignKey("Phone_driver")]
        public UserModel Driver { get; set; }


        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

    }
}