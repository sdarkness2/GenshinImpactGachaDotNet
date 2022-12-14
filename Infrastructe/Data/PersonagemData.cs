﻿using System;
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

namespace Infrastructe.Data
{
    public class PersonagemData : IPersonagemData
    {
        private IConfiguration _config;
        private readonly string _connectionString;

        public PersonagemData(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("GenshinDb");
        }

        public PersonagemDTO RetornaPersonagemPorId(int id)
        {
            //protocolo de segurança
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            //query a ser executada
            var query = "SELECT * FROM TB_PERSONAGEM WHERE PERSONAGEMID = @ID";

            //execução do dapper
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                var result = conexao.Query<PersonagemDTO>(query, new { id });
                return result.Count() > 0 ? result.ToList()[0] : null;
            }
        }

        public IEnumerable<PersonagemDTO> RetornaTodosOsPersonagens()
        {
            //protocolo de segurança
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

            //query a ser executada
            var query = "SELECT * FROM TB_PERSONAGEM WHERE PERSONAGEMID";

            //execução do dapper
            using (SqlConnection conexao = new SqlConnection(_connectionString))
            {
                var result = conexao.Query<PersonagemDTO>(query);
                return result;
            }
        }
    }
}