using DistroWatch.Api.Domain;
using DistroWatch.Api.Features.Distribution.Get;

namespace DistroWatch.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static DistributionResponse ToDistributionResponse(this Distribution distribution)
    {
        return new DistributionResponse
        {
            Id = distribution.Id.Value,
            Creator = distribution.Creator.Value,
            Name = distribution.Name.Value,
            WebPageURL = distribution.WebPageURL.Value,
            DateOfBirth = distribution.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }
    public static GetAllDistributionsResponse ToDistributionsResponse(this IEnumerable<Distribution> distributions)
    {
        return new GetAllDistributionsResponse
        {
            Distributions = distributions.Select(x => new DistributionResponse
            {
                Id = x.Id.Value,
                Creator = x.Creator.Value,
                Name = x.Name.Value,
                WebPageURL = x.WebPageURL.Value,
                DateOfBirth = x.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
            })
        };
    }
}
