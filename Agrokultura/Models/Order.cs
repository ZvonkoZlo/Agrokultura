using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class Order
{
    public int Id { get; set; }

    public double? AmountOfGoods { get; set; }

    public int CustomerId { get; set; }

    public int PlantId { get; set; }

    public int OrderStatusId { get; set; }

    public virtual Person Customer { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual Plant Plant { get; set; } = null!;
}
