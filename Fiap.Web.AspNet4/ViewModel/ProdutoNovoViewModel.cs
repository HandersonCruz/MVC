using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet4.ViewModel

{
    public class ProdutoNovoViewModel
    {
        public string ProdutoNome { get; set; }
        public IList<LojaViewModel> Lojas { get; set; }
        public ICollection<int> LojaId { get; set; }


    }
}
