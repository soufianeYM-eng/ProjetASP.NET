using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetASP.NET.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string CIN { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public int IdFil { get; set; }
        public int IdDept { get; set; }

    }
}
