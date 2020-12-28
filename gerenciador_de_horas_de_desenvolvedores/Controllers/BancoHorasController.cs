using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gerenciador_de_horas_de_desenvolvedores.Domain;
using System.Threading.Tasks;

namespace gerenciador_de_horas_de_desenvolvedores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BancoHorasController : ControllerBase
    {
        private readonly ILogger<LubyTestDB> logger;
        private BancoHorasCRUD bancoCRUD;
        private HorasAcomuladasDevCRUD horasCrud;

        public BancoHorasController(ILogger<LubyTestDB> log, LubyTestDB ctx)
        {
            logger = log;
            bancoCRUD = new BancoHorasCRUD(ctx);
            horasCrud = new HorasAcomuladasDevCRUD(ctx);
        }
        [HttpGet]
        public async Task<ActionResult<ITable[]>> Get()
        {
            try
            {
                var all = await bancoCRUD.GetAll();
                return Ok(all);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPost("GetOne")]
        public async Task<ActionResult<ITable>> One(BancoHorasTable ety)
        {
            try
            {
                var all = await bancoCRUD.GetOne(ety);
                return Ok(all);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPost]
        public async Task<bool> Post(BancoHorasTable horas)
        {
            var res = await bancoCRUD.Insert(horas);
            var res2 = await horasCrud.Insert(horas);

            if (res is true && res2 is true)
                return true;

            return false;

        }

        [HttpPut]
        public async Task<bool> Put(BancoHorasTable horas)
        {
            var res = await bancoCRUD.Update(horas);
            if (res is true)
                return true;

            return false;
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await bancoCRUD.Delete(id);
            if (res is true)
                return true;;

            return false;
        }
    }
}
