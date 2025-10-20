namespace PetHub.Domain.Entities
{
    public class Pet
    {
        public Pet(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            this.Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddError("Pet name is invalid");
        }

        private void AddError(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsInvalid => Errors.Any();

        public List<string> Errors { get; set; } = [];
    }
}
