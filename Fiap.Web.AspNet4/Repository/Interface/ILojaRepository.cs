using Fiap.Web.AspNet4.Models;

namespace Fiap.Web.AspNet4.Repository.Interface
{
    public interface ILojaRepository
    {
        public IList<LojaModel> FindAll();
    }
}
