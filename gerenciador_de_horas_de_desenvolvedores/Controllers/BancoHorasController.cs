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
        public async Task<ITable[]> Get()
        {
            return await bancoCRUD.GetAll();
        }
        [HttpPost("GetOne")]
        public async Task<ITable> One(BancoHorasTable ety)
        {
            return await bancoCRUD.GetOne(ety);
        }
        [HttpPost]
        public async Task<string> Post(BancoHorasTable horas)
        {
            var res = await bancoCRUD.Insert(horas);
            var res2 = await horasCrud.Insert(horas);

            if (res is true && res2 is true)
                return $"o Dev {horas.Desenvolvedor} foi cadastrado com sucesso";
            
            return $"o Dev {horas.Desenvolvedor} já foi cadastrado";
        }

        [HttpPut]
        public async Task<string> Put(BancoHorasTable horas)
        {
            var res = await bancoCRUD.Update(horas);
            if (res is true)
                return $"o Horario foi alterado com sucesso";

            return $"o Horario não consta no sistema";
        }
        [HttpDelete("{id}")]
        public async Task<string> Delete(BancoHorasTable horas)
        {
            var res = await bancoCRUD.Delete(horas);
            if (res is true)
                return $"Apagado com Sucesso";

            return $"Não Encontrado";
        }
    }
}
