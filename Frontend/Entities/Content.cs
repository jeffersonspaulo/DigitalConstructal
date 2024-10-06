namespace DigitalConstructalWeb.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProjectId { get; set; }
        public string Body { get; set; }

        public Project Project { get; set; }
    }
}
