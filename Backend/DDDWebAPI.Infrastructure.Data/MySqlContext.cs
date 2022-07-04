
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
        public DbSet<MateriaPrima> MateriaPrimas { get; set; }
        public DbSet<MateriaPrima_Produto> MateriaPrimasProduto { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Many to Many
            modelBuilder.Entity<Produto>()
            .HasMany(p => p.materiasprima)
            .WithMany(m => m.Produtos)
            .UsingEntity<MateriaPrima_Produto>(
                j => j
                    .HasOne(pt => pt.MateriaPrima)
                    .WithMany(t => t.MateriaPrima_Produtos)
                    .HasForeignKey(pt => pt.MateriaID),
                j => j
                    .HasOne(pt => pt.Produto)
                    .WithMany(p => p.MateriaPrima_Produtos)
                    .HasForeignKey(pt => pt.ProdutoID),
                j =>
                {
                    j.Property(pt => pt.dataAlteracao).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.ProdutoID, t.MateriaID });
                });
            #endregion

            #region One to Many 
            modelBuilder.Entity<Produto>()
                        .HasOne<Categoria>()
                        .WithMany(p => p.produtos)
                        .HasForeignKey(c=> c.categoriaid);
            #endregion


        }
        #region Construtores
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            //ensure data base is created 
            try
            {
                var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
                if (!databaseCreator.Exists())
                    databaseCreator.EnsureCreated();
                databaseCreator.CreateTables();
            }
            catch { }
        }

        #endregion


    }
}
