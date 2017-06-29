using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Moq;
using NUnit.Framework;

namespace BusinessLogicLayer.Tests
{
    [TestFixture]
    public class GetOwnersTests
    {
        [Test]
        public void GetOwners_FiltersPets_SoOnlyCatsRemain()
        {
            var mockPetOwnerDataAccessLayer = new Mock<IPetOwnerDataAccessLayer>();

            var petsDal = new List<PetDal>();

            petsDal.Add(new PetDal {Name = "Michi", Type = "Cat"});
            petsDal.Add(new PetDal {Name = "Escamosa", Type = "Snake"});

            var ownersDal = new List<OwnerDal>();

            ownersDal.Add(new OwnerDal {Age = 20, Name = "Catherine", Gender = "Female", Pets = petsDal});

            mockPetOwnerDataAccessLayer.Setup(s => s.GetOwners())
                .Returns(Task.FromResult<IEnumerable<OwnerDal>>(ownersDal));

            var petOwnerServices = new PetOwnerServices(mockPetOwnerDataAccessLayer.Object);

            var actualDtoResult = petOwnerServices.GetOwners().Result;

            foreach (var ownerDto in actualDtoResult)
                Assert.AreEqual(1, ownerDto.Pets.Count);
        }

        [Test]
        public void GetOwners_FiltersOwners_SoIfPetsIsNullOwnerIsNotIncludedinDTOForPresentationLayer()
        {
            var mockPetOwnerDataAccessLayer = new Mock<IPetOwnerDataAccessLayer>();

            var petsDalCatherine = new List<PetDal>();

            petsDalCatherine.Add(new PetDal { Name = "Michi", Type = "Cat" });
            petsDalCatherine.Add(new PetDal { Name = "Escamosa", Type = "Snake" });

            var petsDalJosh = new List<PetDal>();

            petsDalJosh.Add(new PetDal { Name = "Ziggy", Type = "Cat" });
            petsDalJosh.Add(new PetDal { Name = "Henry", Type = "Parrot" });
            petsDalJosh.Add(new PetDal { Name = "Mico", Type = "Cat" });

            var ownersDal = new List<OwnerDal>();

            ownersDal.Add(new OwnerDal { Age = 21, Name = "Catherine", Gender = "Female", Pets = petsDalCatherine });
            ownersDal.Add(new OwnerDal { Age = 23, Name = "Franc", Gender = "Male", Pets = null });
            ownersDal.Add(new OwnerDal { Age = 20, Name = "Josh", Gender = "Male", Pets = petsDalJosh });

            mockPetOwnerDataAccessLayer.Setup(s => s.GetOwners())
                .Returns(Task.FromResult<IEnumerable<OwnerDal>>(ownersDal));

            var petOwnerServices = new PetOwnerServices(mockPetOwnerDataAccessLayer.Object);

            var actualDtoResult = petOwnerServices.GetOwners().Result;

            Assert.AreEqual(2, actualDtoResult.Count());
        }

        [Test]
        public void GetOwners_SortsPets_ByNameDescending()
        {
            var mockPetOwnerDataAccessLayer = new Mock<IPetOwnerDataAccessLayer>();

         

            var petsDalJosh = new List<PetDal>();

            petsDalJosh.Add(new PetDal { Name = "Ziggy", Type = "Cat" });
            petsDalJosh.Add(new PetDal { Name = "Henry", Type = "Parrot" });
            petsDalJosh.Add(new PetDal { Name = "Bico", Type = "Cat" });

            var ownersDal = new List<OwnerDal>();

            ownersDal.Add(new OwnerDal { Age = 23, Name = "Franc", Gender = "Male", Pets = null });
            ownersDal.Add(new OwnerDal { Age = 20, Name = "Josh", Gender = "Male", Pets = petsDalJosh });

            mockPetOwnerDataAccessLayer.Setup(s => s.GetOwners())
                .Returns(Task.FromResult<IEnumerable<OwnerDal>>(ownersDal));

            var petOwnerServices = new PetOwnerServices(mockPetOwnerDataAccessLayer.Object);

            var actualDtoResult = petOwnerServices.GetOwners().Result;

            foreach (var ownerDto in actualDtoResult)
                Assert.AreEqual("Bico", ownerDto.Pets.ElementAt(0).Name);
        }
    }
}