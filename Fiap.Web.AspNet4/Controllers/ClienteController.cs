using AutoMapper;
using Fiap.Web.AspNet4.Controllers.Filters;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Fiap.Web.AspNet4.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet4.Controllers
{
    [FiapAuthFilter]
    public class ClienteController : Controller
    {

        private readonly IClienteRepository clienteRepository;
        private readonly IRepresentanteRepository representanteRepository;
        private readonly IMapper mapper;

        public ClienteController(IClienteRepository _clienteRepository, IRepresentanteRepository _representanteRepository, IMapper _mapper)
        {
            clienteRepository = _clienteRepository;
            representanteRepository = _representanteRepository;
            mapper = _mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {

            var vm = new ClientePesquisaViewModel();
            vm.Representantes = LoadRepresentantes();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Pesquisar(ClientePesquisaViewModel vm)
        {
            List<ClienteModel> listaClientes = 
                clienteRepository
                    .FindByNomeAndEmailAndRepresentante(
                        vm.ClienteNome, 
                        vm.ClienteEmail, 
                        vm.RepresentanteId);

            var listaClienteVM = mapper.Map<List<ClienteViewModel>>(listaClientes);

            vm.Representantes = LoadRepresentantes();
            vm.Clientes = listaClienteVM;

            return View("Index", vm );
        }



        [HttpGet]
        public IActionResult Novo()
        {
            ComboRepresentantes();

            return View(new ClienteModel());
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Insert(clienteModel);

                TempData["Mensagem"] = "Cliente cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                ComboRepresentantes();

                return View(clienteModel);
            }
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            ComboRepresentantes();

            var clienteModel = clienteRepository.FindById(id);

            return View(clienteModel);
        }


        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if ( ModelState.IsValid  ) {
                clienteRepository.Update(clienteModel);

                TempData["Mensagem"] = "Cliente editado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                ComboRepresentantes();
                return View(clienteModel);
            }

        }

        

        [HttpGet]
        public IActionResult Remover(int id)
        {
            TempData["Mensagem"] = "Cliente removido com sucesso";

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = clienteRepository.FindById(id);
            return View(clienteModel);
        }



        private void ComboRepresentantes()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            var selectListRepresentantes = new SelectList(listaRepresentantes, "RepresentanteId", "NomeRepresentante");
            ViewBag.representantes = selectListRepresentantes;
        }


        private SelectList LoadRepresentantes()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            return new SelectList(listaRepresentantes, "RepresentanteId", "NomeRepresentante");
        }

    }
}
