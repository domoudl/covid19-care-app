namespace covid19_care_app.Models
{
    public class StructureSante
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string contact { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int type { get; set; }
    }
}