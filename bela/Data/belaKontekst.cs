using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using bela.Models;

namespace bela.Data
{
    public class belaKontekst : DbContext
    {
        public belaKontekst (DbContextOptions<belaKontekst> options)
            : base(options)
        {
        }

        public DbSet<bela.Models.Bela> Bela { get; set; }

        public DbSet<bela.Models.Partija> Partija { get; set; }
    }
}
