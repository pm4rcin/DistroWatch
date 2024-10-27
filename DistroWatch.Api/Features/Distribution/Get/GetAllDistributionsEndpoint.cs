using DistroWatch.Api.Mapping;
using DistroWatch.Api.Services;

using Microsoft.AspNetCore.Authorization;

namespace DistroWatch.Api.Features.Distribution.Get;

[HttpGet("distributions"), AllowAnonymous]
public sealed class GetAllDistributionsEndpoint : EndpointWithoutRequest<GetAllDistributionsResponse>
{
    private readonly IDistributionService _distributionService;

    public GetAllDistributionsEndpoint(IDistributionService distributionService)
    {
        _distributionService = distributionService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var distributions = await _distributionService.GetAllAsync();
        var distributionsResponse = distributions.ToDistributionsResponse();
        await SendOkAsync(distributionsResponse, ct);

    }
}
