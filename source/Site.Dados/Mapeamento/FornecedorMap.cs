using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Site.Negocios.Entidades;

namespace Site.Dados.Mapeamento
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Documento).IsRequired().HasColumnType("varchar(200)");

            builder.HasOne(x => x.Endereco).WithOne(e => e.Fornecedor);
            builder.HasMany(x => x.Produtos).WithOne(f => f.Fornecedor).HasForeignKey(p => p.FornecedorId);

            builder.ToTable("FORNECEDOR");
        }
    }
}
