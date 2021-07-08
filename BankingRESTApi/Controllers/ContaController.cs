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
    public class ContaController : ControllerBase
    {
        private readonly ILogger<ContaController> _logger;
        private IContaBusiness _contaBusiness;

        public ContaController(ILogger<ContaController> logger, IContaBusiness contaBusiness)
        {
            _logger = logger;
            _contaBusiness = contaBusiness;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(List<ContaVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_contaBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ContaVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var conta = _contaBusiness.FindByID(id);
            if (conta == null)
                return NotFound();
            return Ok(conta);
        }

        [HttpGet("Depositar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Depositar([FromQuery] int agencia, [FromQuery] int numero, [FromQuery] decimal valor)
        {
            if (valor <= 0)
                return NotFound("O valor a ser depositado deve ser maior do que zero!");

            var conta = _contaBusiness.Depositar(agencia, numero, valor);
            if (conta == null)
                return NotFound();
            return Ok(conta);
        }

        [HttpGet("Sacar")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] int agencia, [FromQuery] int numero, [FromQuery] decimal valor)
        {
            if (valor <= 0)
                return NotFound("O valor a ser sacado deve ser maior do que zero!");

            var conta = _contaBusiness.Sacar(agencia, numero, valor);
            if (conta == null)
                return NotFound();
            return Ok(conta);
        }

        [HttpGet("Transferir")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] int agenciaOrigem, 
                                 [FromQuery] int numeroOrigem,
                                 [FromQuery] int agenciaDestino,
                                 [FromQuery] int numeroDestino,
                                 [FromQuery] decimal valor)
        {
            if (valor <= 0)
                return NotFound("O valor a ser transferido deve ser maior do que zero!");

            var contas = _contaBusiness.Transferir(agenciaOrigem, numeroOrigem,
                                                  agenciaDestino, numeroDestino, valor);
            if (contas == null)
                return NotFound();
            return Ok(contas);
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(ContaVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] ContaVO conta)
        {
            if (conta == null)
                return BadRequest();
            return Ok(_contaBusiness.Create(conta));
        }

        [HttpPut()]
        [ProducesResponseType(200, Type = typeof(ContaVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] ContaVO conta)
        {
            if (conta == null)
                return BadRequest();
            return Ok(_contaBusiness.Update(conta));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _contaBusiness.Delete(id);
            return NoContent();
        }
    }
}
