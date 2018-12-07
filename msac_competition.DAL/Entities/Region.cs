using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }

        public Region()
        {
            Cities = new List<City>();
        }
    }
}
