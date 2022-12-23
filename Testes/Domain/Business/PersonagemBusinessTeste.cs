﻿using Domain.DTO;
using Domain.Entity;
using Domain.Enumerable;
using Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Fact(DisplayName = nameof(AdicionarPersonagemNomeMenosQueQuatroCaracteres))]
        public void AdicionarPersonagemNomeMenosQueQuatroCaracteres()
        {
            var personagem = new PersonagemEntity("Dil", 5, ElementosEnum.PYRO);

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("O nome deve ter no minimo 4 caracteres e não deve ser nulo.", result);
        }

        [Trait("Domain", "Business")]
        [Fact(DisplayName = nameof(AdicionarPersonagemNomeVazio))]
        public void AdicionarPersonagemNomeVazio()
        {
            var personagem = new PersonagemEntity("", 5, ElementosEnum.PYRO);

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("O nome deve ter no minimo 4 caracteres e não deve ser nulo.", result);
        }

        [Trait("Domain", "Business")]
        [Fact(DisplayName = nameof(AdicionarPersonagemEstrelaMaiorQueCinco))]
        public void AdicionarPersonagemEstrelaMaiorQueCinco()
        {
            var personagem = new PersonagemEntity("Diluc", 6, ElementosEnum.PYRO);

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("As estrelas do personagem só vão de 4 a 5.", result);
        }

        [Trait("Domain", "Business")]
        [Fact(DisplayName = nameof(AdicionarPersonagemEstrelaMenorQueQuatro))]
        public void AdicionarPersonagemEstrelaMenorQueQuatro()
        {
            var personagem = new PersonagemEntity("Diluc", 3, ElementosEnum.PYRO);

            var result = _business.AdicionarPersonagem(personagem);

            Assert.Equal("As estrelas do personagem só vão de 4 a 5.", result);
        }

    }
}