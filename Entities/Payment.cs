namespace DigitalConstructal.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } // Ex: CreditCard, PayPal, etc.
        public string PaymentStatus { get; set; } // Ex: Pending, Completed, Failed.

        public Order Order { get; set; } // Relacionamento com Order.
    }

}
