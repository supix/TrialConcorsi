using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.SalvaDomanda
{
    public class GiorniDiServizioNonPossonoEssereNegativiValidator : ICommandValidator<SalvaDomandaCommand>
    {
        public IEnumerable<ValidationResult> Validate(SalvaDomandaCommand command)
        {
            // Here the validation
            // In case of failure you must return a ValidationResult
            if (command.GiorniDiServizio < 0)
                yield return new ValidationResult("I giorni di servizio non possono essere negativi");
        }
    }
}
