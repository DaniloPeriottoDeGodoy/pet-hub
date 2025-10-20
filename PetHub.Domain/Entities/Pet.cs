namespace PetHub.Domain.Entities
{
    public class Pet
    {
        public Pet()
        {
            Id = Guid.NewGuid();            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
