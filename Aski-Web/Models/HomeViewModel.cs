using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aski_Web.Models
{
    public class HomeViewModel
    {
        public Question Question;
        public List<Discipline> Disciplines;
        public List<User> UserCanHelp;
    }
}