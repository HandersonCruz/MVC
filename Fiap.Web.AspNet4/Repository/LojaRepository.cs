using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;

namespace Fiap.Web.AspNet4.Repository
{
    public class LojaRepository : ILojaRepository
    {

        private readonly DataContext dataContext;

        public LojaRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }


        public IList<LojaModel> FindAll()
        {
            return dataContext.Lojas.ToList();
        }

    }
}