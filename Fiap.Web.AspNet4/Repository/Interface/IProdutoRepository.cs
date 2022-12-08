using Fiap.Web.AspNet4.Models;

namespace Fiap.Web.AspNet4.Repository.Interface
{
    public interface IProdutoRepository
    {
        public IList<ProdutoModel> FindAll();

        public ProdutoModel FindById(int id);

        public int Insert(ProdutoModel produtoNovoViewModel);

    }
}
