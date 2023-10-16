using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using covid19_care_app.Models;

namespace covid19_care_app.UserControls
{
    public partial class UC_RV : UserControl
    {
        public UC_RV()
        {
            InitializeComponent();
            
            MaDataGridView.CellContentClick += MaDataGridView_CellContentClick;
     
 
        }
        
        public async Task ChargerListeDisponibiliteDepuisAPI()
        {
            // Utilise HttpClient pour envoyer une requête GET à ton API
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://localhost:8888/Disponibilite";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
        
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    
                    // Désérialise les données JSON reçues depuis l'API en objets C#
                    List<Disponibilite> structuresDispo = JsonSerializer.Deserialize<List<Disponibilite>>(responseBody);
                    DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
                    idColumn.Name = "Id";
                    idColumn.Visible = false;
                    MaDataGridView.Columns.Add(idColumn);
                    MaDataGridView.Columns.Add("Nom", "Nom");
                    MaDataGridView.Columns.Add("Contact", "Contact");
                    MaDataGridView.Columns.Add("Adresse", "Adresse");
                    MaDataGridView.Columns.Add("Disponibilite", "Disponibilite");
                    DataGridViewButtonColumn operationColumn = new DataGridViewButtonColumn();
                    operationColumn.HeaderText = "Operation";
                    operationColumn.Name = "Operation";
                    operationColumn.Text = "Reserver";
                    MaDataGridView.Columns.Add(operationColumn);

                    foreach (var elt in structuresDispo)
                    {
                        String Id = elt.structureMedical.id.ToString();
                        String Nom = "";
                        String Contact = "";
                        String Adresse = "";
                        String Operation = "Reservation";
                        if (elt.structureMedical != null)
                        {
                            Nom = elt.structureMedical.nom;
                            Contact = elt.structureMedical.contact;
                            Adresse = elt.structureMedical.adresse;
                        }

                        String Disponibilite = "";
                        if (elt.doses_Vaccin_Disponibles == "DISPO")
                        {
                            Disponibilite = "VACCINATION";
                        }

                        if (elt.tests_Disponibles == "DISPO")
                        {
                            Disponibilite = Disponibilite + "TEST";
                        }
                        MaDataGridView.Rows.Add(Id,Nom, Contact, Adresse, Disponibilite,Operation);
                    }
                }
                else
                {
                    // Gère les erreurs de la requête API (par exemple, affiche un message d'erreur)
                    MessageBox.Show("Erreur lors de la récupération des données depuis l'API.");
                    
                }
            }
        }

        private void MaDataGridView_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == MaDataGridView.Columns["Operation"].Index && e.RowIndex >= 0)
            {
                String typeRV = MaDataGridView.Rows[e.RowIndex].Cells["Disponibilite"].Value.ToString();
                String Id = MaDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                ReservationForm reservationForm = new ReservationForm(Id,typeRV);
                reservationForm.ShowDialog();
            }

        }
    }
}