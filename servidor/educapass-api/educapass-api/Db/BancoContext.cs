using educapass_api.Models;
using Microsoft.EntityFrameworkCore;

namespace educapass_api.Db
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<EscolaModel> Escola { get; set; }
        public DbSet<ClaseModel> Clase { get; set; }
        public DbSet<AlunoModel> Aluno { get; set; }
        public DbSet<ProfessorModel> Professor { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClaseModel>()
                .HasOne(t => t.Escola)
                .WithMany(u => u.Clase)
                .HasForeignKey(t => t.Escola_id);

            modelBuilder.Entity<AlunoModel>()
                .HasOne(t => t.Escola)
                .WithMany(u => u.Aluno)
                .HasForeignKey(t => t.Escola_id);

            modelBuilder.Entity<AlunoModel>()
                .HasOne(t => t.Clase)
                .WithMany(u => u.Aluno)
                .HasForeignKey(t => t.Clase_id);

            modelBuilder.Entity<ProfessorModel>()
                .HasOne(t => t.Escola)
                .WithMany(u => u.Professor)
                .HasForeignKey(t => t.Escola_id);
        }
    }
}
