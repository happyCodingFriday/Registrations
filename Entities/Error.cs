using System.ComponentModel;

namespace Registrations.Entities
{
    public record Error
    {
        [ReadOnly(true)]
        public string Code { get; private set; }

        [ReadOnly(true)]
        public string Message { get; private set; }
    }
}