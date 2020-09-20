using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CwoPqsApp.Models;

namespace CwoPqsApp.Data
{
    public class CwoPqsAppContext : DbContext
    {
        public CwoPqsAppContext (DbContextOptions<CwoPqsAppContext> options)
            : base(options)
        {
        }

        public DbSet<CwoPqsApp.Models.Officer> Officers { get; set; }
    }
}
