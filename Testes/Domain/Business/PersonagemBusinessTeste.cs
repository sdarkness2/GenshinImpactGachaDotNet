using Domain.DTO;
using Domain.Entity;
using Domain.Enum;
using Domain.Interface;
using Moq;

namespace Testes.Domain.Business
{
    public class PersonagemBusinessTeste
    {
        private readonly Mock<IPersonagemData> _personagemData;
        private readonly PersonagemBusiness _business;

        public PersonagemBusinessTeste()
        {
            _personagemData = new Mock<IPersonagemData>();
            _business = new PersonagemBusiness(_personagemData.Object);
        }

        [Trait("Domain", "Business")]
        [Fact(DisplayName = nameof(AdicionarPersonagemComSucesso))]
        public void AdicionarPersonagemComSucesso()
        {
            var personagem = new PersonagemEntity("Diluc", 5, ElementosEnum.PYRO);
            _personagemData.Setup(x => x.AdicionarPersonagem(It.IsAny<PersonagemEntity>())).Returns(true);
            _personagemData.Setup(x => x.RetornaTodosOsPersonagens()).Returns(
                new List<PersonagemDTO>()
                );

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("Personagem adicionado com sucesso", result);
        }

        [Trait("Domain", "Business")]
        [Fact(DisplayName = nameof(AdicionarPersonagemSemSucesso))]
        public void AdicionarPersonagemSemSucesso()
        {
            var personagem = new PersonagemEntity("Diluc", 5, ElementosEnum.PYRO);
            _personagemData.Setup(x => x.AdicionarPersonagem(It.IsAny<PersonagemEntity>())).Returns(false);
            _personagemData.Setup(x => x.RetornaTodosOsPersonagens()).Returns(
                new List<PersonagemDTO>()
                );

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("Houve algum erro.", result);
        }

        [Trait("Domain", "Business")]
        [Fact(DisplayName = nameof(AdicionarPersonagemExistente))]
        public void AdicionarPersonagemExistente()
        {
            var personagem = new PersonagemEntity("Diluc", 5, ElementosEnum.PYRO);
            _personagemData.Setup(x => x.RetornaTodosOsPersonagens()).Returns(
                                        new List<PersonagemDTO> {
                                        new PersonagemDTO { Elemento = ElementosEnum.PYRO, Estrela = 5, Nome = "Diluc"},
                                        new PersonagemDTO { Elemento = ElementosEnum.PYRO, Estrela = 5, Nome = "Yoimiya"}
                                        });

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("Já existe um personagem come esse nome.", result);
        }

        [Trait("Domain", "Business")]
        [Theory(DisplayName = nameof(AdicionarPersonagemNomeMenosQueQuatroCaracteresOuVazio))]
        [InlineData("Dil")]
        [InlineData("")]
        public void AdicionarPersonagemNomeMenosQueQuatroCaracteresOuVazio(string nome)
        {
            var personagem = new PersonagemEntity(nome, 5, ElementosEnum.PYRO);

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("O nome deve ter no minimo 4 caracteres e não deve ser vazio.", result);
        }

        [Trait("Domain", "Business")]
        [Theory(DisplayName = nameof(AdicionarPersonagemEstrelaMenorQueQuatroEMaiorQueCinco))]
        [InlineData(3)]
        [InlineData(6)]
        public void AdicionarPersonagemEstrelaMenorQueQuatroEMaiorQueCinco(int estrela)
        {
            var personagem = new PersonagemEntity("Diluc", estrela, ElementosEnum.PYRO);

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("As estrelas do personagem só vão de 4 a 5.", result);
        }
    }
}
