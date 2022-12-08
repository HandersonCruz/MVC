using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet4.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public IList<ProdutoModel> FindAll()
        {
            var lista = dataContext.Produtos.ToList<ProdutoModel>(); // Nao tem WHERE

            if ( lista == null || lista.Count() == 0)
            {
                throw new Exception("Lista vazia");
            }

            return lista;
        }

        public ProdutoModel FindById(int id)
        {
            var produto = dataContext
                    .Produtos // From
                        .Include( p => p.ProdutosLojas ) // Inner Join
                            .ThenInclude( l => l.Loja)   // Inner Join
                    .SingleOrDefault( p => p.ProdutoId == id ); // Where 

            return produto; 
        }

        public int Insert(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();

            return produtoModel.ProdutoId;
        }
    }
}
