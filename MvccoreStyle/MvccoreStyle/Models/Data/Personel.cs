using System;
using System.Collections.Generic;

namespace MvccoreStyle.Models.Data
{
    public partial class Personel
    {
        public int PersonelId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public int SehirId { get; set; }

        public virtual Sehir Sehir { get; set; } = null!;
    }
}
