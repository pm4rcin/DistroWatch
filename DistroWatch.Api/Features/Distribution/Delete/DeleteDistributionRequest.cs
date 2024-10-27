namespace DistroWatch.Api.Features.Distribution.Delete;

public record DeleteDistributionRequest
{
    public Guid Id { get; init; }
}
