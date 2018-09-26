using System.Collections.Generic;

namespace Aski_Web.Models
{
    public class Discipline
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<User> UsersOwners { get; set; }
        public List<User> DependentUsers { get; set; }
    }
}
