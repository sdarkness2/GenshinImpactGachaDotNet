namespace Domain.Entity
{
    public class PersonagemIdEntity
    {
        public int PersonagemId { get; private set; }

        public PersonagemIdEntity(int personagemId)
        {
            PersonagemId = personagemId;
        }
    }
}
