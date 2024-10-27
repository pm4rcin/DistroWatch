namespace DistroWatch.Api.Features.Distribution.Update;

public class UpdateDistributionRequest
{
    public Guid Id { get; init; }
    public string Creator { get; init; } = default!;
    public string Name { get; init; } = default!;
    public DateTime DateOfBirth { get; init; }
    public string WebPageURL { get; init; } = default!;
}
