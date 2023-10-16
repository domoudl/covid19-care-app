using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using covid19_care_app.UserControls;

namespace covid19_care_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UC_Acceuil ucAcceuil = new UC_Acceuil();
            addUserControl(ucAcceuil);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
            
        }
        private void btnAcceuil_Click(object sender, EventArgs e)
        {
           // throw new System.NotImplementedException();
            UC_Acceuil ucAcceuil = new UC_Acceuil();
            addUserControl(ucAcceuil);
        }

        private async void btnSS_Click(object sender, EventArgs e)
        {
            UC_SS ucSs = new UC_SS();
            addUserControl(ucSs);
            await ucSs.ChargerListeStructuresSanteDepuisAPI();
        }

        private async void btnCarte_Click(object sender, EventArgs e)
        {
            UC_Carte ucCarte = new UC_Carte();
            addUserControl(ucCarte);
            await ucCarte.ChargerListeStructuresSanteDepuisAPI();
            ucCarte.GoToCoordinate();
        }

        private async void btnRV_Click(object sender, EventArgs e)
        {
            UC_RV ucRv = new UC_RV();
            addUserControl(ucRv);
            await ucRv.ChargerListeDisponibiliteDepuisAPI();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}