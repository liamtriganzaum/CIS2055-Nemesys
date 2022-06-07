using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS2055___Nemesys.Models.Documents;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Identity;
using Microsoft.Extensions.Identity.Core;

namespace CIS2055___Nemesys.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            //This will pass any options passed in the constuctor to the base class (DbContext)
            
        }
        
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Report>().HasData(
                new Report()
                {
                    RRN = 1,
                    Title = "Disaster1",
                    Location = "Malta",
                    _hazardType = HazardType.UnsafeAct,
                    Desc = "desctiption: hazardous",
                    Reporter_Email = "email@mail.com",
                    _status = Status.Open
                },
                new Report()
                {
                    RRN = 2,
                    Title = "Disaster2",
                    Location = "Malta",
                    _hazardType = HazardType.UnsafeAct,
                    Desc = "desctiption: hazardous",
                    Reporter_Email = "email@mail.com",
                    _status = Status.Open
                },
                new Report()
                {
                    RRN = 3,
                    Title = "Disaster3",
                    Location = "Malta",
                    _hazardType = HazardType.UnsafeAct,
                    Desc = "desctiption: hazardous",
                    Reporter_Email = "email@mail.com",
                    _status = Status.Open
                }
                );
        }
    }
}
