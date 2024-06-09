using System;
using System.Collections.Generic;

namespace KolokwiumDF.Models;

public partial class Discount
{
    public int IdDiscount { get; set; }

    public int Value { get; set; }

    public int IdSubscription { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int IdClient { get; set; } 

    public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
}
