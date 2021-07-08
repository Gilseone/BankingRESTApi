using BankingRESTApi.Business;
using BankingRESTApi.Data.VO;
using BankingRESTApi.Hypermedia.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BankingRESTApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private IClienteBusiness _clienteBusiness;

        public ClienteController(ILogger<ClienteController> logger, IClienteBusiness clienteBusiness)
        {
            _logger = logger;
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(List<ClienteVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_clienteBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ClienteVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var cliente = _clienteBusiness.FindByID(id);
            if (cliente == null)
                return NotFound();
            return Ok(cliente);
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(ClienteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] ClienteVO cliente)
        {
            if (cliente == null)
                return BadRequest();
            return Ok(_clienteBusiness.Create(cliente));
        }

        [HttpPut()]
        [ProducesResponseType(200, Type = typeof(ClienteVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] ClienteVO cliente)
        {
            if (cliente == null)
                return BadRequest();
            return Ok(_clienteBusiness.Update(cliente));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(200, Type = typeof(ClienteVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(long id)
        {
            var cliente = _clienteBusiness.Disable(id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _clienteBusiness.Delete(id);
            return NoContent();
        }
    }
}
