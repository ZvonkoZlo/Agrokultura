using System;
using System.Collections.Generic;

namespace Agrokultura.Models
{
    public partial class ContractPlot
    {
        public int Id { get; set; }
        public int? ContractId { get; set; }
        public int? PlotId { get; set; }
        public decimal? MonthlyPayment { get; set; } 
        public decimal? Price { get; set; } 

        public virtual Contract? Contract { get; set; }
        public virtual Plot? Plot { get; set; }
    }
}
