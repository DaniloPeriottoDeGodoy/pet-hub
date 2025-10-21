using PetHub.Domain.Enums;

namespace PetHub.AppService.DTOs
{
    public class FilterPetDTO
    {
        public FilterPetDTO(string? name, Species specie, Status status)
        {
            Name = name;
            Specie = specie;
            Status = status;
        }

        public string? Name { get; set; }
        public Species Specie { get; set; }
        public Status Status { get; set; }
    }
}
