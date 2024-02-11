using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class OwnerDal
    {
        //change 4 - four
        //change 5 - five
        //change 6 - six
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public IEnumerable<PetDal> Pets { get; set; }
    }
}