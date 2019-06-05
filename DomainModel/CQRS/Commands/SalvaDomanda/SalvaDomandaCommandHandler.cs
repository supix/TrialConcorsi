using CQRS.Commands;
using DomainModel.CQRS.Services;
using DomainModel.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.SalvaDomanda
{
    public class SalvaDomandaCommandHandler : ICommandHandler<SalvaDomandaCommand>
    {
        private readonly ISalvaDomanda salvaDomanda;

        public SalvaDomandaCommandHandler(ISalvaDomanda salvaDomanda)
        {
            this.salvaDomanda = salvaDomanda ?? throw new ArgumentNullException(nameof(salvaDomanda));
        }

        public void Handle(SalvaDomandaCommand command)
        {
            //Mapping da DTO a classe di dominio
            var domanda = new Domanda()
            {
                CodiceFiscale = command.CodiceFiscale,
                GiorniDiServizio = command.GiorniDiServizio,
                DataSalvataggio = DateTime.UtcNow
            };

            this.salvaDomanda.Save(domanda);

            command.Id = domanda.Id;
        }
    }
}
