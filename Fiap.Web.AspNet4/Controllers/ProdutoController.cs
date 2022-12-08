using Fiap.Web.AspNet4.Controllers.Filters;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Fiap.Web.AspNet4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet4.Controllers
{
    //[FiapAuthFilter]
    public class ProdutoController : Controller
    {
        // Declarando a propriedade do repositorio
        private readonly IProdutoRepository produtoRepository;

        // declarando o construtor da classe
        public ProdutoController(IProdutoRepository _produtoRepository)
        {
            produtoRepository = _produtoRepository;
        }


        public IActionResult Index()
        {
            IList<ProdutoModel> produtos = produtoRepository.FindAll();

            return View(produtos);
        }

        public IActionResult Details(int id)
        {
            ProdutoModel produtoModel = produtoRepository.FindById(id);

            return View(produtoModel);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(ProdutoNovoViewModel produtoNovoViewModel)
        {

            try
            {
                var produtoModel = new ProdutoModel();
                produtoModel.ProdutoNome = produtoNovoViewModel.ProdutoNome;
                produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

                if (produtoNovoViewModel.LojaId != null || produtoNovoViewModel.LojaId.Count() > 0)
                {

                    foreach (var item in produtoNovoViewModel.LojaId)
                    {
                        var produtoLojaModel = new ProdutoLojaModel();

                        produtoLojaModel.LojaId = item;
                        produtoLojaModel.Produto = produtoModel;
                        produtoModel.ProdutosLojas.Add(produtoLojaModel);
                    }
                }
                else
                {
                    throw new Exception("Nenhuma loja foi selecionada!");
                }

                produtoRepository.Insert(produtoModel);

                TempData["mensagem"] = "Produto cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produtoNovoViewModel);
            }            
        }

        private SelectList LoadLojas()
        {

        }
    }
}
