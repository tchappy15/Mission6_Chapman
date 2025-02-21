using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission6_Chapman.Models;

public class JoelHiltonMovieCollectionContext : DbContext //inherit from a DbContext class
{

    public JoelHiltonMovieCollectionContext(DbContextOptions<JoelHiltonMovieCollectionContext> options)
        : base(options)
    {
        Console.WriteLine($"Database Path: {Database.GetDbConnection().ConnectionString}");
    }

    public DbSet<Movie> Movies { get; set; } //first table
    public DbSet<Category> Categories { get; set; } //second table

    //code to seed our database

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>().HasData( //go in and check to see if there's already data of type Category in this table. If no data, then we will run our code:
                    new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 2, CategoryName = "Drama" },
                    new Category { CategoryId = 3, CategoryName = "Television" },
                    new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 5, CategoryName = "Comedy" },
                    new Category { CategoryId = 6, CategoryName = "Family" },
                    new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 8, CategoryName = "VHS" }
                );
    }

}

