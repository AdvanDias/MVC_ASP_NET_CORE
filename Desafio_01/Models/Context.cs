using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_01.Models
{
    public class Context : DbContext
    {
        public DbSet<TipoExame> tipoExames { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<ConsultaMarca> ConsultaMarcas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DesafioBD;Integrated Security=True");
        }
    }
}
