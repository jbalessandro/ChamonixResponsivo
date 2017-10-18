using Chamonix.Domain.Models.Admin;
using Chamonix.Domain.Models.Produtos;
using Chamonix.Domain.Models.Restaurante;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chamonix.Domain.Repository
{
    public class EFDbContext: DbContext
    {
        public EFDbContext()
            : base("ChamonixDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<CliGrupoPermissao>().HasKey(x => new { x.IdGrupo, x.IdPermissao });
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Complemento> Complemento { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<ContaCategoria> ContaCategoria { get; set; }
        public DbSet<ContaParcela> ContaParcela { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<MesaSituacao> MesaSituacao { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
        public DbSet<Ramo> Ramo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}