using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class IncomeAndExpense
{
    public int Id { get; set; }

    public int? PlotId { get; set; }

    public int? PlantId { get; set; }

    public double? AmountOfPlants { get; set; }

    public double? Price { get; set; }

    public string? DateOfPlanting { get; set; }

    public string? EndDateOfPlanting { get; set; }

    public double? AmountOfGoods { get; set; }

    public virtual Plant? Plant { get; set; }

    public virtual Plot? Plot { get; set; }
}
