namespace KolokwiumDF.DTOs
{
    public class PaymentDto
    {
        public int IdClient { get; set; }
        public int IdSubscription { get; set; }
        public decimal Amount { get; set; }
    }
}
