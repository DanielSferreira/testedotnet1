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
        public async Task<bool> Post(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Insert(desenvolvedor);
            if (res is true)
                return true;

            return false;
        }

        [HttpPut]
        public async Task<bool> Put(DesenvolvedorTable desenvolvedor)
        {
            var res = await devCrud.Update(desenvolvedor);
            if (res is true)
                return true;

            return false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await devCrud.Delete(id);
            if (res is true)
                return true;

            return false;

        }
    }
}
