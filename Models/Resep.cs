namespace resep_langkah.Models
{
    public class Resep
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public ICollection<Langkah> Langkahs { get; set; } = new List<Langkah>();

    }
}
