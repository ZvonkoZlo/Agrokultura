using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class OrderStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ChorePerson> ChorePeople { get; set; } = new List<ChorePerson>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
