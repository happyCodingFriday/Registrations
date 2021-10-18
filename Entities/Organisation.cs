using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Organisation
    {
        [Required]
        public Address Address { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string Name { get; set; }

    }
}