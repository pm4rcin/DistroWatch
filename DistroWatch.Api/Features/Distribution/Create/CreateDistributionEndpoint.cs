using DistroWatch.Api.Features.Distribution.Get;
using DistroWatch.Api.Mapping;
using DistroWatch.Api.Services;

using Microsoft.AspNetCore.Authorization;

namespace DistroWatch.Api.Features.Distribution.Create;

[HttpPost("distributions"), AllowAnonymous]
public sealed class CreateDistributionEndpoint
    : Endpoint<CreateDistributionRequest, DistributionResponse>
{
    private readonly IDistributionService _distributionService;

    public CreateDistributionEndpoint(IDistributionService distributionService)
    {
        _distributionService = distributionService;
    }

    public override async Task HandleAsync(CreateDistributionRequest req, CancellationToken ct)
    {
        var distribution = req.ToDistribution();

        await _distributionService.CreateAsync(distribution);

        var distributionResponse = distribution.ToDistributionResponse();
        await SendCreatedAtAsync<GetDistributionEndpoint>(new { Id = distribution.Id.Value }, distributionResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
