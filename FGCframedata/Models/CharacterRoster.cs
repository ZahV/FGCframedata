using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FGCframedata.Models
{
    public class CharacterRoster
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Game Title")]
        public string GameName { get; set; }


        public string ImagePath { get; set; }

        public List<Character> Characters { get; set; }
    }
}