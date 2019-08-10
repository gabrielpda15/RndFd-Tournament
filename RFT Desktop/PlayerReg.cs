using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RFT_Desktop
{
    public partial class PlayerReg : Form
    {
        public Player Player { get; private set; }

        public PlayerReg()
        {
            InitializeComponent();

            this.Load += PlayerReg_Load;

            cbElos.SelectedIndexChanged += CbElos_SelectedIndexChanged;

            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Player = new Player();

            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtNick.Text))
            {
                MessageBox.Show("Campos vazios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Player.Name = txtName.Text;
            Player.Nickname = txtNick.Text;

            var item = (Elo)cbElos.SelectedItem;
            if (item == Elo.Challenger || item == Elo.GrandMaster || item == Elo.Master)
            {
                Player.Elo = item;
            }
            else
            {
                if (cbElos2.SelectedIndex == 0)
                {
                    MessageBox.Show("Campos vazios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Player.Elo = item | (Elo)cbElos2.SelectedItem;
            }

            if (clbRoles.CheckedItems.Count == 0)
            {
                MessageBox.Show("Campos vazios!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var r = Role.None;
            foreach (Role i in clbRoles.CheckedItems)
            {
                r |= i;
            }

            Player.Roles = r;

            this.DialogResult = DialogResult.OK;
        }

        private void CbElos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Elo)cbElos.SelectedItem;
            if (item == Elo.Challenger || item == Elo.GrandMaster || item == Elo.Master)
            {
                cbElos2.Enabled = false;
                cbElos2.SelectedIndex = 0;
            }
            else
            {
                cbElos2.Enabled = true;
            }
        }

        private void PlayerReg_Load(object sender, EventArgs e)
        {
            var elos = Enum.GetValues(typeof(Elo)).Cast<Elo>().Where(x => x != Elo.None);

            cbElos2.Items.Add(Elo.None);
            cbElos2.Items.Add(Elo.I);
            cbElos2.Items.Add(Elo.II);
            cbElos2.Items.Add(Elo.III);
            cbElos2.Items.Add(Elo.IV);

            cbElos.Items.Add(Elo.Iron);
            cbElos.Items.Add(Elo.Bronze);
            cbElos.Items.Add(Elo.Silver);
            cbElos.Items.Add(Elo.Gold);
            cbElos.Items.Add(Elo.Platinum);
            cbElos.Items.Add(Elo.Diamond);
            cbElos.Items.Add(Elo.Master);
            cbElos.Items.Add(Elo.GrandMaster);
            cbElos.Items.Add(Elo.Challenger);

            cbElos2.SelectedIndex = 0;
            cbElos.SelectedIndex = 0;

            clbRoles.Items.Add(Role.Fill, false);
            clbRoles.Items.Add(Role.Top, false);
            clbRoles.Items.Add(Role.Jungle, false);
            clbRoles.Items.Add(Role.Mid, false);
            clbRoles.Items.Add(Role.Adc, false);
            clbRoles.Items.Add(Role.Support, false);
        }
    }
}
