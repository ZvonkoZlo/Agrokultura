﻿using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class GoodsType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public int Quantity { get; set; }
    public string MeasurementUnit { get; set; }

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}
