using System.Collections.Generic;
using System.Threading.Tasks;
using API.Client;
using DataAccessLayer.Entities;
using System.Configuration;

namespace DataAccessLayer
{
    public class PetOwnerDataAccessLayer : IPetOwnerDataAccessLayer
    {
        public async Task<IEnumerable<OwnerDal>> GetOwners()
        {
            var peopleDataSourceEndpoint = ConfigurationManager.AppSettings["PeopleDataSourceEndpoint"];
            var owners =
                await HttpClientSingleton.Instance.GetData<IEnumerable<OwnerDal>>(peopleDataSourceEndpoint);
            return owners;
        }
    }
}