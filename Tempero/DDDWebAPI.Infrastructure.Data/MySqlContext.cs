
using DDDWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DDDWebAPI.Infrastructure.Data
{
    public class MySqlContext : DbContext
    {
        #region Data Sets
        public DbSet<Feira> Feiras { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                        .HasOne(c => c.categoria)
                        .WithMany(p => p.produtos);
        }
        #region Construtores
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            //ensure data base is created 
            try
            {
                var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
                if (databaseCreator.Exists())
                    databaseCreator.EnsureCreated();
                databaseCreator.CreateTables();
            }
            catch { }
        }

        #endregion


    }
}
