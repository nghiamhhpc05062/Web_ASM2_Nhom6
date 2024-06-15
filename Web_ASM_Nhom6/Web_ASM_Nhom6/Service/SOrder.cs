using System.Collections.Generic;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Service
{
    public class SOrder
    {
        public int Total {  get; set; }
        public List<SProdOrder> Products {  get; set; }
    }
}
