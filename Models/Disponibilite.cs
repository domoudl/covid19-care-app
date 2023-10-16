namespace covid19_care_app.Models
{
    public class Disponibilite
    {
        public int id { get; set; }
        public StructureSante structureMedical { get; set; }
        public string dateDisponibilite { get; set; }
        public string doses_Vaccin_Disponibles { get; set; }
        public string tests_Disponibles { get; set; }
    }
}