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
using System.Runtime.Serialization.Json;

namespace Admin_Client
{
    public partial class AdminForm : Form
    {
        public AdminForm(string token)
        {
            Token = token;
            InitializeComponent();
            BuildGrid();
            Closing += new System.ComponentModel.CancelEventHandler(this.OnWindowClosing);
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        public string GetToken()
        {
            return Token;
        }
            
        public static string Token;
        
        public string site = "http://localhost:11821/";
        public UserModel ChoosenUser;
        public void BuildGrid()
        {
            UserGrid.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(OnRowHeaderMouseClick);

            GRID.DataSource = DataReqOrders();
            UpdateGrid();
        }

        private void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChoosenUser = new UserModel
            {
                Phone = UserGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                FIO = UserGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),
                Email = UserGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                Auto = UserGrid.Rows[e.RowIndex].Cells[3].Value.ToString(),
                AutoNumber = UserGrid.Rows[e.RowIndex].Cells[4].Value.ToString(),
                RegistrationDate = UserGrid.Rows[e.RowIndex].Cells[5].Value.ToString(),
                Password = UserGrid.Rows[e.RowIndex].Cells[6].Value.ToString(),
                RoleId = int.Parse(UserGrid.Rows[e.RowIndex].Cells[7].Value.ToString())
            };
            
            EditUserButton.Enabled =  DeleteUserButton.Enabled = true;
        }


        private static List<OrderModel> DataReqOrders()
        {
            List<OrderModel> ord = new List<OrderModel>();

            string site = "http://localhost:11821/";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(site + "api/Admin/Orders");
                request.ContentType = "application/json";
                request.Headers.Add("Authorization: Bearer " + Token);

                using (var httpWebResponse = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = httpWebResponse.GetResponseStream();   
                    DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<OrderModel>));
                    ord = (List<OrderModel>)JsonSerializer.ReadObject(stream);
                }

                
            } catch {  }
                return ord;
        }

        private static List<UserModel> DataReqUsers()
        {
            List<UserModel> users = new List<UserModel>();
            string site = "http://localhost:11821/";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(site + "api/Admin/AllUser");
                request.ContentType = "application/json";
                request.Headers.Add("Authorization: Bearer " + Token);

                using (var httpWebResponse = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = httpWebResponse.GetResponseStream();
                    DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<UserModel>));
                    users = (List<UserModel>)JsonSerializer.ReadObject(stream);
                }


            }
            catch { }
            return users;
        }


        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить пользователя " + ChoosenUser.Phone + "?", "Удалить пользователя", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                WebRequest myWebRequest = WebRequest.Create(site + "api/Admin/DeleteUser?phone=" + ChoosenUser.Phone);
                myWebRequest.Headers.Add("Authorization: Bearer " + Token);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                UpdateGrid();
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            EditUser edit = new EditUser(ChoosenUser, this);
            
            edit.Show();
        }
        public void UpdateGrid()
        {
            UserGrid.DataSource = DataReqUsers();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser(this);
            form.Show();
        }
    }
}
