using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebAsp8RazorDemo.Models.ViewModels
{
    public enum ArticleType { Food, Other }

    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Too short name")]
        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = " Too long name, do not exceed {1}")]
        public string? Name { get; set; }        

        [Range(0, double.MaxValue, ErrorMessage = "Price must be at least 0")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        public ArticleType ArticleType { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }

        public ArticleViewModel()
        {

        }

        public ArticleViewModel(int id, string name, decimal price, DateTime expirationDate, ArticleType articleType, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
            ArticleType = articleType;
            Quantity = quantity;
        }
    }
}
