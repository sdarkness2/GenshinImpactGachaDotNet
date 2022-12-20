using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PersonagemIdEntity
    {
        public int PersonagemId { get; private set; }

        public PersonagemIdEntity(int personagemId)
        {
            PersonagemId = personagemId;
        }
    }
}
