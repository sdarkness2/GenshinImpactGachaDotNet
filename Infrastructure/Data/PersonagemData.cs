using Domain.DTO;
using Domain.Entity;
using Domain.Interface;
using Infrastructe.Data.Base;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class PersonagemData : BaseData, IPersonagemData
    {
        private static string _connectionString = "GenshinDb";

        public PersonagemData(IConfiguration config):base(_connectionString, config)
        {
        }

        #region LEITURA
        public IEnumerable<PersonagemDTO> RetornaPersonagemPorId(PersonagemIdEntity personagem)
        {
            var query = "SELECT * FROM TB_PERSONAGEM WHERE PERSONAGEMID = @PERSONAGEMID";

            return base.Leitura<PersonagemDTO>(query, personagem);
        }

        public IEnumerable<PersonagemDTO> RetornaTodosOsPersonagens()
        {
            var query = "SELECT * FROM TB_PERSONAGEM";

            return base.Leitura<PersonagemDTO>(query, null);
        }
        #endregion

        #region ESCRITA

        public bool AdicionarPersonagem(PersonagemEntity personagem)
        {
            var query = @"INSERT INTO TB_PERSONAGEM (NOME, ESTRELA, ELEMENTO)
                        VALUES (@NOME, @ESTRELA, @ELEMENTO)";

            var result = base.Escrita(query, personagem);

            return result > 0;
        }

        #endregion
    }
}
