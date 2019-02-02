using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormdan_WebApiye_baglanmak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //WINFORMDAN APIYE BAGLANMAK !!!
        //Async ye dikkat
 
        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:60005");

            HttpResponseMessage httpResponse = await client.GetAsync("api/sehir/1");

            string result = await httpResponse.Content.ReadAsStringAsync();

            MessageBox.Show(result);
        }
    }
}
