using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.SalvaDomanda
{
    public class SalvaDomandaCommand
    {
        public string Id { get; set; }
        public string CodiceFiscale { get; set; }
        public int GiorniDiServizio { get; set; }
    }
}
