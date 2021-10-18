using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record Organisation
    {
        [Required]
        public Address Address { get; set; }

        [Required]
        [MaxLength(120)]
        [MinLength(1)]
        public string Name { get; set; }

    }
}