namespace DigitalConstructalWeb.Entities
{
    public class ContentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
