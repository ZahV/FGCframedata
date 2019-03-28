using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FGCframedata.Models
{
    public abstract class Move
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Input { get; set; }

        public int StartupFrames { get; set; }
        public int ActiveFrames { get; set; }
        public int? RecoveryFrames { get; set; }
        public int? FrameAdvantage { get; set; }

        public abstract bool Beats(Move other);
    }
}