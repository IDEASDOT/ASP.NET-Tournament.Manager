using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Identity;

namespace Domain
{
    public class Player
    {
        //Information about player
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "FirstNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "FirstNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.FirstName), ResourceType = typeof(Resources.Domain))]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "NickNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "NickNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.NickName), ResourceType = typeof(Resources.Domain))]
        public string NickName { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "LastNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "LastNameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.LastName), ResourceType = typeof(Resources.Domain))]
        public string LastName { get; set; }

        //Favourite Map of Player + FK
        [Display(Name = nameof(Resources.Domain.FavouriteMap), ResourceType = typeof(Resources.Domain))]
        public int MapId { get; set; } //favourite map id. /FK to mapid
        [Display(Name = nameof(Resources.Domain.FavouriteMap), ResourceType = typeof(Resources.Domain))]
        public virtual Map FavouriteMap { get; set; }

        //Information about win/lose rate
        [Display(Name = nameof(Resources.Domain.AllTimeWins), ResourceType = typeof(Resources.Domain))]
        public int? AllTimeWins { get; set; }
        [Display(Name = nameof(Resources.Domain.CurrentWins), ResourceType = typeof(Resources.Domain))]
        public int? CurrentWins { get; set; }
        [Display(Name = nameof(Resources.Domain.AllTimeLost), ResourceType = typeof(Resources.Domain))]
        public int? AllTimeLost { get; set; }
        [Display(Name = nameof(Resources.Domain.CurrentLost), ResourceType = typeof(Resources.Domain))]
        public int? CurrentLost { get; set; }

        //Information about computer and game specifications
        [Display(Name = nameof(Resources.Domain.ComputerSpecifications), ResourceType = typeof(Resources.Domain))]
        public virtual List<ComputerSpecification> ComputerSpecifications { get; set; } = new List<ComputerSpecification>();
        [Display(Name = nameof(Resources.Domain.GameSpecifications), ResourceType = typeof(Resources.Domain))]
        public virtual List<GameSpecification> GameSpecifications { get; set; } = new List<GameSpecification>();

        //Info about team (one player - one team)

        [Display(Name = nameof(Resources.Domain.Team), ResourceType = typeof(Resources.Domain))]
        public int TeamId { get; set; }
        [Display(Name = nameof(Resources.Domain.Team), ResourceType = typeof(Resources.Domain))]
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }

        #region NotMapped
        [Display(Name = nameof(Resources.Domain.FullName), ResourceType = typeof(Resources.Domain))]
        public string FullName => FirstName + " '" + NickName + "' " + LastName;
        [Display(Name = nameof(Resources.Domain.FirstLastName), ResourceType = typeof(Resources.Domain))]
        public string FirstLastName => FirstName + " " + LastName;
        [Display(Name = nameof(Resources.Domain.LastFirstName), ResourceType = typeof(Resources.Domain))]
        public string LastFirstName => LastName + " " + FirstName;

        [Display(Name = nameof(Resources.Domain.CurrentWinLose), ResourceType = typeof(Resources.Domain))]
        public string CurrentWinLose => "W:" + CurrentWins + "/L:" + CurrentLost;
        [Display(Name = nameof(Resources.Domain.AllTimeWinLose), ResourceType = typeof(Resources.Domain))]
        public string AllTimeWinLose => "W:" + AllTimeWins + "/L:" + AllTimeLost;

        #endregion
    }
}
