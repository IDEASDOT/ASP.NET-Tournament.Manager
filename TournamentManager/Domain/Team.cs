using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Team
    {
        //Primary key for teamID
        public int TeamId { get; set; }
        //Name for the team
        [Required]
        [MaxLength(64, ErrorMessageResourceName = "TeamNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "TeamNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.TeamName), ResourceType = typeof(Resources.Domain))]
        public string TeamName { get; set; }

        [Required]
        [MaxLength(10, ErrorMessageResourceName = "TeamAbbrevationLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "TeamAbbrevationLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.TeamAbbrevation), ResourceType = typeof(Resources.Domain))]
        public string TeamAbbreviation { get; set; }
   
        //List of players in this specific team
        public virtual List<Player> Players { get; set; } = new List<Player>();
    }
}
