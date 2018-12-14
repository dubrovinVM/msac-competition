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
        City,
        Region,
        Country,
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
        man,
        [Display(Name = "жін.")]
        woman
    }

}
