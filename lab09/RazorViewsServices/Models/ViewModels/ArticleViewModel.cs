﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebAsp8RazorDemo.Models.ViewModels
{
    public enum ArticleType { Dairy, Meat, Fish, Fruit, Vegetable, Bakery, Cutlery }

    public class ArticleViewModel
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

        public ArticleType ArticleType { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }

        public ArticleViewModel()
        {

        }

        public ArticleViewModel(int id, string name, decimal price, ArticleType articleType, int quantity, DateTime? expirationDate = null)
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
