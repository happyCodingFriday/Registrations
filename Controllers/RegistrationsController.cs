using Microsoft.AspNetCore.Mvc;
using Registrations.Entities;
using Registrations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Registrations.Controllers
{
    //GET /api/v1
    [ApiController]
    [Route("/api/v1/registrations")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationsRepository repository;

        public RegistrationsController(IRegistrationsRepository repository)
        {
            this.repository = repository;
        }        

        // GET /registrations/{id}
        [HttpGet("{registrationId}")]
        public ActionResult<Registration> GetRegistration(Guid registrationId)
        {
            var registration = repository.GetRegistration(registrationId);

            if (registration is null)
            {
                return NotFound();
            }

            return registration;
        }       

        // POST /registrations
        [HttpPost]
        //[ProducesResponseType(typeof(RegistrationResponse), 201)]
        //[ProducesResponseType(typeof(ErrorResponse), 400)]
        public ActionResult<Registration> CreateRegistration(Registration registration)
        {
            Registration newRegistration = new()
            {
                RegistrationId = Guid.NewGuid(),

                Locale = registration.Locale,

                Organisation = registration.Organisation,

                Person = registration.Person,

                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateRegistration(newRegistration);

            //RegistrationResponse registrationResponse = new RegistrationResponse(newRegistration.RegistrationId);

            CreatedAtActionResult createdAtActionResult = CreatedAtAction(nameof(GetRegistration), new { registrationId = newRegistration.RegistrationId }, newRegistration);            

            return createdAtActionResult;

        }

        
    }
}