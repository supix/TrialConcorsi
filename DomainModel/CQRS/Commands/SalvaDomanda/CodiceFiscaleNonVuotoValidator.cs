using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.SalvaDomanda
{
    public class CodiceFiscaleNonVuotoValidator : ICommandValidator<SalvaDomandaCommand>
    {
        public IEnumerable<ValidationResult> Validate(SalvaDomandaCommand command)
        {
            // Here the validation
            // In case of failure you must return a ValidationResult
            if (string.IsNullOrWhiteSpace(command.CodiceFiscale))
                yield return new ValidationResult("Il codice fiscale non può essere vuoto");
        }
    }
}
