using FluentAssertions;
using Site.Negocios.Entidades;
using Site.Negocios.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Site.Dados.Teste.RepositorioTeste
{
    public class RepositorioTeste
    {

        //private Mock<IRepositorio<Produto>> repositorio;

        //[SetUp]
        //public void Inicializar()
        //{
        //    repositorio = new Mock<IRepositorio<Produto>>();
        //}

        //[Test]
        //public void AdicionarTeste()
        //{
        //    repositorio.Object.Adicionar(It.IsAny<Produto>());
        //    repositorio.Verify(x => x.Adicionar(It.IsAny<Produto>()), Times.Once);            
        //}

        //[Test]
        //public void BuscarTeste()
        //{
        //    var listaTeste = new List<Produto>() { new Produto { Nome = "PlayStation" } };
        //    repositorio.Setup(x => x.Buscar(It.IsAny<Expression<Func<Produto, bool>>>())).ReturnsAsync(listaTeste);
        //    var retorno = repositorio.Object.Buscar(x => x.Nome == "PlayStation").Result.ToList();

        //    retorno.Should().NotBeNull();
        //    retorno.Count.Should().Be(1);
        //}

        //[Test]
        //public void ObterPorIdTeste()
        //{
        //    var produto = new Produto { Id = Guid.NewGuid() };
        //    repositorio.Setup(x => x.ObterPorId(It.IsAny<Guid>())).ReturnsAsync(produto);
        //    var guidId = Guid.NewGuid();

        //    var retorno = repositorio.Object.ObterPorId(guidId).Result;

        //    retorno.Should().NotBeNull();
        //    retorno.Should().BeOfType(typeof(Produto));
        //}

        //[Test]
        //public void ObterTodosTest()
        //{
        //    var listaTeste = new List<Produto>() { new Produto { Nome = "PlayStation" }, new Produto { Nome = "Xbox" }, new Produto { Nome = "Nintendo" }, new Produto { Nome = "PC" } };
        //    repositorio.Setup(x => x.ObterTodos()).ReturnsAsync(listaTeste);

        //    var retorno = repositorio.Object.ObterTodos().Result;

        //    retorno.Should().NotBeEmpty();
        //    retorno.Count.Should().Be(4);
        //    retorno[0].Nome.Should().Be("PlayStation");
        //    retorno[1].Nome.Should().Be("Xbox");
        //    retorno[2].Nome.Should().Be("Nintendo");
        //    retorno[3].Nome.Should().Be("PC");
        //}

        //[Test]
        //public void AtualizarTeste()
        //{
        //    repositorio.Object.Atualizar(It.IsAny<Produto>());
        //    repositorio.Verify(x => x.Atualizar(It.IsAny<Produto>()), Times.Once);
        //}

        //[Test]
        //public void RemoverTeste()
        //{
        //    repositorio.Object.Remover(It.IsAny<Guid>());
        //    repositorio.Verify(x => x.Remover(It.IsAny<Guid>()), Times.Once);
        //}       
    }
}
