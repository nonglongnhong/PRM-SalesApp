﻿namespace ProductService.API.Models;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = default!;
    public string? BriefDescription { get; set; }
    public string? FullDescription { get; set; }
    public string? TechnicalSpecifications { get; set; }
    public decimal Price { get; set; }
    public string? ImageURL { get; set; }

    public int? CategoryID { get; set; }
    public Category? Category { get; set; }
}
