using System.Text.Json.Serialization;

namespace resep_langkah.Models
{
    public class Langkah
    {
        public int Id { get; set; }
        public int ResepId { get; set; }
        public string Judul { get; set; } = string.Empty;
        public int? ParentLangkahId { get; set; }
        public int Urutan { get; set; }

        [JsonIgnore]
        public Resep? Resep { get; set; }

        [JsonIgnore]
        public Langkah? ParentLangkah { get; set; }
        public ICollection<Langkah> SubLangkahs { get; set; } = new List<Langkah>();
        public ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
    }
}
