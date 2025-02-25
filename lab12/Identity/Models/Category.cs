﻿using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Too short name")]
        [MaxLength(50, ErrorMessage = "Too long name, do not exceed {1}")]
        public string Name { get; set; }

        public Category()
        {
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
