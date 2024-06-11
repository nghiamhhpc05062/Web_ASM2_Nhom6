using System;
using System.Collections.Generic;

namespace Web_ASM_Nhom6.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public DateTime OpeningHours { get; set; }
        public bool IsDelete { get; set; }

        public Category Category { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }
}
