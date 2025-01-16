namespace Identity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalCost { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}