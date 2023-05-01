using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class Plant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? SubspeciesName { get; set; }

    public double? AmountOfGoods { get; set; }

    public double? Price { get; set; }

    public int? PlantTypeId { get; set; }

    public int? GoodsTypeId { get; set; }

    public int? ManufacturerId { get; set; }

    public virtual GoodsType? GoodsType { get; set; }

    public virtual ICollection<IncomeAndExpense> IncomeAndExpenses { get; set; } = new List<IncomeAndExpense>();

    public virtual Person? Manufacturer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual PlantType? PlantType { get; set; }
}
