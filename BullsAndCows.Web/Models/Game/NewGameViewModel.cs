using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Web.Models.Game
{
    public class NewGameViewModel
    {
        public NewGameViewModel()
        {

        }

        [Required]
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Your number must contain only 4 digits.")]
        public string Number { get; set; }
    }
}