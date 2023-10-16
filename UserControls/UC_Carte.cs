using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using covid19_care_app.Models;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace covid19_care_app.UserControls
{
    public partial class UC_Carte : UserControl
    {
        GMap.NET.WindowsForms.GMapControl gMap;
        private List<StructureSante> structures;
        public UC_Carte()
        {
            InitializeComponent();
            gMap = new GMap.NET.WindowsForms.GMapControl();
            gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMap.Dock = DockStyle.Fill;
            gMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.ShowCenter = false;
            gMap.MinZoom = 1;
            gMap.MaxZoom = 20;
            panelCarte.Controls.Add(gMap);
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
                    structures = JsonSerializer.Deserialize<List<StructureSante>>(responseBody);
                }
            }
        }

        public void GoToCoordinate()
        {
            List<PointLatLng> coordinatesList = new List<PointLatLng>{};
            List<String> namesList = new List<string> {};
            foreach (var elt in structures)
            {
                coordinatesList.Add(new PointLatLng(Convert.ToDouble(elt.latitude),Convert.ToDouble(elt.longitude)));
            }

            foreach (var elt in structures)
            {
                namesList.Add(elt.nom);
            }
            gMap.Position = coordinatesList[0];
            gMap.Zoom = 15;
            gMap.DragButton = MouseButtons.Left;

            var markerOverlay = new GMap.NET.WindowsForms.GMapOverlay("marker1");
            for (int i = 0;i<coordinatesList.Count;i++)
            {
                var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                    coordinatesList[i],GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_dot
                );
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = namesList[i];
                markerOverlay.Markers.Add(marker);
            }
            
            gMap.Overlays.Add(markerOverlay);
            gMap.Update();
            gMap.Refresh();
        }
    }
}