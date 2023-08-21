using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using product_app_test.Models;
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
            var categories = await _Context.Product.ToListAsync();
            return View("index",categories);
        }

        public async Task<IActionResult> Create()
        {
            var CreateProductForm = new ProductViewModel
            {
                categories = await _Context.Category.OrderBy(i => i.ctg_name).ToListAsync()
            };
            return View("ProducForm", CreateProductForm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model )  // model (ال instance  الي هيقرا الداتا )
        {
            if (!ModelState.IsValid)
            {
                model.categories = await _Context.Category.OrderBy(i => i.ctg_name).ToListAsync();
                return View("ProducForm",model);
            }

            var files = Request.Form.Files;
             if(!files.Any())
            {
                model.categories = await _Context.Category.OrderBy(i => i.ctg_name).ToListAsync();
                ModelState.AddModelError("item_img", "Please select image product");
                return View("ProducForm", model);
            }

            var imgProduct = files.FirstOrDefault();
            var allowedExtentions = new List<string> { ".jpg", ".png" };

            if(!allowedExtentions.Contains(Path.GetExtension(imgProduct.FileName).ToLower()))
            {
                model.categories = await _Context.Category.OrderBy(i => i.ctg_name).ToListAsync();
                ModelState.AddModelError("item_img", "only .PNG, .JPG images are allowed ");
                return View("ProducForm", model);
            }

            if (imgProduct.Length > 1048576)
            {
                model.categories = await _Context.Category.OrderBy(i => i.ctg_name).ToListAsync();
                ModelState.AddModelError("item_img", "Poster cannot be more than 1 MB!");
                return View("ProducForm", model);
            }

            using var dataStream = new MemoryStream();
            await imgProduct.CopyToAsync(dataStream);

            // convert from ProductForm to Product
            var products = new Product
            {
                item_name = model.item_name,
                item_img = dataStream.ToArray(),
                item_dec = model.item_dec,
                price = model.price,
                Year = model.Year,
                Rate = model.Rate,
                ctg_id = model.ctg_id
            };
            _Context.Product.Add(products);
            _Context.SaveChanges();


            return RedirectToAction(nameof(index));
         //  return View(model);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var productItem = await _Context.Product.FindAsync(id);
            if(productItem == null)
            {
                return NotFound();
            }

            var products = new Product
            {
                item_id = productItem.item_id,
                item_name = productItem.item_name,
                item_img = productItem.item_img,
                item_dec = productItem.item_dec,
                price = productItem.price,
                Year = productItem.Year,
                Rate = productItem.Rate,
                ctg_id = productItem.ctg_id
            };

            return View("ProducForm", products);



        }
    }
    
}
