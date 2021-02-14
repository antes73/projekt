using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bela.Models
{
    public class Bela
    {
        public int Id { get; set; }
        public int ZvanjaMi { get; set; }
        public int BodoviMi { get; set; }
        public int BodoviVi { get; set; }
        public int ZvanjaVi { get; set; }


        public Partija Partija { get; set; }
        public int PartijaId { get; set; }
   
    }
}
