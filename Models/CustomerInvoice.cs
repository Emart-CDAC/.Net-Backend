using System;
using System.Collections.Generic;

namespace Emart_DotNet.Models;

public partial class CustomerInvoice
{
    public int InvoiceId { get; set; }

    public string? BillingAddress { get; set; }

    public string? DeliveryType { get; set; }

    public decimal? DiscountAmount { get; set; }

    public int EpointsBalance { get; set; }

    public int EpointsEarned { get; set; }

    public int EpointsUsed { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? ShippingAddress { get; set; }

    public decimal? TaxAmount { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Customer? User { get; set; }
}
