using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aski_Web.Models
{
    public class Course
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome do curso")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres")]
        public string Name { get; set; }
    }
}