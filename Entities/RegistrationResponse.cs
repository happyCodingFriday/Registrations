using System;
using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record RegistrationResponse
    {
        public RegistrationResponse(Guid registrationId)
        {
            RegistrationId = registrationId;
        }

        public Guid RegistrationId { get; set; }        

    }
}