 using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using System.Text;

namespace msac_competition.DAL.Entities
{
    public class Fst
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Team> Teams { get; set; }

        public Fst()
        {
            Teams = new List<Team>();
        }
    }
}
