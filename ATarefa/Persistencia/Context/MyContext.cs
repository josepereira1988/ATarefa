using Dominio.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Tarefa> tarefas { get; set; }
        public DbSet<ComentariosTarefa> comentarios { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ComentariosTarefa>()
            //.HasKey(linha => new { linha.Id, linha.Linha });
           // modelBuilder.Entity<Tarefa>().HasData()
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = DbConf.Conect();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }
    }
}
