using System;
using System.Collections.Generic;

namespace Emart_DotNet.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DeliveryType? DeliveryType { get; set; }
    public int? EpointsEarned { get; set; }

    public int? EpointsUsed { get; set; }

    public DateTime? OrderDate { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
    public OrderStatus Status { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? AddressId { get; set; }

    public int? CartId { get; set; }

    public int? UserId { get; set; }

    public int? StoreId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; } = new List<CustomerInvoice>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Store? Store { get; set; }

    public virtual Customer? User { get; set; }
}
