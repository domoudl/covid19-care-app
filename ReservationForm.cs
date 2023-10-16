using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using covid19_care_app.Models;
using Json.Net;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace covid19_care_app
{
    public partial class ReservationForm : Form
    {
        private String idStructure;
        private String typeRV;
        private HttpClient httpClient;
        public ReservationForm(String idStructure, String typeRV)
        {
            InitializeComponent();
            this.typeRV = typeRV;
            this.idStructure = idStructure;
            List<String> listRV = new List<string> { };
            listRV.Add(this.typeRV);
            typeRvComboBox.DataSource = listRV;
            httpClient = new HttpClient();
        }
        
        private async Task<bool> EnregistrerRendezVousAsync(RendezVous rendezVous)
        {
            try
            {
                // Utiliser l'URL de l'API
                string apiUrl = "http://localhost:8888/RendezVous";

                // Convertir le formulaire RendezVous en JSON
                string jsonData = JsonSerializer.Serialize(rendezVous);

                // Créer un contenu JSON
                var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Envoyer une requête POST asynchrone à l'API
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, jsonContent);

                // Assurer que la réponse est un succès
                response.EnsureSuccessStatusCode();

                return true; // Rendez-vous enregistré avec succès
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
                return false; // Erreur lors de l'enregistrement du rendez-vous
            }
        }


        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            string nom = lastNameTextBox.Text;
            string prenom = firstNameTextBox.Text;
            string numeroTelephone = phoneTextBox.Text;
            string adresse = addressTextBox.Text;
            string type = (string)typeRvComboBox.SelectedItem;
            
            RendezVous rendezVous = new RendezVous
            {
                lieuMedical = new StructureSante { id = Convert.ToInt32(idStructure) }, // ID de la structure médicale
                patient = new Patient
                {
                    nom = nom,
                    prenom = prenom,
                    numeroTelephone = numeroTelephone,
                    adresse = adresse
                },
                type = type
            };
            
            bool success = await EnregistrerRendezVousAsync(rendezVous);
            
            if (success)
            {
                MessageBox.Show("Rendez-vous enregistré avec succès !");
                Close();
            }

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}