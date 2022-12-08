using Fiap.Web.AspNet4.Data;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;

namespace Fiap.Web.AspNet4.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public UsuarioModel Login(UsuarioModel usuarioModel)
        {
            var usuario = dataContext.Usuarios
                    .SingleOrDefault(x =>   x.UsuarioEmail == usuarioModel.UsuarioEmail && 
                                            x.UsuarioSenha == usuarioModel.UsuarioSenha);

            return usuario;

            //return dataContext.Usuarios.Where(x => x.UsuarioNome == username && x.UsuarioSenha == password).FirstOrDefault();
            
        }
    }
}
