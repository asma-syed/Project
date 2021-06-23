using Microsoft.EntityFrameworkCore;
using Service1_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service1_FrontEnd.Data
{
    public class AppDbContext : DbContext
    {

        //Creating a constructor chaning that allows to inject the child class (DbContextOptions) to base class (options)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Giving the name to my table that contains food objects
        public DbSet<Alias> Aliases { get; set; }
    }
}
