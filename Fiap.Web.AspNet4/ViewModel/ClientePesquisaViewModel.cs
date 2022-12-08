using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fiap.Web.AspNet4.ViewModel
{
    public class ClientePesquisaViewModel
    {

        [Display(Name = "Nome do Cliente")]
        public string ClienteNome { get; set; }

        [Display(Name = "Digite o email do cliente")]
        public string ClienteEmail { get; set; }

        [Display(Name = "Selecione o Representante")]
        public int RepresentanteId { get; set; }

        public SelectList Representantes { get; set; }

        public IList<ClienteViewModel> Clientes { get; set; }

    }
}
