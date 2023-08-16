using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace product_app_test.Models
{
    public class Product
    {[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Byte item_id { get; set; }
        public string item_name { get; set; }
        public Byte[] item_img { get; set; }
        public string item_dec { get; set; }
        public int price { get; set; }
        public Byte ctg_id { get; set; }
        public Category category { get; set; }   // navigation property
    }
}
