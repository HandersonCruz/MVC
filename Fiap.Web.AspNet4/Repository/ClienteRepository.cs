using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet4.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly DataContext dataContext;
        public ClienteRepository(DataContext context)
        {
            dataContext = context;
        }


        public List<ClienteModel> FindAll()
        {
            var listaClientes = dataContext
                    .Clientes // SELECT * FROM Clientes
                        .Include(r => r.Representante)  // inner join
                                .ToList<ClienteModel>();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindAllOrderByNomeAsc()
        {
            var listaClientes = dataContext
                    .Clientes // SELECT * FROM Clientes
                        .Include(r => r.Representante)  // inner join
                        .OrderBy( c => c.Nome )
                                .ToList<ClienteModel>();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindAllOrderByNomeDesc()
        {
            var listaClientes = dataContext
                    .Clientes // SELECT * FROM Clientes
                        .Include(r => r.Representante)  // inner join
                        .OrderByDescending(c => c.Nome)
                                .ToList<ClienteModel>();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindByNome(string nomeParcial)
        {
            var listaClientes = dataContext
                    .Clientes                                       // SELECT * FROM Clientes
                        .Include(r => r.Representante)              // inner join
                        .Where( c => c.Nome.Contains(nomeParcial) ) // Where
                        .OrderBy(c => c.Nome)                       // order by
                            .ToList<ClienteModel>();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindByNomeAndEmail(string nomeParcial, string emailParcial)
        {
            var listaClientes = dataContext
                    .Clientes                                           // SELECT * FROM Clientes
                        .Include(r => r.Representante)                  // inner join
                        .Where(c => c.Nome.Contains(nomeParcial) && 
                                    c.Email.Contains(emailParcial) )    // Where nome like %var% AND email like %var%
                        .OrderBy(c => c.Nome)                           // order by
                            .ToList<ClienteModel>();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindByNomeAndEmailAndRepresentante(string nomeParcial, string emailParcial, int? representanteId)
        {
            var listaClientes = dataContext
                    .Clientes                                           // SELECT * FROM Clientes
                        .Include(r => r.Representante)                  // inner join
                        .Where(c => ( String.IsNullOrEmpty(nomeParcial)  || c.Nome.Contains(nomeParcial) )  &&
                                    ( String.IsNullOrEmpty(emailParcial) || c.Email.Contains(emailParcial) ) &&
                                    ( 0 == representanteId ||   c.RepresentanteId == representanteId ) )    // Where nome like %var% AND email like %var%
                        .OrderBy(c => c.Nome)                           // order by
                            .ToList<ClienteModel>();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public ClienteModel FindById(int id)
        {
            //return dataContext.Clientes.Find(id);

            var clienteModel =
                dataContext.Clientes // SELECT * FROM Clienter
                    .Include(r => r.Representante) // Inner JOIN
                    .SingleOrDefault(c => c.ClienteId == id ); // Where

            return clienteModel;
        }

        public void Insert(ClienteModel clienteModel)
        {
            dataContext.Clientes.Add(clienteModel);
            dataContext.SaveChanges();
        }

        public void Update(ClienteModel clienteModel)
        {
            dataContext.Clientes.Update(clienteModel);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.ClienteId = id;
            Delete(clienteModel);
        }

        public void Delete(ClienteModel clienteModel)
        {
            dataContext.Clientes.Remove(clienteModel);
            dataContext.SaveChanges();
        }


    }
}
