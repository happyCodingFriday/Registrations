using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Person
    {
        public Address Address { get; set; }

        [Required]
        [StringLength(254, MinimumLength = 1)]
        public string Email { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string LastName { get; set; }
    }
}