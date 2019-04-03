using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FGCFrameData.Models
{
    public class MkxCharacter: Character
    {
        private Dictionary<MkxVariation, IEnumerable<Move>> AllMoves { get; set; }

        public MkxVariation CharacterVariation { get; set; }

        public override IEnumerable<Move> GetMove(string name)
        {
            return AllMoves[CharacterVariation].Where(m => m.Name == name);
        }
    }
}