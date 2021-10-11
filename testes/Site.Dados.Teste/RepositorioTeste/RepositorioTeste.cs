using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Site.Dados.Contexto;
using Site.Dados.Repositorios;
using Site.Negocios.Entidades;
using Site.Negocios.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Dados.Teste.RepositorioTeste
{
    public class RepositorioTeste
    {
        private Repositorio<Produto> repositorio;
        private Produto produto;

        [SetUp]
        public void Inicializar()
        {
            var options = new DbContextOptionsBuilder<MeuDBContext>().UseInMemoryDatabase("repositorio_teste").Options;
            var context = new MeuDBContext(options);
            repositorio = new Repositorio<Produto>(context);
            produto = CriarProduto();
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        [Test]
        public void AdicionarTeste()
        {
            Produto produto = new Produto()
            {
                FornecedorId = new Guid(),
                Nome = "Celular2",
                Descricao = "Celular feito de barro",
                Valor = 1355.00m,
                DataInclusao = new DateTime(),
                Imagem = "1233",
                QuantidadeEstoque = 4
            };

            var retorno = repositorio.Adicionar(produto);

            retorno.Should().NotBeNull();
            retorno.Id.Should().Be(1);
        }

        [Test]
        public void BuscarTeste()
        {
            var retorno = repositorio.Buscar(x => x.Nome.Equals("Celular")).Result.ToList();

            retorno.Should().NotBeNull();
            retorno[0].Nome.Should().Be("Celular");
            retorno[0].Descricao.Should().Be("Celular feito de pedra");
        }

        [Test]
        public void ObterPorIdTeste()
        {
            var retorno = repositorio.ObterPorId(produto.Id).Result;

            retorno.Should().NotBeNull();
            retorno.Should().BeOfType(typeof(Produto));
            retorno.Nome.Should().Be("Celular");
            retorno.Descricao.Should().Be("Celular feito de pedra");

        }

        [Test]
        public void ObterTodosTest()
        {
            var retorno = repositorio.ObterTodos().Result;

            retorno.Should().NotBeEmpty();
            retorno.Should().NotBeNull();
            retorno[0].Nome.Should().Be("Celular");
        }

        [Test]
        public void AtualizarTeste()
        {
            produto.Imagem = "12345";
            repositorio.Atualizar(produto);

            var retorno = repositorio.ObterPorId(produto.Id).Result;

            retorno.Should().NotBeNull();
            retorno.Imagem.Should().Be("12345");
        }

        [Ignore("Verificar melhor a implementação do teste de remover")]
        public void RemoverTeste()
        {
            repositorio.Remover(produto.Id);
            var retorno = repositorio.ObterPorId(produto.Id).Result;

            retorno.Should().BeNull();
        }


        private static Produto CriarProduto()
        {
            return new Produto()
            {
                FornecedorId = new Guid(),
                Nome = "Celular",
                Descricao = "Celular feito de pedra",
                Valor = 1355.00m,
                DataInclusao = new DateTime(),
                Imagem = "123",
                QuantidadeEstoque = 1
            };
        }
    }
}
