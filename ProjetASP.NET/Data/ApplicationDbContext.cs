using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetASP.NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Filiere> Filieres { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Departement> Departements { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Element> Elements { get; set; }

        public DbSet<Etudiant> Etudiants { get; set; }
    }
}
