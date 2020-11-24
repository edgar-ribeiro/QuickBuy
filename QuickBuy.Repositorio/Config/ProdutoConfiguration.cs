using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Dominio.Entidades;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);//chave primaria - campo referenciado atraves de lambda

            //Builder utiliza padrao Fluent
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(400);
            builder.Property(p => p.Preco).IsRequired();
        }
    }
}
