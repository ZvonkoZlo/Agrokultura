using System;
using System.Collections.Generic;

namespace Agrokultura.Models
{
    public partial class PlantPassport
    {
        public int Id { get; set; }

        public string? CountryOfOrigin { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string? IssuingAuthority { get; set; }

        public string? CertificateNumber { get; set; }

        public string? Description { get; set; }
        
    }

}
