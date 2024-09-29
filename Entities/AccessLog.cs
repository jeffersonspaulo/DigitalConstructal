namespace DigitalConstructal.Entities
{
    public class AccessLog
    {
        public int AccessLogId { get; set; }
        public int? UserLoginId { get; set; }
        public DateTime AccessTime { get; set; } = DateTime.Now;
        public string AccessType { get; set; }
        public string Description { get; set; }

        public UserLogin UserLogin { get; set; }
    }
}
