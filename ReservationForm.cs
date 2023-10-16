using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace covid19_care_app
{
    public partial class ReservationForm : Form
    {
        private String idStructure;
        private String typeRV;
        public ReservationForm(String idStructure, String typeRV)
        {
            InitializeComponent();
            this.typeRV = typeRV;
            this.idStructure = idStructure;
            List<String> listRV = new List<string> { };
            listRV.Add(this.typeRV);
            typeRvComboBox.DataSource = listRV;
        }
    }
}