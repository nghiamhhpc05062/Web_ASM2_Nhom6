using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web_ASM_Nhom6.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string PaymentMethod {  get; set; }
        public string DeliveryStatus { get; set; }
        public string DeliveryPerson { get; set; }
        public DateTime DeliveryDate { get; set; }

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
