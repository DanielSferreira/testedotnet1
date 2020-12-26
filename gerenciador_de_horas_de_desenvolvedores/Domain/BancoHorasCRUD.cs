using System.Linq;
using System.Threading.Tasks;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace gerenciador_de_horas_de_desenvolvedores.Domain
{
    public class BancoHorasCRUD : ICRUD
    {

        private LubyTestDB context;
        public BancoHorasCRUD(LubyTestDB _context)
        {
            context = _context;
        }
        public async Task<bool> Insert(ITable ety)
        {
            BancoHorasTable entity = (BancoHorasTable)ety;
            await context.BancoHoras.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(ITable ety)
        {
            BancoHorasTable entity = (BancoHorasTable)ety;
            var res = context.BancoHoras.FirstOrDefault(x => x.DataId == entity.DataId);
            if (res is not null)
            {
                res.Desenvolvedor = entity.Desenvolvedor;
                res.DataIni = entity.DataIni;
                res.DataFim = entity.DataFim;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> Delete(ITable ety, bool isId = true)
        {
            BancoHorasTable entity = (BancoHorasTable)ety;
            BancoHorasTable res;

            try
            {
                if (isId)
                    res = context.BancoHoras.FirstOrDefault(x => x.Id == entity.Id);
                else
                    res = context.BancoHoras.FirstOrDefault(x => x.Desenvolvedor == entity.Desenvolvedor);

                var delete = context.Desenvolvedores.FirstOrDefault(x => x.Id == entity.Id);
                context.Entry(delete).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }
        public async Task<ITable[]> GetAll()
        {
            return await context.BancoHoras.Select(x => x).ToArrayAsync();
        }
        public async Task<ITable> GetOne(ITable ety, bool isId = true)
        {

            BancoHorasTable entity = (BancoHorasTable)ety;
            if (isId)
                return await context.BancoHoras.FirstOrDefaultAsync(x => x.Id == entity.Id);
            else
                return await context.BancoHoras.FirstOrDefaultAsync(x => x.Desenvolvedor == entity.Desenvolvedor);

        }
    }
}