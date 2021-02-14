using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace bela.Models
{
    public class Partija
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

    }
}
