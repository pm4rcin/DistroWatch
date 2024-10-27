using DistroWatch.Api.Domain;
using DistroWatch.Api.Domain.Common;
using DistroWatch.Api.Features.Distribution.Create;
using DistroWatch.Api.Features.Distribution.Update;

namespace DistroWatch.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Distribution ToDistribution(this CreateDistributionRequest request)
    {
        return new Distribution
        {
            Id = DistributionId.From(Guid.NewGuid()),
            Creator = Creator.From(request.Creator),
            Name = Name.From(request.Name),
            WebPageURL = WebPageURL.From(request.WebPageURL),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
    public static Distribution ToDistribution(this UpdateDistributionRequest request)
    {
        return new Distribution
        {
            Id = DistributionId.From(request.Id),
            Creator = Creator.From(request.Creator),
            Name = Name.From(request.Name),
            WebPageURL = WebPageURL.From(request.WebPageURL),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
}
