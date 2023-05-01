using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class Person
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public string Adress { get; set; } = null!;

    public int? CityId { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<ChorePerson> ChorePeople { get; set; } = new List<ChorePerson>();

    public virtual City? City { get; set; }

    public virtual ICollection<Contract> ContractBeneficiaries { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractProviders { get; set; } = new List<Contract>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();

    public virtual ICollection<Plot> Plots { get; set; } = new List<Plot>();

    public virtual Role? Role { get; set; }
}
