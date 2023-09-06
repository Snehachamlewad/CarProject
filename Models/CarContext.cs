using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace C_INFO.Models
{
        public class CarContext : DbContext
        {
            public CarContext(DbContextOptions<CarContext> options) : base(options)
            {
            }

            public DbSet<CAR1> CAR1S { get; set; }
            public DbSet<Manufacturer1> Manufacturer1s { get; set; }
            public DbSet<CarType1> CarType1s { get; set; }
            public DbSet<CarTransmissionType1> CarTransmissionType1s { get; set; }
        public DbSet<RegisterTbl> RegisterTbls { get; set; }
    }
}
