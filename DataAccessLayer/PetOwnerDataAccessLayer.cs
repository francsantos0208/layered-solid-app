using System.Collections.Generic;
using System.Threading.Tasks;
using API.Client;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public class PetOwnerDataAccessLayer : IPetOwnerDataAccessLayer
    {
        public async Task<IEnumerable<OwnerDal>> GetOwners()
        {
            var owners =
                await HttpClientSingleton.Instance.GetData<IEnumerable<OwnerDal>>(
                    "http://agl-developer-test.azurewebsites.net/people.json");

            return owners;
        }
    }
}