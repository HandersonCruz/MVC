using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository;
using Fiap.Web.AspNet4.Repository.Interface;
using Fiap.Web.AspNet4.Controllers.Filters;

namespace Fiap.Web.AspNet4.Controllers
{
    [FiapAuthFilter]    public class Fornecedor : Controller
    {

        private readonly IFornecedorRepository fornecedorRepository;

        public Fornecedor(IFornecedorRepository _fornecedorRepository)
        {
            fornecedorRepository = _fornecedorRepository;
        }

        // GET: Fornecedor
        public IActionResult Index()
        {
              return View(fornecedorRepository.FindAll());
        }


        // GET: Fornecedor/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = fornecedorRepository.FindById(id);

            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FornecedorId,FornecedorNome,Cnpj,Telefone,Email")] FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorRepository.Insert(fornecedorModel);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        // GET: Fornecedor/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = fornecedorRepository.FindById(id);
            fornecedorRepository.Update(fornecedorModel);

            if (fornecedorModel == null)
            {
                return NotFound();
            }
            return View(fornecedorModel);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FornecedorId,FornecedorNome,Cnpj,Telefone,Email")] FornecedorModel fornecedorModel)
        {
            if (id != fornecedorModel.FornecedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    fornecedorRepository.Update(fornecedorModel);

                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        // GET: Fornecedor/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorModel = fornecedorRepository.FindById(id);

            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            fornecedorRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
