namespace DigitalConstructal.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ContentTypeId { get; set; }
        public string Briefing { get; set; }
        public string Brainstorm { get; set; }

        public ContentType ContentType { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
