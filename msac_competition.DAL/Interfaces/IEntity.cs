using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace msac_competition.DAL.Interfaces
{
    public interface IEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}
