using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using msac_competition.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace msac_competition.Models
{
    public class CoachEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Firstname", ResourceType = typeof(@Resources.TableHeads))]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Surname", ResourceType = typeof(@Resources.TableHeads))]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Lastname", ResourceType = typeof(@Resources.TableHeads))]
        public string Lastname { get; set; }
        [Display(Name = "Photo", ResourceType = typeof(@Resources.TableHeads))]
        public string Avatar { get; set; }
        [Display(Name = "Sex", ResourceType = typeof(@Resources.TableHeads))]
        public Sex Sex { get; set; }

        [Display(Name = "Birthday", ResourceType = typeof(@Resources.TableHeads))]
        public DateTime? DaTeOfBirth { get; set; }
        [Display(Name = "Sportrank", ResourceType = typeof(@Resources.TableHeads))]
        public SportRank? SportRank { get; set; }

        public int? TeamId { get; set; }
        [Display(Name = "Team", ResourceType = typeof(@Resources.TableHeads))]
        public TeamViewModel Team { get; set; }

        public int? CityId { get; set; }
        [Display(Name = "City", ResourceType = typeof(@Resources.TableHeads))]
        public CityViewModel City { get; set; }

        public List<SportmanViewModel> Sportmen { get; set; }

        public CoachEditViewModel()
        {
            Sportmen = new List<SportmanViewModel>();
        }

        [Display(Name = "Team", ResourceType = typeof(@Resources.TableHeads))]
        public string SelectedTeam { get; set; }
        public IEnumerable<SelectListItem> Teams { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
