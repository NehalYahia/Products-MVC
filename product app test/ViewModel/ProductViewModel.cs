using product_app_test.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace product_app_test.ViewModel
{
    public class ProductViewModel
    {
        public int item_id { get; set; }
        [Display(Name =" product name"),Required,StringLength(200)]
            public string item_name { get; set; }
        [Display(Name = "select product image")]
            public Byte[] item_img { get; set; }

        [Display(Name = " product discription"), Required, StringLength(2500)]
            public string item_dec { get; set; }
        [Required]
            public int price { get; set; }
        [Display(Name = " category name"), Required]
            public Byte ctg_id { get; set; }
            public IEnumerable<Category> categories { get; set; }
            public int Year { get; set; }
        [Range(1, 10)]
            public double Rate { get; set; }

    }
}
