using DistroWatch.Api.Features.Distribution.Get;
using DistroWatch.Api.Mapping;
using DistroWatch.Api.Services;

using Microsoft.AspNetCore.Authorization;

namespace DistroWatch.Api.Features.Distribution.Update;

[HttpPut("distributions/{id:guid}"), AllowAnonymous]
public class UpdateDistributionEndpoint : Endpoint<UpdateDistributionRequest, DistributionResponse>
{
    private readonly IDistributionService _distributionService;

    public UpdateDistributionEndpoint(IDistributionService distributionService)
    {
        _distributionService = distributionService;
    }
    public override async Task HandleAsync(UpdateDistributionRequest req, CancellationToken ct)
    {
        var exisitingDistribution = await _distributionService.GetAsync(req.Id);

        if (exisitingDistribution is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var distribution = req.ToDistribution();
        await _distributionService.UpdateAsync(distribution);

        var distributionResponse = distribution.ToDistributionResponse();
        await SendOkAsync(distributionResponse, ct);
    }
}
