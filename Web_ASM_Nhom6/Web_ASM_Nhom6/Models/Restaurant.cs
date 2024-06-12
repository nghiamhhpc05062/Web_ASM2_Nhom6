using Web_ASM_Nhom6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_ASM_Nhom6.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống thông tin")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống thông tin")]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống thông tin")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Không được bỏ trống thông tin")]
        public DateTime OpeningHours { get; set; }
        public bool IsDelete { get; set; }

        public Category Category { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}
