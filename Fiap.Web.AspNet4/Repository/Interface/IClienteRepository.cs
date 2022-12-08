using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;

namespace Fiap.Web.AspNet4.Repository.Interface
{
    public interface IClienteRepository
    {

        public List<ClienteModel> FindAll();


        public List<ClienteModel> FindAllOrderByNomeAsc();


        public List<ClienteModel> FindAllOrderByNomeDesc();


        public List<ClienteModel> FindByNome(string nomeParcial);


        public List<ClienteModel> FindByNomeAndEmail(string nomeParcial, string emailParcial);


        public List<ClienteModel> FindByNomeAndEmailAndRepresentante(string nomeParcial, string emailParcial, int? representanteId);


        public ClienteModel FindById(int id);

        public void Insert(ClienteModel clienteModel);

        public void Update(ClienteModel clienteModel);

        public void Delete(int id);

        public void Delete(ClienteModel clienteModel);

    }
}
