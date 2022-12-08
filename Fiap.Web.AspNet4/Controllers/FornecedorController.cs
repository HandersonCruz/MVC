using Fiap.Web.AspNet4.Controllers.Filters;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet4.Controllers
{
    [FiapAuthFilter, FiapLogFilter]
    public class FornecedorController : Controller
    {

        private readonly IFornecedorRepository fornecedorRepository;

        public FornecedorController(IFornecedorRepository _fornecedorRepository)
        {
            fornecedorRepository = _fornecedorRepository;
        }

        // GET: Fornecedor
        public IActionResult Index()
        {
            //FornecedorRepository repo = new FornecedorRepository(null);
            //var lista = repo.FindAll();

            return View( fornecedorRepository.FindAll() );
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
            if (id == null )
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
            if (id == null )
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
