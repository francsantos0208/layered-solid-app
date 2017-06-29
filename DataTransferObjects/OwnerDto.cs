using System.Collections.Generic;

namespace DataTransferObjects
{
    public class OwnerDto
    {
        public string Gender { get; set; }
        public List<PetDto> Pets { get; set; }
    }
}