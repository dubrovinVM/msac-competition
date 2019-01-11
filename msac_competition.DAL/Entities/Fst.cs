 using System;
using System.Collections.Generic;
 using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;
 using System.Text;
 using msac_competition.DAL.Interfaces;

namespace msac_competition.DAL.Entities
{
    public class Fst:IEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Team> Teams { get; set; }

        public Fst()
        {
            Teams = new List<Team>();
        }
    }
}
