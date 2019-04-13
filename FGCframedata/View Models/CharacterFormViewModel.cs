using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FGCFrameData.Models;

namespace FGCFrameData.View_Models
{
    public class CharacterFormViewModel
    {
        public Character Character { get; set; }
        public IEnumerable<CharacterRoster> CharacterRoster { get; set; }
    }
}