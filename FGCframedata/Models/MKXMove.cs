using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FGCframedata.Models
{
    public class MkxMove : Move
    {
        public override bool Beats(Move other)
        {
            if (!(other is MkxMove))
            {
                return false;
            }

            return this.StartupFrames <= other.FrameAdvantage;
        }
    }
}