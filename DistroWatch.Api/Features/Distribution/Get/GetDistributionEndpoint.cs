using DistroWatch.Api.Mapping;
using DistroWatch.Api.Services;

using Microsoft.AspNetCore.Authorization;

namespace DistroWatch.Api.Features.Distribution.Get;

[HttpGet("distributions/{id:guid}"), AllowAnonymous]
public class GetDistributionEndpoint : Endpoint<GetDistributionRequest, DistributionResponse>
{
    private readonly IDistributionService _distributionService;

    public GetDistributionEndpoint(IDistributionService distributionService)
    {
        _distributionService = distributionService;
    }
    public override async Task HandleAsync(GetDistributionRequest req, CancellationToken ct)
    {
        var distribution = await _distributionService.GetAsync(req.Id);
        if (distribution is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        var distributionResponse = distribution.ToDistributionResponse();
        await SendOkAsync(distributionResponse, ct);
    }
}
