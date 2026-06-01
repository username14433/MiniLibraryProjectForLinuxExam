namespace LinuxAdminExamApi.Models;

public class Reader
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
