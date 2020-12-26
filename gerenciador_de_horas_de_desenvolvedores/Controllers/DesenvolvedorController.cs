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
        public async Task<ITable[]> Get()
        {
            return await devCrud.GetAll();
        }
        
        [HttpPost("GetOne")]
        public async Task<ITable> One(ITable ety)
        {
            return await devCrud.GetOne(ety);
        }
        [HttpPost]
        public async Task<string> Post(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Insert(desenvolvedor);
            if (res is true)
                return $"o Dev {desenvolvedor.Nome} foi cadastrado com sucesso";
            
            return $"o Dev {desenvolvedor.Nome} já foi cadastrado";
        }
        
        [HttpPut]
        public async Task<string> Put(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Update(desenvolvedor);
            if (res is true)
                return $"o Dev {desenvolvedor.Nome} foi alterado com sucesso";

            return $"o Dev {desenvolvedor.Nome} não consta no sistema";
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Delete(desenvolvedor);
            if (res is true)
                return $"Apagado com Sucesso";

            return $"Não Encontrado";

        }
    }
}
