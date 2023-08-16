using product_app_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace product_app_test.ViewModel
{
    public class ProductForm
    {
        [Display(Name =" product name"),Required,StringLength(200)]
            public string item_name { get; set; }
        [Display(Name = " product image")]
            public Byte[] item_img { get; set; }

        [Display(Name = " product discription"), Required, StringLength(2500)]
            public string item_dec { get; set; }
            public int price { get; set; }
        [Display(Name = " category name"), Required]
            public Byte ctg_id { get; set; }
            public IEnumerable<Category> category { get; set; }

    }
}
