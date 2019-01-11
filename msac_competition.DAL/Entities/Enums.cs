using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace msac_competition.DAL.Entities
{
    public enum CompetitionStatus
    {
        Edit,
        Finished
    }

    public enum Rank
    {
        [Display(Name = "Міські")]
        City,
        [Display(Name = "Районі")]
        Region,
        [Display(Name = "Національні")]
        Country,
        [Display(Name = "Міжнародні")]
        World
    }

    public enum SportRank
    {
        [Display(Name = "КМСУ")]
        Kmsu,
        [Display(Name = "МСУ")]
        Msu,
        [Display(Name = "МСУМК")]
        Msumk,
        [Display(Name = "ЗМСУ")]
        Zmsu
    }

    public enum Sex
    {
        [Display(Name = "чол.")]
        Man,
        [Display(Name = "жін.")]
        Woman
    }

}
