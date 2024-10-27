using DistroWatch.Api.Data;
using DistroWatch.Api.Domain;
using DistroWatch.Api.Domain.Common;

namespace DistroWatch.Api.Mapping;

public static class DtoToDomainMapper
{
    public static Distribution ToDistribution(this DistributionDto distributionDto)
    {
        return new Distribution
        {
            Id = DistributionId.From(Guid.Parse(distributionDto.Id)),
            Creator = Creator.From(distributionDto.Creator),
            Name = Name.From(distributionDto.Name),
            WebPageURL = WebPageURL.From(distributionDto.WebPageURL),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(distributionDto.DateOfBirth))
        };
    }
}
