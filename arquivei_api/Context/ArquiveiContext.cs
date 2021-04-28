using arquivei_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace arquivei_api.Context
{
    public partial class ArquiveiContext : DbContext
    {
        public ArquiveiContext(DbContextOptions<ArquiveiContext> options)
           : base(options)
        { }

        public virtual DbSet<Nfe> Nfes { get; set; }
    }
}
