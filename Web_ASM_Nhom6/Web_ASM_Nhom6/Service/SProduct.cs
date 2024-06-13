using System.Collections.Generic;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Service
{
    public class SProduct
    {
        public List<Product> Products { get; set; }
        public SProduct()
        {
            Products = new List<Product>();
        }
    }
}
