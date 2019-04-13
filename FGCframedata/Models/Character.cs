using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FGCFrameData.Models
{
    public class Character
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public CharacterRoster CharacterRoster { get; set; }

        [Display(Name = "Game")]
        public int CharacterRosterId { get; set; }

        private IEnumerable<Move> Moves { get; set; }

        public string ImagePath { get; set; }
    }
}