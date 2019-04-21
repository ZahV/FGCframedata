using System.ComponentModel.DataAnnotations;

namespace FGCFrameData.Models
{
    public class Move
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Input { get; set; }

        public Character Character { get; set; }

        [Required]
        [Display(Name = "Select a character")]
        public int CharacterId { get; set; }

        [Required]
        [Display(Name = "Startup Frames")]
        public int StartupFrames { get; set; }

        [Required]
        [Display(Name = "Active Frames")]
        public int ActiveFrames { get; set; }

        [Required]
        [Display(Name = "Recovery Frames")]
        public int? RecoveryFrames { get; set; }

        [Display(Name = "Frame Adv. on Block")]
        public int? FrameAdvantage { get; set; }

        public bool Beats(Move other)
        {
            return StartupFrames <= other.FrameAdvantage;
        }
    }
}