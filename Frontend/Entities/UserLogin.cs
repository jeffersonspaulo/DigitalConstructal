namespace DigitalConstructalWeb.Entities
{
  public class UserLogin
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? Role { get; set; } = null;
    public string? GoogleId { get; set; } = null;

    public ICollection<AccessLog> AccessLogs { get; set; }
  }
}
