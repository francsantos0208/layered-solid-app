using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataTransferObjects;

namespace BusinessLogicLayer
{
    public class PetOwnerServices : IPetOwnerServices
    {
        private readonly IPetOwnerDataAccessLayer _petOwnerDataAccessLayer;

        public PetOwnerServices(IPetOwnerDataAccessLayer petOwnerDataAccessLayer)
        {
            _petOwnerDataAccessLayer = petOwnerDataAccessLayer;
        }

        public async Task<IEnumerable<OwnerDto>> GetOwners()
        {
            var owners = await _petOwnerDataAccessLayer.GetOwners();

            var ownersWithCats =
                from owner in owners
                where owner.Pets != null
                      && owner.Pets.Any(p => p.Type.Equals("Cat"))
                select owner;

            var ownersDto = new List<OwnerDto>();

            foreach (var ownerWithCat in ownersWithCats)
            {
                var ownerDto = new OwnerDto {Gender = ownerWithCat.Gender, Pets = new List<PetDto>()};

                foreach (var pet in ownerWithCat.Pets.OrderBy(p=>p.Name))
                    if (pet.Type.Equals("Cat")) ownerDto.Pets.Add(new PetDto {Name = pet.Name});

                ownersDto.Add(ownerDto);
            }

            return ownersDto;
        }
    }
}