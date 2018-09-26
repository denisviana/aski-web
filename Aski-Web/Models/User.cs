using System;
using System.Collections.Generic;

namespace Aski_Web.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool WantBeHelped { get; set; }
        public bool WantToHelp { get; set; }
        public List<Discipline> HasDomainIn { get; set; }
        public List<Discipline> HasDificultyIn { get; set; }
    }
}
