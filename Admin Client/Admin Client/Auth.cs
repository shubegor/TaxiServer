using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;

namespace Admin_Client
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string site = "http://localhost:11821/";
            string user = Username.Text;
            string pass = Password.Text;
            //try
            //{
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(site + "Token");
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                var postData = "grant_type=password";
                postData += "&username=" + user;
                postData += "&password=" + pass;
                var data = Encoding.ASCII.GetBytes(postData);
                req.ContentLength = data.Length;

                using (var stream = req.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)req.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                string token = responseString.ToString();
                var x = token.Split('\\', '"');
                token = "";
                foreach (var a in x)
                {
                    if (token.Length < a.Length)
                        token = a;
                }

                AdminForm form = new AdminForm(token);
                form.Show();
                this.Hide();
            //}
            //catch { MessageBox.Show("Ошибка авторизации"); }
                      
            
        }
    }
}


//"{\"access_token\":\"xgB0_7KFnb_owMGfQqUvbDfcrwtHPxeDLY-DNy7AyJzaXJWNStD_nWdZ2gtzo-FVpQ2zilQ1nDzcPJLBkJsTx93i1JuS4uTcR2MQ6ND2OTL4ZflIuiV-VrNlj1rwW0DdcZf835SUfPb-7NS5WL8zcKS5gBCU3cZU6MetcAnJeTZajjJhYutC6OsHNf05xYJeBoS7OJlmjgwd3w-wqLrda9WAQcBncB66UTrUbk8XJUmdbAv4JiVkB34W6_2yyv-OXptwNO6M-51yf72eCrcGQKZgBrVTPLnpXQqJWEWC4oMNUrQU0pX1Qb169a3wvtKXiSOFO4gLpMmjg2K_-Hn_bw\",\"token_type\":\"bearer\",\"expires_in\":863999}"