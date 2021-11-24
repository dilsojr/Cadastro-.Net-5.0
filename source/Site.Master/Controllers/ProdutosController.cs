using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Dados.Contexto;
using Site.Negocios.Entidades;
using Site.Negocios.Interfaces;

namespace Site.Master.Controllers
{
    public class ProdutosController : Controller
    {
        private IProdutoRepositorio produtoRepositorio;
        private IFornecedorRepositorio fornecedorRepositorio;

        public ProdutosController(IProdutoRepositorio produtoRepositorio, IFornecedorRepositorio fornecedorRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
            this.fornecedorRepositorio = fornecedorRepositorio;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            return View(await produtoRepositorio.ObterTodos());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var produto = await _context.Produtos
            //    .Include(p => p.Fornecedor)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var produto = await produtoRepositorio.ObterProdutosPorFornecedor(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public async Task<IActionResult> Create()
        {
            var result = await fornecedorRepositorio.ObterTodos();
            ViewData["FornecedorId"] = new SelectList(result, "Id", "Documento");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorId,Nome,Descricao,Valor,DataInclusao,Imagem,QuantidadeEstoque,Id")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.Id = Guid.NewGuid();
                produtoRepositorio.Adicionar(produto);
                return RedirectToAction(nameof(Index));
            }
            var result = await fornecedorRepositorio.ObterTodos();
            ViewData["FornecedorId"] = new SelectList(result, "Id", "Documento", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoRepositorio.ObterPorId(id.Value);
            if (produto == null)
            {
                return NotFound();
            }
            var result = await fornecedorRepositorio.ObterTodos();
            ViewData["FornecedorId"] = new SelectList(result, "Id", "Documento", produto.FornecedorId);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FornecedorId,Nome,Descricao,Valor,DataInclusao,Imagem,QuantidadeEstoque,Id")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    produtoRepositorio.Atualizar(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var result = await fornecedorRepositorio.ObterTodos();
            ViewData["FornecedorId"] = new SelectList(result, "Id", "Documento", produto.FornecedorId);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoRepositorio.ObterProdutosPorFornecedor(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await produtoRepositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(Guid id)
        {
            return produtoRepositorio.ObterPorId(id).Result != null;
        }
    }
}
