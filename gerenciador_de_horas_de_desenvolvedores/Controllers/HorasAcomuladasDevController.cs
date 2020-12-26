﻿using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gerenciador_de_horas_de_desenvolvedores.Domain;
using System.Threading.Tasks;
using System.Collections.Generic; 

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
        public async Task<ITable[]> Get()
        {
            return await horasCrud.GetAll();
        }

        [HttpGet("GetTopByNumber/{number}")]
        public async Task<ITable[]> GetTopNumber(int number)
        {
            var c = await horasCrud.GetAll();
            
            if(c.Length < number)
                number = c.Length;
            
            List<HorasAcomuladasDevTable> list = new List<HorasAcomuladasDevTable>();
            
            for(int i=0; i < number;i++)
                list.Add((HorasAcomuladasDevTable)c[i]);
            
            return list.ToArray();
        }
        
        [HttpPost("GetOne")]
        public async Task<ITable> One(ITable ety)
        {
            return await horasCrud.GetOne(ety);
        }
        public async Task<string> Post(DesenvolvedorTable desenvolvedor)
        {
            var res = await horasCrud.Insert(desenvolvedor);
            if (res is true)
                return $"as horas foram lançadas com sucesso";
            
            return $"erro no lançamento";
        }
        
        [HttpPut]
        public async Task<string> Put(HorasAcomuladasDevTable desenvolvedor)
        {
            var res = await horasCrud.Update(desenvolvedor);
            if (res is true)
                return $"o Dev {desenvolvedor.Desenvolvedor} foi alterado com sucesso";

            return $"o Dev {desenvolvedor.Desenvolvedor} não consta no sistema";
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(HorasAcomuladasDevTable desenvolvedor)
        {
            var res = await horasCrud.Delete(desenvolvedor);
            if (res is true)
                return $"Apagado com Sucesso";

            return $"Não Encontrado";

        }
    }
}