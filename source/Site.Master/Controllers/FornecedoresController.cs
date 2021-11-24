using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Negocios.Entidades;
using Site.Negocios.Interfaces;

namespace Site.Master.Controllers
{
    public class FornecedoresController : Controller
    {
        private IProdutoRepositorio produtoRepositorio;
        private IFornecedorRepositorio fornecedorRepositorio;

        public FornecedoresController(IProdutoRepositorio produtoRepositorio, IFornecedorRepositorio fornecedorRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
            this.fornecedorRepositorio = fornecedorRepositorio;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            return View(await fornecedorRepositorio.ObterTodos());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await fornecedorRepositorio.ObterPorId(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Documento,TipoDocumento,DataCriacao,Telefone,Email,Id")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                fornecedor.Id = Guid.NewGuid();
                await fornecedorRepositorio.Adicionar(fornecedor);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await fornecedorRepositorio.ObterPorId(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Documento,TipoDocumento,DataCriacao,Telefone,Email,Id")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await fornecedorRepositorio.Atualizar(fornecedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
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
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await fornecedorRepositorio.ObterPorId(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await fornecedorRepositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(Guid id)
        {
            return fornecedorRepositorio.ObterPorId(id).Result != null;
        }
    }
}
