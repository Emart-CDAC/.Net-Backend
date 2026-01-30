using System;
using System.Collections.Generic;

namespace Emart_DotNet.Models;

public partial class SubCategory
{
    public int SubCategoryId { get; set; }

    public string? Brand { get; set; }

    public ulong? Sponsors { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
