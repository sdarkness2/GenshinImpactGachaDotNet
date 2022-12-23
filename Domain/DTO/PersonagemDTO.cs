using Domain.Enum;
using System.Diagnostics.CodeAnalysis;

namespace Domain.DTO
{
    [ExcludeFromCodeCoverage]
    public class PersonagemDTO
    {
        public int PersonagemId { get; set; }
        public string Nome { get; set; }
        public int Estrela { get; set; }
        public ElementosEnum Elemento { get; set; }
    }
}
