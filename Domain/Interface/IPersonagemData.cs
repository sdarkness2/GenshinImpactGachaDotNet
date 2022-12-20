using Domain.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IPersonagemData
    {
        IEnumerable<PersonagemDTO> RetornaPersonagemPorId(PersonagemIdEntity personagem);
        IEnumerable<PersonagemDTO> RetornaTodosOsPersonagens();
        bool AdicionarPersonagem(PersonagemEntity personagem);
    }
}
