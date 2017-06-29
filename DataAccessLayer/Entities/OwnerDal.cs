using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class OwnerDal
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public IEnumerable<PetDal> Pets { get; set; }
    }
}