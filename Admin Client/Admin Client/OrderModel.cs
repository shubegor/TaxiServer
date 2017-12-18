using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Client
{
    [DataContract]
    class OrderModel
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Phone_client { get; set; }

        [DataMember]
        public string Phone_driver { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string OrderDate { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
