﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Site.Dados.Contexto;
using Site.Dados.Repositorios;
using Site.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Dados.Teste.RepositorioTeste
{
    public class EnderecoRepositorioTeste
    {
        private EnderecoRepositorio repositorio;
        private DbContextOptions<MeuDBContext> options;
        private MeuDBContext context;

        [SetUp]
        public void Inicializar()
        {
            options = new DbContextOptionsBuilder<MeuDBContext>().UseInMemoryDatabase("repositorio_teste").Options;
            context = new MeuDBContext(options);
            repositorio = new EnderecoRepositorio(context);
        }

        [Test]
        public void DadoFornecedorIdDeveBuscarEndereco()
        {
            var fornecedor = CriarFornecedor();
            using (context = new MeuDBContext(options))
            {
                context.Fornecedores.Add(fornecedor);
                context.SaveChanges();
            }

            var resultado = repositorio.ObterEnderecoPorFornecedor(fornecedor.Id).Result;

            resultado.Should().NotBeNull();
            resultado.Rua.Should().Be("Rua Marechal");
            resultado.Bairro.Should().Be("Centro");
            resultado.Numero.Should().Be("222");
            resultado.Cidade.Should().Be("Brusque");
            resultado.Estado.Should().Be("Santa Catarina");
            resultado.CEP.Should().Be("65433456");

        }

        private Fornecedor CriarFornecedor()
        {
            return new Fornecedor()
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
        }
    }
}
