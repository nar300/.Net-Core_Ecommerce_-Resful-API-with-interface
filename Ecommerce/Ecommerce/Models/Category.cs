using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{ 
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category Name Required")]
        [Column(TypeName = "VARCHAR (50)")]
        public string categoryname { get; set; }

        [Required(ErrorMessage ="Category Description required")]
        [Column(TypeName = "VARCHAR (500)")]
        public string description { get; set; }

        public List<Product> Products { get; set; }
    }
}
