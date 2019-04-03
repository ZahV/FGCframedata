using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FGCFrameData.Models
{
    public class Move
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

        public bool Beats(Move other)
        {
            return this.StartupFrames <= other.FrameAdvantage;
        }
    }
}