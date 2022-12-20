using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
    public class PersonagemBusiness : IPersonagemBusiness
    {
        private IPersonagemData _personagemData;

        public PersonagemBusiness(IPersonagemData personagemData)
        {
            _personagemData = personagemData;
        }

        public string AdicionarPersonagem(PersonagemEntity personagem)
        {
            var personagemTratado = AjeitarNome(personagem);
            var validar = ValidarPersonagem(personagemTratado);

            if (string.IsNullOrEmpty(validar))
            {
                var result = _personagemData.AdicionarPersonagem(personagemTratado);

                return result ? "Personagem adicionado com sucesso" : "Houve algum erro.";

            }
            return validar;
        }

        public string ValidarPersonagem(PersonagemEntity personagem)
        {
            if(personagem.Nome.Length < 4 || string.IsNullOrEmpty(personagem.Nome))
            {
                return "O nome deve ter no minimo 4 caracteres e não deve ser nulo.";
            }
            if(personagem.Estrela > 5 || personagem.Estrela < 3)
            {
                return "As estrelas do personagem só vão de 3 a 5";
            }
            var validarNomePersonagem = VerificarSePersonagemJáExiste(personagem);
            if(!string.IsNullOrEmpty(validarNomePersonagem))
            {
                return validarNomePersonagem;
            }
            return "";
        }
        
        public string VerificarSePersonagemJáExiste(PersonagemEntity personagem)
        {
            var personagens = _personagemData.RetornaTodosOsPersonagens();

            var personagensNome = personagens.Select(x => x.Nome.ToLower());

            return personagensNome.Contains(personagem.Nome.ToLower()) ? "Já existe um personagem come esse nome." : "";
        }

        public PersonagemEntity AjeitarNome(PersonagemEntity personagem) 
        {
            return new PersonagemEntity(personagem.Nome.Trim(), personagem.Estrela, personagem.Elemento);
        }
    }
}
