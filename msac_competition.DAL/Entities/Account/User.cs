using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
