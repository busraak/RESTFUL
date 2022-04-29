using System;
using System.Collections.Generic;

namespace ApiStyle.Data
{
    public partial class City
    {
        public City()
        {
            Personels = new HashSet<Personel>();
        }

        public int CityId { get; set; }
        public string? CityName { get; set; }

        public virtual ICollection<Personel> Personels { get; set; }
    }
}
