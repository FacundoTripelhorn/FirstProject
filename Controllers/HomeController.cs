using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstProject.Models;
using FirstProject.Entities;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Products()
        {
            dbContext.Database.EnsureCreated();

            List<ProductViewModel> products = new List<ProductViewModel>();

            foreach(var product in dbContext.Products)
            {
                ProductViewModel vm = new ProductViewModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };

                products.Add(vm);
            }

            return View(products);
        }
    }
}
