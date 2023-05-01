using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agrokultura.Models;

public partial class Chore
{

    
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double? Duration { get; set; }

    public virtual ICollection<ChorePerson> ChorePeople { get; set; } = new List<ChorePerson>();
}
