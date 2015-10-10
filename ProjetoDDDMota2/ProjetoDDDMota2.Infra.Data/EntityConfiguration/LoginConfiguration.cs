using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using ProjetoDDDMota2.Domain.Entities;

namespace ProjetoDDDMota2.Infra.Data.EntityConfiguration
{
    public class LoginConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginConfiguration()
        {
            //ToTable("Login");

            HasKey(x => x.LoginId);

            Property(x => x.Usuario).IsRequired().HasColumnType("varchar").HasMaxLength(150);

            Property(x => x.Senha).IsRequired().HasColumnType("varchar").HasMaxLength(150);
        }
    }
}
