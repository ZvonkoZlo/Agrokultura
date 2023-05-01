using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class PlantType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}
