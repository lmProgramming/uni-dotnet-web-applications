namespace Identity.Models
{
    public class OrderModel
    {
        public List<OrderItem> CartItems { get; set; } = new List<OrderItem>();
        public decimal TotalCost { get; set; }
    }
}
