namespace RazorCookies.Models
{
    public class CartItem
    {
        public CartItem(Article article, int quantity)
        {
            Article = article;
            Quantity = quantity;
        }

        public Article Article { get; set; }
        public int Quantity { get; set; }
    }
}
