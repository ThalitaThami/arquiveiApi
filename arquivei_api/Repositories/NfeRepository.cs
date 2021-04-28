using arquivei_api.Context;
using arquivei_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arquivei_api.Repositories
{   
    public interface INfeRepository 
    {
        Task InsertAsync(Nfe nfe);
    }

    public class NfeRepository : INfeRepository
    {
        private readonly ArquiveiContext _context;            
        public NfeRepository(ArquiveiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task InsertAsync(Nfe nfe)
        {
            await _context.AddAsync(nfe);
            await _context.SaveChangesAsync();
        }      
    }
}

