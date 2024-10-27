namespace DistroWatch.Api.Features.Distribution.Get;

public class GetAllDistributionsResponse
{
    public IEnumerable<DistributionResponse> Distributions { get; init; } = Enumerable.Empty<DistributionResponse>();
}
