namespace DistroWatch.Api.Features.Distribution.Create;

public class CreateDistributionRequest
{
    public required string Name { get; init; }
    public required string Creator { get; init; }
    public required DateTime DateOfBirth { get; init; }
    public required string WebPageURL { get; init; }
}
