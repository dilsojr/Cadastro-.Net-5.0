using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Site.Dados.Contexto;
using Site.Dados.Repositorios;
using Site.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Site.Dados.Teste.RepositorioTeste
{
    public class FornecedorRepositorioTeste
    {
        private FornecedorRepositorio repositorio;
        private DbContextOptions<MeuDbContext> options;
        private MeuDbContext context;

        [SetUp]
        public void Inicializar()
        {
            options = new DbContextOptionsBuilder<MeuDbContext>().UseInMemoryDatabase("repositorio_teste").Options;
            context = new MeuDbContext(options);
            repositorio = new FornecedorRepositorio(context);
        }

        [Test]
        public void DadoUmIdDeFornecedorDeveBuscarComEnderecoJunto()
        {
            var fornecedor = CriarFornecedor();
            using(context = new MeuDbContext(options))
            {
                context.Fornecedores.Add(fornecedor);
                context.SaveChanges();
            }

            var resultado = repositorio.ObterFornecedorEEndereco(fornecedor.Id).Result;

            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be("Fornecedor SA");
            resultado.Endereco.Should().NotBeNull();
            resultado.Endereco.Rua.Should().Be("Rua Marechal");
        }

        [Test]
        public void DadoUmIdDeFornecedorDeveBuscarComEnderecoEProdutosJunto()
        {
            var fornecedor = CriarFornecedor();
            using (context = new MeuDbContext(options))
            {
                context.Fornecedores.Add(fornecedor);
                context.SaveChanges();
            }

            var resultado = repositorio.ObterFornecedorEnderecoEProduto(fornecedor.Id).Result;

            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be("Fornecedor SA");
            resultado.Endereco.Should().NotBeNull();
            resultado.Endereco.Rua.Should().Be("Rua Marechal");
            resultado.Produtos.Should().NotBeEmpty();
            resultado.Produtos.ToList()[0].Nome.Should().Be("Celular");
        }


        private Fornecedor CriarFornecedor()
        {
            var fornecedor = new Fornecedor()
            {
                Nome = "Fornecedor SA",
                Documento = "081999234760001",
                TipoDocumento = TipoDocumento.Cnpj,
                DataCriacao = new DateTime(),
                Telefone = "33374518",
                Email = "fornecedorsa@fornecedorsa.com",
                Endereco = new Endereco()
                {
                    Rua = "Rua Marechal",
                    Bairro = "Centro",
                    Numero = "222",
                    CEP = "65433456",
                    Cidade = "Brusque",
                    Estado = "Santa Catarina",
                },

            };

            var produtos = new List<Produto>();

            var produto = new Produto()
            {
                FornecedorId = fornecedor.Id,
                Nome = "Celular",
                Descricao = "Celular feito de pedra",
                Valor = 1355.00m,
                DataInclusao = new DateTime(),
                Imagem = "123",
                QuantidadeEstoque = 1
            };

            produtos.Add(produto);

            fornecedor.Produtos = produtos;

            return fornecedor;
        }
    }
}
