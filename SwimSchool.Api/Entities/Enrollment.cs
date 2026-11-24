namespace SwimSchool.Api.Entities;

public sealed class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public int SwimClassId { get; set; }

    public SwimClass SwimClass { get; set; } = null!;
}
