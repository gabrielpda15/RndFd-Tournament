using Newtonsoft.Json;
using RFT.Api.Repository.Models;
using RFT_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFT_Desktop
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var pr = new PlayerReg();
            var result = pr.ShowDialog();
            if (result == DialogResult.OK)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/player");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(new PostRequest<Player>
                    {
                        Entity = pr.Player,
                        User = new User
                        {
                            Username = "RFT Desktop"
                        }
                    });

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Inserido com sucesso");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new TournamentReg().ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/tournament/0/teams");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<IEnumerable<Player>>>(streamReader.ReadToEnd());
                var ti = new Times();

                var i = 1;
                foreach (var team in result)
                {
                    var players = new List<TreeNode>();
                    foreach (var p in team)
                    {
                        players.Add(new TreeNode(p.ToString()));
                    }

                    ti.treeView1.Nodes.Add(new TreeNode("Time " + i++, players.ToArray()));
                }
                ti.ShowDialog();
            }
        }
    }
}
