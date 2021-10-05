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
    public class ProdutoRepositorioTeste
    {

        private ProdutoRepositorio produtoRepositorio;
        private Fornecedor fornecedor;
       
        [SetUp]
        public void Inicializar()
        {
            var options = new DbContextOptionsBuilder<MeuDBContext>().UseInMemoryDatabase("produto_teste").Options;
            fornecedor = CriarFornecedor();
            using (var context = new MeuDBContext(options))
            {
                produtoRepositorio = new ProdutoRepositorio(context);
                context.Fornecedores.Add(fornecedor);
                context.SaveChanges();
            }
        }

        [Test]
        public void QuandoPassarFornecedorIdDeveReceberSeusProdutos()
        {

            var retorno = produtoRepositorio.ObterProdutosPorFornecedor(fornecedor.Id).Result.ToList();

            retorno.Should().NotBeNull();
            retorno.Count.Should().Be(1);
            retorno[0].Nome.Should().Be("Celular");

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
