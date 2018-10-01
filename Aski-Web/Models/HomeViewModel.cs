using System;
using System.Collections.Generic;

namespace Aski_Web.Models
{
    public class HomeViewModel
    {
        public User User { get; set; }
        public List<String> HasDificultyIn { get; set; }
        public List<String> HasDomainIn { get; set; }
    }
}
