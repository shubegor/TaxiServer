using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Client
{
    public partial class AddUser : Form
    {
        AdminForm Parent;
        public AddUser(AdminForm Parent)
        {
            InitializeComponent();
            this.Parent = Parent;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            UserModel newUser = new UserModel
                {
                Phone = Phone.Text,
                FIO = FIO.Text,
                Auto = Auto.Text,
                AutoNumber = GosNum.Text,
                Email = Email.Text,
                Password = Password.Text
                };

            string site = "http://localhost:11821/";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(site + "api/Admin/NewUser");
                request.ContentType = "application/json";
                request.Headers.Add("Authorization: Bearer " + Parent.GetToken());
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(newUser);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();

            }
            catch { }

            Parent.UpdateGrid();
            this.Close();
        }
    }
}
