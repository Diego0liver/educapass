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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClaseModel>()
                .HasOne(t => t.Escola)
                .WithMany(u => u.Clase)
                .HasForeignKey(t => t.Escola_id);
        }
    }
}
