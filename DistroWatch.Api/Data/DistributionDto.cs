namespace DistroWatch.Api.Data;

public class DistributionDto
{
    public string Id { get; init; } = default!;
    public string Creator { get; init; } = default!;
    public string Name { get; init; } = default!;
    public DateTime DateOfBirth { get; init; }
    public string WebPageURL { get; init; } = default!;
}
