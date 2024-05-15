namespace Bit2C
{
    public class UserOrderDTO
    {
       
        public string BuySell { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }

        public UserOrderDTO(double amount, double price, string buySell)
        {
            
            Amount = amount;
            Price = price;
            BuySell = buySell;

        }
    }
}
