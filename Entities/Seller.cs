namespace DigitalConstructal.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public int UserLoginId { get; set; }
        public string StoreName { get; set; }
        public DateTime RegisteredAt { get; set; }

        public UserLogin UserLogin { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

}
