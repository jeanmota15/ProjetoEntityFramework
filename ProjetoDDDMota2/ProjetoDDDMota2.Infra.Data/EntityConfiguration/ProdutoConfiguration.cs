using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDDDMota2.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoDDDMota2.Infra.Data.EntityConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            //ToTable("Produto");

            HasKey(x => x.ProdutoId);

            Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(150);

            HasRequired(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId);
        }
    }
}
