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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFT_Desktop
{
    public partial class TournamentReg : Form
    {
        public Tournament Tournament { get; private set; }

        public TournamentReg()
        {
            InitializeComponent();

            this.Load += TournamentReg_Load;
            panel1.Enabled = false;
        }

        private void TournamentReg_Load(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/player");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var result = Enumerable.Empty<Player>();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = JsonConvert.DeserializeObject<IEnumerable<Player>>(streamReader.ReadToEnd());
            }

            foreach(var r in result)
            {
                comboBox1.Items.Add(r);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var pt = new List<PlayerTournament>();
            foreach (Player item in comboBox1.Items)
            {
                pt.Add(new PlayerTournament
                {
                    TournamentId = Tournament.Id,
                    PlayerId = item.Id
                });
            }
            Tournament.PlayerTournaments = pt.ToArray();

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/tournament");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new PostRequest<Tournament>
                {
                    Entity = Tournament,
                    User = new User
                    {
                        Username = "RFT Desktop"
                    }
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Tournament = new Tournament();
            Tournament.Name = textBox1.Text;
            Tournament.Date = dateTimePicker1.Value;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/api/tournament");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(new PostRequest<Tournament>
                {
                    Entity = Tournament,
                    User = new User
                    {
                        Username = "RFT Desktop"
                    }
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    Tournament = JsonConvert.DeserializeObject<Tournament>(streamReader.ReadToEnd());                    
                }
                panel1.Enabled = true;
            }
        }
    }
}
