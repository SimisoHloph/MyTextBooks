using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using My_Books.Data.Models;

namespace My_Books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Born A crime",
                        Description = "Comedy",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 8,
                        Genre = "Comedy",
                        Author = "Trevor Noah",
                        CoverUrl = "../",
                        DateAdded = DateTime.Now.AddDays(-12),

                    },
                    new Book()
                    {
                        Title = "Born A crime",
                        Description = "Comedy",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 8,
                        Genre = "Comedy",
                        Author = "Trevor Noah",
                        CoverUrl = "../",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
