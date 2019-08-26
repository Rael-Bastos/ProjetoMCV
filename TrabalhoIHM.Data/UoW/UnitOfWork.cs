using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHM.Dominio.UoW;
using TrabalhoIHM.Models;

namespace TrabalhoIHM.Data
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly EscolaContext _context;

        public UnitOfWork(EscolaContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
