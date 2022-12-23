using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PersonagemEntity
    {
        public PersonagemEntity(string nome, int estrela, ElementosEnum elemento)
        {
            Nome = nome;
            Estrela = estrela;
            Elemento = elemento;
        }

        public string Nome { get; private set; }
        public int Estrela { get; private set; }
        public ElementosEnum Elemento { get; private set; }
    }
}
