using System.Threading.Tasks;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using gerenciador_de_horas_de_desenvolvedores.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gerenciador_de_horas_de_desenvolvedores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ILogger<LubyTestDB> logger;
        private ProjetoCRUD ProCrud;

        public ProjetosController(
            ILogger<LubyTestDB> _logger,
            LubyTestDB context)
        {
            logger = _logger;
            ProCrud = new ProjetoCRUD(context);
        }

        [HttpGet]
        public async Task<ActionResult<ITable[]>> Get()
        {
            try
            {
                var all = await ProCrud.GetAll();
                return Ok(all);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }
        
        [HttpGet("GetDevs")]
        public async Task<ActionResult<ITable[]>> GetDevs()
        {
            try
            {
                var all = await ProCrud.GetDevInProject();
                return Ok(all);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPost("GetOne")]
        public async Task<ActionResult<ITable>> One(ITable ety)
        {
            return await ProCrud.GetOne(ety);
        }

        [HttpPost]
        public async Task<bool> Post(ProjetoTable desenvolvedor)
        {
            var res = await ProCrud.Insert(desenvolvedor);
            if (res is true)
                return true;

            return false;
        }

        [HttpPut]
        public async Task<bool> Put(ProjetoTable desenvolvedor)
        {
            var res = await ProCrud.Update(desenvolvedor);
            if (res is true)
                return true;

            return false;
        }

        [HttpPut("PutDevs")]
        public async Task<bool> PutDevs(ProjetoTable desenvolvedor)
        {
            var res = await ProCrud.UpdateProjetos(desenvolvedor);
            if (res is true)
                return true;

            return false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await ProCrud.Delete(id);
            if (res is true)
                return true;

            return false;

        }
    }
}
