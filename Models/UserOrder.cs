using Microsoft.EntityFrameworkCore;

namespace Bit2C
{
   
    public class UserOrder
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string BuySell { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        
    }
}
