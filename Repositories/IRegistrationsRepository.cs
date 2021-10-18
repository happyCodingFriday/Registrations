using Registrations.Entities;
using System;
using System.Collections.Generic;

namespace Registrations.Repositories
{
    public interface IRegistrationsRepository
    {
        Registration GetRegistration(Guid id);        
        void CreateRegistration(Registration item);
        
    }
}