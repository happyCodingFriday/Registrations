using System;
using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Registration
    {
        public Guid RegistrationId { get; init; }

        [Required]
        public string Locale { get; set; }

        public Organisation Organisation { get; set; }

        public Person Person { get; set; }

        public DateTimeOffset CreatedDate { get; init; }

    }
}