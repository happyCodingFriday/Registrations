using System;
using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Address
    {
        [Required]
        [MaxLength(150)]
        [MinLength(1)]
        public string AddressLine1 { get; set; }

        [MaxLength(150)]
        public string AddressLine2 { get; init; }
        [MaxLength(150)]
        public string AddressLine3 { get; init; }

        [MaxLength(40)]
        public string City { get; init; }

        [Required]
        [MinLength(1)]
        public string CountryIsoCode { get; init; }

        public string Locale { get; init; }

        [MaxLength(60)]
        public string Postcode { get; init; }

        [MaxLength(60)]
        public string State { get; init; }

    }
}