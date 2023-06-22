using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class Terrain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;


    public virtual ICollection<Plot> Plots { get; set; } = new List<Plot>();
}
