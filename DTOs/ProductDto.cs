namespace DigitalConstructal.DTOs
{
    public class ProductDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AssociatedDomain { get; set; }
        public int? IncomingBacklink { get; set; }
        public int? MonthlyEstimatedTraffic { get; set; }
        public int? IndexedPage { get; set; }
        public string LinkType { get; set; }
        public int? DomainAuthority { get; set; }
        public int? PageAuthority { get; set; }
    }
}
