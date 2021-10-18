using System;
using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Address
    {
        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; init; }

        public string AddressLine3 { get; init; }

        public string City { get; init; }

        public string CountryIsoCode { get; init; }

        public string Locale { get; init; }

        public string Postcode { get; init; }

        public string State { get; init; }

    }
}