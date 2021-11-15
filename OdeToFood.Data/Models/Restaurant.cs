﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Data.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Display(Name ="Type of food")]
        public CuisineType Cuisine { get; set; }

    }
}
