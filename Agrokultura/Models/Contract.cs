using System;
using System.Collections.Generic;

namespace Agrokultura.Models;

public partial class Contract
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProviderId { get; set; }

    public int BeneficiaryId { get; set; }

    public string DateOfConclusion { get; set; } = null!;

    public string DateOfExpiration { get; set; } = null!;

    public virtual Person Beneficiary { get; set; } = null!;

    public virtual ICollection<ContractPlot> ContractPlots { get; set; } = new List<ContractPlot>();

    public virtual Person Provider { get; set; } = null!;
}
