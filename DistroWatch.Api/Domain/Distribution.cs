using DistroWatch.Api.Domain.Common;

namespace DistroWatch.Api.Domain;

public class Distribution
{
    public DistributionId Id { get; init; } = DistributionId.From(Guid.NewGuid());
    public Name Name { get; init; } = default!;
    public Creator Creator { get; init; } = default!;
    public DateOfBirth DateOfBirth { get; init; } = default!;
    public WebPageURL WebPageURL { get; init; } = default!;
}
