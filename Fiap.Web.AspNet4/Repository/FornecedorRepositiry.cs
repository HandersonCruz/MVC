using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;

namespace Fiap.Web.AspNet4.Repository
{
    public class FornecedorRepositiry : IFornecedorRepository
    {
        private readonly DataContext dataContext;

        public FornecedorRepositiry(DataContext context)
        {
            dataContext = context;
        }

        public List<FornecedorModel> FindAll()
        {

            return dataContext.Fornecedores.ToList<FornecedorModel>();
        }

        public FornecedorModel FindById(int id)
        {
            return dataContext.Fornecedores.Find(id);
        }

        public void Insert(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Add(fornecedorModel);
            dataContext.SaveChanges();
        }

        public void Update(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Update(fornecedorModel);
            dataContext.SaveChanges();
        }

        public void Delete(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Remove(fornecedorModel);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var fornecedor = new FornecedorModel();
            fornecedor.FornecedorId = id;

            Delete(fornecedor);
        }

    }
}
