using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserPets
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int PetId { get; private set; }
        public bool IsActive { get; private set; }
    }
}
