using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Domain.DTO;
using Domain.Interface;
using System.Net;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Infrastructe.Data.Base;
using Domain.Entity;

namespace Infrastructe.Data
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

            return base.Read<PersonagemDTO>(query, personagem);
        }

        public IEnumerable<PersonagemDTO> RetornaTodosOsPersonagens()
        {
            var query = "SELECT * FROM TB_PERSONAGEM";

            return base.Read<PersonagemDTO>(query, null);
        }
        #endregion

        #region ESCRITA

        public bool AdicionarPersonagem(PersonagemEntity personagem)
        {
            var query = @"INSERT INTO TB_PERSONAGEM (NOME, ESTRELA, ELEMENTO)
                        VALUES (@NOME, @ESTRELA, @ELEMENTO)";

            var result = base.Write(query, personagem);

            return result > 0;
        }

        #endregion
    }
}
