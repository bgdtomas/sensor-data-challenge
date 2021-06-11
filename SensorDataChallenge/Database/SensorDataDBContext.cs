using Microsoft.EntityFrameworkCore;
using SensorDataChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataChallenge.Database
{
    public class SensorDataDBContext : DbContext
    {
        public SensorDataDBContext(DbContextOptions<SensorDataDBContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Seguro> Seguros{ get; set; }

    }
}
