using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noetic.WebUI.Controllers;
using Noetic.Core.Contracts;
using Noetic.Core.Models;
using System.Web.Mvc;
using Noetic.Core.ViewModels;
using System.Linq;

namespace Noetic.WebUI.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexPageDoesReturnProducts()
        {
            IRepository<Product> productContext = new Mocks.MockContext<Product>();
            IRepository<ProductCategory> productCatgeoryContext = new Mocks.MockContext<ProductCategory>();

            productContext.Insert(new Product());

            HomeController controller = new HomeController(productContext, productCatgeoryContext);

            var result = controller.Index() as ViewResult;
            var viewModel = (ProductListViewModel)result.ViewData.Model;

            Assert.AreEqual(1, viewModel.Products.Count());

        }
    }
}
