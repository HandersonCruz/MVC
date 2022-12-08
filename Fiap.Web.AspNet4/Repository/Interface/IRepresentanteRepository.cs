using Fiap.Web.AspNet4.Models;

namespace Fiap.Web.AspNet4.Repository.Interface
{
    public interface IRepresentanteRepository
    {

        public List<RepresentanteModel> FindAll();

        public RepresentanteModel FindById(int id);

        public void Insert(RepresentanteModel representanteModel);

        public void Update(RepresentanteModel representanteModel);

        public void Delete(int id);

        public void Delete(RepresentanteModel representanteModel);

    }
}
