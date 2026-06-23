using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Trabalho_Api.Models;

namespace Trabalho_Api.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a relação entre Aluno e Avaliacao
            modelBuilder.Entity<Avaliacao>()
                .HasOne(a => a.Aluno)
                .WithMany(a => a.Avaliacoes)
                .HasForeignKey(a => a.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configura que CPF do aluno deve ser único
            modelBuilder.Entity<Aluno>()
                .HasIndex(a => a.Cpf)
                .IsUnique();

            // Configura nomes das tabelas
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliacoes");
        }
    }
}