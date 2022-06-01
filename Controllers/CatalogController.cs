using Microsoft.AspNetCore.Mvc;
using MVC_study.Models;

namespace MVC_study.Controllers
{
    public class CatalogController : Controller
    {
        private Catalog _catalog = new();

        public CatalogController()
        {
            _catalog.Products.Add(new Product() { Id = 1, Name = "Тест" }) ;
        }

        [HttpGet]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult Products(Product model)
        {
            _catalog.Products.Add(model);
            return View(_catalog);
        }
    }
}
