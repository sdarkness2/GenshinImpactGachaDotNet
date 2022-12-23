using Domain.Entity;

namespace Domain.Interface
{
    public interface IPersonagemBusiness
    {
        string AdicionarPersonagem(PersonagemEntity personagem);
        string ValidarPersonagem(PersonagemEntity personagem);
        string VerificarSePersonagemJáExiste(PersonagemEntity personagem);
        PersonagemEntity AjeitarNome(PersonagemEntity personagem);
    }
}
