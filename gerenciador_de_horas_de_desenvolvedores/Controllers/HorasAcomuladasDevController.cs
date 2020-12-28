using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gerenciador_de_horas_de_desenvolvedores.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace gerenciador_de_horas_de_desenvolvedores.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorasAcomuladasDevController : ControllerBase
    {
        private readonly ILogger<LubyTestDB> logger;
        private HorasAcomuladasDevCRUD horasCrud;

        public HorasAcomuladasDevController(
            ILogger<LubyTestDB> _logger,
            LubyTestDB context)
        {
            logger = _logger;
            horasCrud = new HorasAcomuladasDevCRUD(context);
        }

        [HttpGet]
        
        public async Task<ActionResult<ITable[]>> Get()
        {
            try
            {
                var all = await horasCrud.GetAll();
                return Ok(all);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpGet("GetTopByNumber/{number}")]
        public async Task<ActionResult<ITable[]>> GetTopNumber(int number)
        {
            var c = await horasCrud.GetAll();
            
            if(c.Length < number)
                number = c.Length;
            
            List<HorasAcomuladasDevTable> list = new List<HorasAcomuladasDevTable>();
            
            for(int i=0; i < number;i++)
                list.Add((HorasAcomuladasDevTable)c[i]);
            
            return Ok(list.ToArray());
        }
        
        [HttpPost("GetOne")]
        public async Task<ActionResult<ITable>> One(BancoHorasTable ety)
        {
            return await horasCrud.GetOne(ety);
        }
        [HttpPost]
        public async Task<bool> Post(HorasAcomuladasDevTable desenvolvedor)
        {
            var res = await horasCrud.Insert(desenvolvedor);
            if (res is true)
                return true;
            
            return false;
        }
        
        [HttpPut]
        public async Task<bool> Put(HorasAcomuladasDevTable desenvolvedor)
        {
            var res = await horasCrud.Update(desenvolvedor);
            if (res is true)
                return true;

            return false;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await horasCrud.Delete(id);
            if (res is true)
                return true;

            return false;

        }
    }
}
