using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.API.Entities
{
    public class NameInfoContext :DbContext
    {
        //public NameinfoContext(DbContextOptions<NameInfoContext> options)
        //    : base(options)
        //{
        //}
        public DbSet<NameE> Names { get; set; }
        public DbSet<PointOfInterest> PointOfInterest { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connetctionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
