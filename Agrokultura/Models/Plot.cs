using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class Plot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Coordinates { get; set; }

    public string? Longitudes { get; set; }

    public string? Corners { get; set; }

    public int? GroundId { get; set; }

    public int? TerrainId { get; set; }

    public int? OwnerId { get; set; }

    public virtual ICollection<ContractPlot> ContractPlots { get; set; } = new List<ContractPlot>();

    public virtual Ground? Ground { get; set; }

    public virtual ICollection<IncomeAndExpense> IncomeAndExpenses { get; set; } = new List<IncomeAndExpense>();

    public virtual Person? Owner { get; set; }

    public virtual Terrain? Terrain { get; set; }
}
