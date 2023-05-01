using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class ChorePerson
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int OrderStatusId { get; set; }

    public int ChoreId { get; set; }

    public int PersonId { get; set; }

    public virtual Chore Chore { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
