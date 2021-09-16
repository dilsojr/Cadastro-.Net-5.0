using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Site.Negocios.Entidades;

namespace Site.Dados.Mapeamento
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Rua).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Bairro).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Numero).IsRequired().HasColumnType("varchar(10)");
            builder.Property(x => x.CEP).IsRequired().HasColumnType("varchar(8)");
            builder.Property(x => x.Cidade).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Estado).IsRequired().HasColumnType("varchar(50)");

            builder.ToTable("ENDERECO_FORNECEDOR");
        }
    }
}
