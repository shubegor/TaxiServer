using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Admin_Client
{
    public partial class EditUser : Form
    {
        
        UserModel SendUser;
        AdminForm Parent;
        public EditUser(UserModel user, AdminForm parent)
        {
            InitializeComponent();
            FIO.Text = user.FIO;
            Auto.Text = user.Auto;
            GosNum.Text = user.AutoNumber;
            Email.Text = user.Email;
            Role.SelectedIndex = user.RoleId;
            UserLable.Text += user.Phone;
            this.Parent = parent;
            SendUser = user;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SendUser.Auto = Auto.Text;
            SendUser.AutoNumber = GosNum.Text;
            SendUser.Email = Email.Text;
            SendUser.FIO = FIO.Text;
            SendUser.RoleId = Role.SelectedIndex;
            string site = "http://localhost:11821/";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(site + "api/Admin/EditUser");
                request.ContentType = "application/json";
                request.Headers.Add("Authorization: Bearer " + Parent.GetToken());
                request.Method = "POST";
                
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(SendUser);
                    streamWriter.Write(json);
                    
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();

            }catch { }

            Parent.UpdateGrid();
            this.Close();
        }

        
    }
}
