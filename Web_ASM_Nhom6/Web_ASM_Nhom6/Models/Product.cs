using System.Collections;
using System.Collections.Generic;

namespace Web_ASM_Nhom6.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public decimal Price { get; set; }
        public bool IsDelete {  get; set; }
        public Menu Menu { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Vouter> Vouters { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
