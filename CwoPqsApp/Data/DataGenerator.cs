using CwoPqsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CwoPqsApp.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CwoPqsAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<CwoPqsAppContext>>()))
            {
                // Look for any board games.
                if (context.Officers.Any())
                {
                    return;   // Data was already seeded
                }
                context.Officers.AddRange(
                    new Officer
                    {
                        Id = 6,
                        FirstName = "Lindsay",
                        LastName = "Spencer",
                        Rank = "LTJG"
                    });

                context.SaveChanges();
            }
        }
    }
}

