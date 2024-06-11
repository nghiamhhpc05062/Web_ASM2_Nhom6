using System.Collections.Generic;

namespace Web_ASM_Nhom6.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
