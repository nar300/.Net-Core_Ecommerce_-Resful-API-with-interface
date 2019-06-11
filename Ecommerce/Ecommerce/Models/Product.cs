using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("Product")]
    public class Product
    {

        [Key]
        public int productId { get; set; }
        [Required(ErrorMessage =("product name required"))]
        [DataType("varchar(50)")]
        public string name { get; set; }
        [Required(ErrorMessage = ("product price required"))]
        
        public int price { get; set; }
        [Required(ErrorMessage = ("product description required"))]
        [Column(TypeName = "VARCHAR (500)")]
        public string description { get; set; }

        [Column(TypeName = "VARCHAR (MAX)")]

        public string imageurl { get; set; }

        public int stock { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public int discount { get; set; }
        public string status { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
