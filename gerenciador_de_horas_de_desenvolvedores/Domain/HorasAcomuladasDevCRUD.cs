using System.Threading.Tasks;
using System.Linq;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using System;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_de_horas_de_desenvolvedores.Domain
{
    public class HorasAcomuladasDevCRUD : ICRUD
    {
        private LubyTestDB context;
        private BancoHorasCRUD bancoCrud;
        private DesenvolvedorCRUD devCrud;
        public HorasAcomuladasDevCRUD(LubyTestDB _context)
        {
            context = _context;
            bancoCrud = new BancoHorasCRUD(context);
            devCrud = new DesenvolvedorCRUD(context);
        }
        public async Task<bool> Insert(ITable ety)
        {
            BancoHorasTable dev = (BancoHorasTable)ety;
            var tt = context.BancoHoras.Where(x => x.Desenvolvedor == dev.Desenvolvedor);
            double acc = 0;
            foreach (var i in tt)
                acc += (i.DataFim - i.DataIni).TotalHours;

            var hora = new HorasAcomuladasDevTable()
            {
                Desenvolvedor = dev.Desenvolvedor,
                HorasAcomuladas = acc
            };
            var coot = context.HorasAcomuladasDev.FirstOrDefault(x => x.Desenvolvedor == dev.Desenvolvedor);
            if (coot is null)
            {
                await context.HorasAcomuladasDev.AddAsync(hora);
                await context.SaveChangesAsync();
            }
            else
                await this.Update(hora);
            return true;
        }
        public async Task<bool> Update(ITable ety)
        {
            HorasAcomuladasDevTable entity = (HorasAcomuladasDevTable)ety;
            var res = context.HorasAcomuladasDev.FirstOrDefault(x => x.Desenvolvedor == entity.Desenvolvedor);
            if (res is not null)
            {
                res.Desenvolvedor = entity.Desenvolvedor;
                res.HorasAcomuladas = entity.HorasAcomuladas;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var delete = context.HorasAcomuladasDev.FirstOrDefault(x => x.Id == id);
            context.Entry(delete).State = EntityState.Deleted;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<ITable[]> GetAll()
        {
            return await context.HorasAcomuladasDev.Select(x => x).OrderByDescending(x => x.HorasAcomuladas).ToArrayAsync();
        }
        public async Task<ITable> GetOne(ITable ety, bool isId = true)
        {
            HorasAcomuladasDevTable entity = (HorasAcomuladasDevTable)ety;
            if (isId)
                return await context.HorasAcomuladasDev.FirstOrDefaultAsync(x => x.Id == entity.Id);
            else
                return await context.HorasAcomuladasDev.FirstOrDefaultAsync(x => x.Desenvolvedor == entity.Desenvolvedor);

        }
    }
}
