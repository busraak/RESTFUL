using System.ComponentModel.DataAnnotations;

namespace NufusKontrol.Data.Classes
{
    public class People
    {
        [Key]
        public string? TC  { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime Birthday { get; set; }

    }
}
