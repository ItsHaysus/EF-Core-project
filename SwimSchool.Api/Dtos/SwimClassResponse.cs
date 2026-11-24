namespace SwimSchool.Api.Dtos;

/// <summary>Represents a swim class and its remaining enrollment capacity.</summary>
public sealed record SwimClassResponse(
    int Id,
    string Name,
    int Capacity,
    int SpotsRemaining);
