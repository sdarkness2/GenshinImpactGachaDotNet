using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PersonagemController : Controller
    {
        private IPersonagemBusiness _personagem;
        public PersonagemController(IPersonagemBusiness personagem) { _personagem = personagem; }

        [HttpPost("AdicionarPersonagem")]
        public IActionResult AdicionarPersonagem([FromBody]PersonagemEntity entidade)
        {
            return Ok(_personagem.AdicionarPersonagem(entidade));
        }
    }
}
