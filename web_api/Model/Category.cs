﻿namespace web_api.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public List<Meal>? Meals { get; set; }
    }
}