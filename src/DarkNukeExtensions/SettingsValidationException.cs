using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkNukeExtensions
{
    public class SettingsValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; }

        public SettingsValidationException(List<ValidationFailure> errors) : base(string.Join(", ", errors.Select(a => a.ErrorMessage)))
        {
            Errors = errors;
        }
    }
}
