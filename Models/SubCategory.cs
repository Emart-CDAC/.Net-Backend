using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_DotNet.Models;

[Table("sub_category")]
public partial class SubCategory
{
    [Key]
    [Column("sub_category_id")]
    public int SubCategoryId { get; set; }

    [Column("brand")]
    [StringLength(255)]
    public string? Brand { get; set; }

    [Column("sponsors")]
    public bool Sponsors { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("SubCategories")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Subcategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
