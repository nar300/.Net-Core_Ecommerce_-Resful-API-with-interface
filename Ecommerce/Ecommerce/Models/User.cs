using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Email required")]
        [EmailAddress(ErrorMessage ="please enter a valid email")]
        public string email { get; set; }
        [Required(ErrorMessage ="Password required")]
        [MinLength(6,ErrorMessage ="minimum 6 chacters required")]
        public string password { get; set; }
        public List<Cart> Cart { get; set; }

        public User()
        {
            Cart = new List<Cart>();
        }
    }
}
