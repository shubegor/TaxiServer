using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Client
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Auto { get; set; }
        [DataMember]
        public string AutoNumber { get; set; }
        [DataMember]
        public string RegistrationDate { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int RoleId { get; set; }
    }
}
