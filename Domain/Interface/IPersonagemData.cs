using Domain.DTO;
using Domain.Entity;

namespace Domain.Interface
{
    public interface IPersonagemData
    {
        IEnumerable<PersonagemDTO> RetornaPersonagemPorId(PersonagemIdEntity personagem);
        IEnumerable<PersonagemDTO> RetornaTodosOsPersonagens();
        bool AdicionarPersonagem(PersonagemEntity personagem);
    }
}
