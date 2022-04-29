using System;
using System.Collections.Generic;

namespace ApiStyle.Data
{
    public partial class Personel
    {
        public int PersonelId { get; set; }
        public int CityId { get; set; }
        public string? PersonelName { get; set; }
        public string? PersonelSurname { get; set; }

        public virtual City? City { get; set; } = null!;
    }
}
