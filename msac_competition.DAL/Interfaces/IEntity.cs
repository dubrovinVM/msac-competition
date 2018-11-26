using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace msac_competition.DAL.Interfaces
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
