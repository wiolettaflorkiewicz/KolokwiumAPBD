using System;
using System.Collections.Generic;

namespace KolokwiumDF.Models;

public partial class Payment
{
    public int IdPayment { get; set; }

    public DateTime Date { get; set; }

    public int IdClient { get; set; }

    public int IdSubscription { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Subscription IdSubscriptionNavigation { get; set; } = null!;
}
