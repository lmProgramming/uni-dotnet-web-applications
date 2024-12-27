using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class Article
    {
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "Too short name")]
        [Display(Name = "Product Name")]
        [MaxLength(30, ErrorMessage = " Too long name, do not exceed {1}")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be at least 0")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        public int CategoryId { get; set; } 
        public Category Category { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }

        public string? ImageName { get; set; }

        public Article()
        {

        }

        public Article(int id, string name, decimal price, Category category, int quantity, DateTime? expirationDate=null, string? imageName=null)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpirationDate = expirationDate;
            Category = category;
            Quantity = quantity;
            ImageName = imageName;
        }
    }
}
