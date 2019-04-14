using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FGCFrameData.Models;

namespace FGCFrameData.View_Models
{
    public class MoveFormViewModel
    {
        public Move Move { get; set; }
        public IEnumerable<Character> Character { get; set; }
    }
}