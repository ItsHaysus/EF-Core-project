namespace SwimSchool.Api.Entities;

public sealed class SwimClass
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Capacity { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
