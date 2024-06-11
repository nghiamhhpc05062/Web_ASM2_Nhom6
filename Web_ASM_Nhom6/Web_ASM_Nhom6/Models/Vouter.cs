using System;

namespace Web_ASM_Nhom6.Models
{
    public class Vouter
    {
        public int VouterId { get; set; }
        public int ProductId { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Product Product { get; set; }
    }
}
