using PetHub.Domain.Enums;

namespace PetHub.Domain.Entities
{
    public class Pet
    {
        public Pet(string name, Species specie)
        {
            Id = Guid.NewGuid();
            Name = name;
            Specie = specie;

            this.Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddError("Pet name is invalid");

            if (!Enum.IsDefined(typeof(Species), Specie))
                AddError("Pet specie is invalid");
        }

        private void AddError(string errorMessage)
        {
            Errors.Add(errorMessage);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Species Specie { get; }

        public bool IsInvalid => Errors.Any();

        public List<string> Errors { get; set; } = [];
    }
}
