using Domain.Enumerable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class PersonagemDTO
    {
        public int PersonagemId { get; set; }
        public string Nome { get; set; }
        public int Estrela { get; set; }
        public ElementosEnum Elemento { get; set; }
    }
}
