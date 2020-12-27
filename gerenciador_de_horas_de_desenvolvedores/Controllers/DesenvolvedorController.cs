using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gerenciador_de_horas_de_desenvolvedores.Domain;
using System.Threading.Tasks;

namespace gerenciador_de_horas_de_desenvolvedores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly ILogger<LubyTestDB> logger;
        private DesenvolvedorCRUD devCrud;

        public DesenvolvedorController(
            ILogger<LubyTestDB> _logger,
            LubyTestDB context)
        {
            logger = _logger;
            devCrud = new DesenvolvedorCRUD(context);
        }

        [HttpGet]
        public async Task<ActionResult<ITable[]>> Get()
        {
            return await devCrud.GetAll();
        }
        
        [HttpPost("GetOne")]
        public async Task<ActionResult<ITable>> One(DesenvolvedorTable ety)
        {
            return await devCrud.GetOne(ety);
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Insert(desenvolvedor);
            if (res is true)
                return Ok($"o Dev {desenvolvedor.Nome} foi cadastrado com sucesso");
            
            return BadRequest($"o Dev {desenvolvedor.Nome} já foi cadastrado");
        }
        
        [HttpPut]
        public async Task<ActionResult<string>> Put(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Update(desenvolvedor);
            if (res is true)
                return Ok($"o Dev {desenvolvedor.Nome} foi Alterado com sucesso");
            
            return BadRequest($"o Dev {desenvolvedor.Nome} não foi cadastrado");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Delete(desenvolvedor);
            if (res is true)
                return Ok($"o Dev {desenvolvedor.Nome} foi apagado com sucesso");
            
            return BadRequest($"o Dev {desenvolvedor.Nome} não foi cadastrado");

        }
    }
}
