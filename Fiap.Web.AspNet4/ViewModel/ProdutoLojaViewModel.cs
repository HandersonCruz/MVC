namespace Fiap.Web.AspNet4.ViewModel
{
    public class ProdutoLojaViewModel
    {
        public int ProdutoLojaId { get; set; }

        public int LojaId { get; set; }

        public LojaViewModel Loja { get; set; }

        public int ProdutoId { get; set; }

        public ProdutoViewModel Produto { get; set; }
    }
}
