namespace Identity.Models
{
    public class OrderItem
    {
        public OrderItem() { }

        public OrderItem(Article article, int quantity)
        {
            Article = article;
            ArticleId = article.Id;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int Quantity { get; set; }
    }
}