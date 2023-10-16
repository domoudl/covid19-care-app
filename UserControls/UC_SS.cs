using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using covid19_care_app.Models;
using System.Text.Json;

//using Json.Net;

namespace covid19_care_app.UserControls
{
    public partial class UC_SS : UserControl
    {
        
        public UC_SS()
        {
            InitializeComponent();
        }
        
        public async Task ChargerListeStructuresSanteDepuisAPI()
        {
            // Utilise HttpClient pour envoyer une requête GET à ton API
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "http://localhost:8888/LieuMedical";
                HttpResponseMessage response = await client.GetAsync(apiUrl);
        
                if (response.IsSuccessStatusCode)
                {
                   string responseBody = await response.Content.ReadAsStringAsync();
                    
                    // Désérialise les données JSON reçues depuis l'API en objets C#
                    List<StructureSante> structures = JsonSerializer.Deserialize<List<StructureSante>>(responseBody);
                    
                    // // Affiche les structures dans le contrôle approprié (par exemple, une ListBox ou un DataGridView)
                    MaListBox.DataSource = structures;
                    // // temp = structures[0].nom;
                    MaListBox.DisplayMember = "Nom"; // Affiche le nom des structures
                    //MaListBox.DisplayMember = "Contact";
                    
                }
                else
                {
                    // Gère les erreurs de la requête API (par exemple, affiche un message d'erreur)
                    MessageBox.Show("Erreur lors de la récupération des données depuis l'API.");
                    
                }
            }
        }
    }
}