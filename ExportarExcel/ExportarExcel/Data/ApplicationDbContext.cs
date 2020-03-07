using System;
using System.Collections.Generic;
using System.Text;
using ExportarExcel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExportarExcel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Producto>(producto => producto.
            HasData(

               new Producto { Id = 1, Nombre = "Dark Side of The Moon", Descontinuado = false, FechaDaLanzamiento = DateTime.Now, Precio = 99.9m },
               new Producto { Id = 2, Nombre = "Desire", Descontinuado = true, FechaDaLanzamiento = new DateTime(2010, 1, 31), Precio = 69.9m },
               new Producto { Id = 3, Nombre = "Próxima estación esperanza", Descontinuado = false, FechaDaLanzamiento = DateTime.Now, Precio = 19.9m },
               new Producto { Id = 4, Nombre = "OK Computer", Descontinuado = false, FechaDaLanzamiento = new DateTime(2018, 6, 3), Precio = 79.9m },
               new Producto { Id = 5, Nombre = "Amnesiac", Descontinuado = false, FechaDaLanzamiento = new DateTime(2011, 7, 5), Precio = 89.9m },
               new Producto { Id = 6, Nombre = "Merlina", Descontinuado = true, FechaDaLanzamiento = new DateTime(2015, 5, 4), Precio = 99.9m }
               )

            );

            base.OnModelCreating(builder);
        }
        public DbSet<Producto> Productos { get; set; }
    }
}
