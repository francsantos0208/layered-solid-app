using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects;

namespace BusinessLogicLayer
{
    public interface IPetOwnerServices
    {
        Task<IEnumerable<OwnerDto>> GetOwners();
    }
}