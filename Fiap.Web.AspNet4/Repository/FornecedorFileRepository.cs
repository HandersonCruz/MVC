using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;

namespace Fiap.Web.AspNet4.Repository
{
    public class FornecedorFileRepository : IFornecedorRepository
    {
        private readonly DataContext dataContext;

        public FornecedorFileRepository(DataContext context)
        {
            dataContext = context;
        }


        public List<FornecedorModel> FindAll()
        {
            return dataContext.Fornecedores.ToList();
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

        public void Delete(int id)
        {
            FornecedorModel fornecedor = new FornecedorModel();
            fornecedor.FornecedorId = id;
            Delete(fornecedor);
        }

        public void Delete(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Remove(fornecedorModel);
            dataContext.SaveChanges();
        }
    }
}
