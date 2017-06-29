using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public interface IPetOwnerDataAccessLayer
    {
        Task<IEnumerable<OwnerDal>> GetOwners();
    }
}