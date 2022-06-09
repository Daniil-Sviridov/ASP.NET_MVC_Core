﻿using Microsoft.AspNetCore.Mvc;
using MVC_study.Models;

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
        public IActionResult Products(Product model)
        {
            _catalog.Add(model);
            return View(_catalog);
        }
    }
}
