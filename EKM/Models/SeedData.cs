using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EKM.Data;
using System;
using System.Linq;

namespace EKM.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcBookContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Frankenstein",
                        Author = "Mary Shelley",
                        ReleaseDate = DateTime.Parse("1818-1-1"),
                        Genre = "Horror",
                        Price = 7.99M
                    },

                    new Book
                    {
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        ReleaseDate = DateTime.Parse("1925-4-10"),
                        Genre = "Tragedy",
                        Price = 8.99M
                    },

                    new Book
                    {
                        Title = "Moby Dick",
                        Author = "Herman Melville",
                        ReleaseDate = DateTime.Parse("1851-10-18"),
                        Genre = "Adventure",
                        Price = 9.99M
                    },

                    new Book
                    {
                        Title = "The Time Machine",
                        Author = "H.G. Wells",
                        ReleaseDate = DateTime.Parse("1895-1-1"),
                        Genre = "Science Fiction",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}