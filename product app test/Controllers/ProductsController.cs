using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product_app_test.ViewModel;

namespace product_app_test.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DbcontextApp _Context;

        public ProductsController(DbcontextApp context)
        {
            _Context = context;
        }


        public async Task<IActionResult> index()
        {
            var movies = await _Context.Product.ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> Create()
        {
            var CreateProductForm = new ProductForm
            {
                category = await _Context.Category.ToListAsync()
            };
            return View(CreateProductForm);
        }

    }   
}
