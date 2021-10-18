using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Registrations.Entities
{
    public record FieldError
    {
        [ReadOnly(true)]
        public string Code { get; set; }

        [ReadOnly(true)]
        public string Field { get; set; }

        [ReadOnly(true)]
        public string Message { get; set; }

        public static implicit operator List<object>(FieldError v)
        {
            throw new NotImplementedException();
        }
    }
}