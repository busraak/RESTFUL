using System;
using System.Collections.Generic;

namespace MvccoreStyle.Models.Data
{
    public partial class Sehir
    {
        public Sehir()
        {
            Personels = new HashSet<Personel>();
        }

        public int SehirId { get; set; }
        public string? SehirAd { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
