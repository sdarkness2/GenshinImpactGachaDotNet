using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
