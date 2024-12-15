using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;

//Classe de context de BDD, permet de définir les tables de la BDD
public class ApplicationDbContext : IdentityDbContext<Teacher>
{
    //DbSet est une classe qui représente une table
    //Elle fait le mapping entre la table et la classe C#
    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Event> Events { get; set; }


    // Constructeur de la classe
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}