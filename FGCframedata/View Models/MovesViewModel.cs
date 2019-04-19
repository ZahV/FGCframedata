using FGCFrameData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FGCFrameData.View_Models
{
    public class MovesViewModel
    {
        public IEnumerable<Move> Moves { get; set; }
        public string CharacterName { get; set; }

        public MovesViewModel(IEnumerable<Move> moves, string characterName)
        {
            Moves = moves;
            CharacterName = characterName;
        }
    }
}