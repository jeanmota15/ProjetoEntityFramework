using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDDDMota2.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;

namespace ProjetoDDDMota2.Infra.Data.EntityConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Cliente");

            HasKey(x => x.ClienteId);

            Property(x => x.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(150);

            Property(x => x.Sobrenome).IsRequired().HasColumnType("varchar").HasMaxLength(150);

            Property(x => x.Email).IsRequired().HasColumnType("varchar");

        }
    }
}
