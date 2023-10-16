namespace covid19_care_app.Models
{
    public class RendezVous
    {
        public StructureSante lieuMedical { get; set; }
        public Patient patient { get; set; }
        public string type { get; set; }
    }
}