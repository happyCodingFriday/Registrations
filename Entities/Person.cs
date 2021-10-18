using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Person
    {
        public Address Address { get; set; }

        [Required]
        [MaxLength(254)]
        [MinLength(1)]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        [MinLength(1)]
        public string LastName { get; set; }
    }
}