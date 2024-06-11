using System;

namespace Web_ASM_Nhom6.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId {  get; set; }
        public int UserId {  get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
