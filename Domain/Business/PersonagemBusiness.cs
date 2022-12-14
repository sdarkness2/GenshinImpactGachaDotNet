using Domain.Entity;
using Domain.Interface;

namespace Domain.Business
{
    public class PersonagemBusiness : IPersonagemBusiness
    {
        private readonly IPersonagemData _personagemData;

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
                return "O nome deve ter no minimo 4 caracteres e não deve ser vazio.";
            }
            if(personagem.Estrela > 5 || personagem.Estrela < 4)
            {
                return "As estrelas do personagem só vão de 4 a 5.";
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
