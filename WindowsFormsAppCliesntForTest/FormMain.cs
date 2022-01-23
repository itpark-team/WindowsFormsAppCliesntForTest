using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using Newtonsoft.Json;
using WindowsFormsAppCliesntForTest.Models;

namespace WindowsFormsAppCliesntForTest
{
    public partial class FormMain : Form
    {
        private WebClient webClient;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.Headers.Set("content-type", "application/json");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jsonData = webClient.DownloadString("https://localhost:44361/Posts");

            List<PostData> postDatas = JsonConvert.DeserializeObject<List<PostData>>(jsonData);

            dataGridView1.DataSource = postDatas;

            MessageBox.Show("Ok");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PostData insertData = new PostData() { Id = 1111, UserId = 11111, Body = "sdsd123ds", Title = "fbgd23423h" };

            string jsonData = JsonConvert.SerializeObject(insertData);

            webClient.UploadString("https://localhost:44361/Posts", jsonData);

            MessageBox.Show("Ok");

        }
    }
}
