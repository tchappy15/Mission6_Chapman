//using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mission6.Models
{
    public class JoelHiltonContext : DbContext
    //inherit from a DbContext class
    {

        //constructor:
        public JoelHiltonContext(DbContextOptions<JoelHiltonContext> options) : base(options)
        {
            Console.WriteLine($"Database Path: {Database.GetDbConnection().ConnectionString}");
        }

        public DbSet<Application> Applications { get; set; } //Applications is the name of the TABLE that all the Application objects are going to
    }
}
