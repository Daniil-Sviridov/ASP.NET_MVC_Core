using Microsoft.AspNetCore.Mvc;
using MVC_study.Models;
using MVC_study.Services;

namespace MVC_study.Controllers
{
    public class CatalogController : Controller
    {
        private ICatalog _catalog;


        public CatalogController(ICatalog catalog)
        {
            _catalog = catalog;
        }

        [HttpGet]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult ProductsAsync(Product model)
        {
            CancellationToken ct = new CancellationToken();
            _catalog.Add(model, ct);

            return View(_catalog);
        }
    }
}
