using System;
using Registrations.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Registrations.Repositories
{
    public class InMemItemsRepository : IRegistrationsRepository
    {

        private readonly List<Registration> registrations = new()
        {
            new Registration { RegistrationId = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow }
        };

        public Registration GetRegistration(Guid registrationId)
        {
            return registrations.Where(Registration => Registration.RegistrationId == registrationId).SingleOrDefault();
        }

        public void CreateRegistration(Registration registration)
        {
            registrations.Add(registration);
        }

    }
}