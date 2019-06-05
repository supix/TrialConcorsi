using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Commands;
using DomainModel.CQRS.Commands.SalvaDomanda;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalvaDomandaController : ControllerBase
    {
        private readonly ICommandHandler<SalvaDomandaCommand> handler;

        public SalvaDomandaController(ICommandHandler<SalvaDomandaCommand> handler)
        {
            this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }


        // POST: api/SalvaDomanda
        [HttpPost]
        public ActionResult Post([FromBody] SalvaDomandaCommand command)
        {
            this.handler.Handle(command);

            return Created("domande/" + command.Id, command);
        }
    }
}
