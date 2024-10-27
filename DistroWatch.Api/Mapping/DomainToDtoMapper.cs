using DistroWatch.Api.Data;
using DistroWatch.Api.Domain;

namespace DistroWatch.Api.Mapping;

public static class DomainToDtoMapper
{
    public static DistributionDto ToDistributionDto(this Distribution distribution)
    {
        return new DistributionDto
        {
            Id = distribution.Id.Value.ToString(),
            Creator = distribution.Creator.Value,
            Name = distribution.Name.Value,
            DateOfBirth = distribution.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue),
            WebPageURL = distribution.WebPageURL.Value
        };
    }
}
