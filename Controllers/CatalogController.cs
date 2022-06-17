using Microsoft.AspNetCore.Mvc;
using MVC_study.Models;
using MVC_study.Services;

namespace MVC_study.Controllers
{
    public class CatalogController : Controller
    {
        private ICatalog _catalog;
        private readonly IMailService _mail;

        public CatalogController(ICatalog catalog, IMailService mail)
        {
            _catalog = catalog;
            _mail = mail;
        }

        [HttpGet]
        public IActionResult Products()
        {
            return View(_catalog);
        }

        [HttpPost]
        public IActionResult ProductsAsync(Product model)
        {
            _catalog.Add(model);

            List<string> to = new List<string>();
            to.Add("daniil_sviridov@mail.ru");

            _ =  _mail.SendAsync(new MailData(to,"Добавлен новый товар!", $" id: {model.Id} name: {model.Name}"), new CancellationToken());

            return View(_catalog);
        }
    }
}
