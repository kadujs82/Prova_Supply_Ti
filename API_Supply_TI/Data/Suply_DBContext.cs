using API_Supply_TI.Data.Map;
using API_Supply_TI.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Supply_TI.Data
{
    public class Suply_DBContext : DbContext
    {
        public Suply_DBContext(DbContextOptions<Suply_DBContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
