using System.Collections.Generic;
using System.Data.OracleClient;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Service
{
    public class SHistori
    {
        public static List<Product> Products { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<OrderItem> OrderItems { get; set; }
    }
}
