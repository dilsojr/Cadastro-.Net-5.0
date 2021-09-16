﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Site.Negocios.Entidades;

namespace Site.Dados.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("vatchar(1000)");
            builder.Property(x => x.Imagem).IsRequired().HasColumnType("varchar(100)");

            builder.ToTable("PRODUTO");
        }
    }
}
