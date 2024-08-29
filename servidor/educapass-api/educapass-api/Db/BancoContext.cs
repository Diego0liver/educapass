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
    }
}
