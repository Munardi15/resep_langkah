namespace resep_langkah.Models
{
    public class Parameter
    {
        public int Id { get; set; }
        public int LangkahId { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string TipeData { get; set; } = string.Empty;
        public string Nilai { get; set; } = string.Empty;
    }
}
