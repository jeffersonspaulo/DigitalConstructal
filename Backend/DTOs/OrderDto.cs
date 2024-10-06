namespace DigitalConstructalWeb.DTOs
{
    public class OrderDto
    {
        public int UserLoginId { get; set; }
        public int SellerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderStatusId { get; set; }
    }
}
