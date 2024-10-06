namespace DigitalConstructalWeb.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserLoginId { get; set; }
        public int SellerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public UserLogin Customer { get; set; }
        public Seller Seller { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
