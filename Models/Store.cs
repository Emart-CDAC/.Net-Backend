using System;
using System.Collections.Generic;

namespace Emart_DotNet.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string Address { get; set; } = null!;

    public ulong? Availability { get; set; }

    public string City { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string StoreName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
