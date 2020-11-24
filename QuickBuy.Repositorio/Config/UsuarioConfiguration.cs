using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);//chave primaria - campo referenciado atraves de lambda
            
            //Builder utiliza padrao Fluent
            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(400);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(50);
            builder.Property(u => u.SobreNome).IsRequired().HasMaxLength(50);

            //Relacionamentos
            builder
                .HasMany(u => u.Pedidos)//usuario tem muitos pedidos
                .WithOne(p => p.Usuario);//metodo acessa props da entidd acima e aq exige q pedido tenha soh UM usuario
        }
    }
}
