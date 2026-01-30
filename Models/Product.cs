using System;
using System.Collections.Generic;

namespace Emart_DotNet.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? AvailableQuantity { get; set; }

    public string? Description { get; set; }

    public decimal? DiscountPercent { get; set; }

    public decimal? EcardPrice { get; set; }

    public string? ProductImageUrl { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal NormalPrice { get; set; }

    public int? StoreId { get; set; }

    public int? SubcategoryId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual SubCategory? Subcategory { get; set; }
}
