using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registrations.Entities
{
    public record ErrorResponse
    {
        public Error Error { get; set; }

        public List<FieldError> FieldErrors { get; set; }

        public ErrorResponse (Error error, List<FieldError> fieldErrors)
        {
            Error = error;
            FieldErrors = fieldErrors;
        }

    }
}