using Fiap.Web.AspNet4.Controllers;
using Fiap.Web.AspNet4.Models;
using Fiap.Web.AspNet4.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Fiap.Web.AspNet4Test
{
    public class FornecedorControllerTest
    {

        [Fact]
        public Task IndexReturnsViewResultWithListOfFornecedores()
        {
            var repositoryMock = new Mock<IFornecedorRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns(MockFornecedorRepositoryFindAll3());

            var controller = new FornecedorController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<FornecedorModel>>(viewResult.Model);

            Assert.NotEmpty(model);

            Assert.Equal(3, model.Count());

            return Task.CompletedTask;
        }

        [Fact]
        public Task IndexReturnsViewResultWithZeroOfFornecedores()
        {
            var repositoryMock = new Mock<IFornecedorRepository>();
            repositoryMock.Setup(r => r.FindAll()).Returns( new List<FornecedorModel>() );

            var controller = new FornecedorController(repositoryMock.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<FornecedorModel>>(viewResult.Model);

            Assert.Empty(model);

            return Task.CompletedTask;
        }


        private List<FornecedorModel> MockFornecedorRepositoryFindAll3()
        {

            return new List<FornecedorModel>() {
                new FornecedorModel()
                {
                    FornecedorNome = "F1"
                },
                new FornecedorModel()
                {
                    FornecedorNome = "F2"
                },
                new FornecedorModel()
                {
                    FornecedorNome = "F3"
                }
            };
        }


    }
}
