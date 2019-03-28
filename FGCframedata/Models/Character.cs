using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FGCframedata.Models
{
    public abstract class Character
    {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    private IEnumerable<Move> Moves { get; set; }

    public abstract IEnumerable<Move> GetMove(string name);

    }
}