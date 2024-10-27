using DistroWatch.Api.Services;

using Microsoft.AspNetCore.Authorization;

namespace DistroWatch.Api.Features.Distribution.Delete;

[HttpDelete("distributions/{id:guid}"), AllowAnonymous]
public class DeleteDistributionEndpoint : Endpoint<DeleteDistributionRequest>
{
    private readonly IDistributionService _distributionService;

    public DeleteDistributionEndpoint(IDistributionService distributionService)
    {
        _distributionService = distributionService;
    }

    public override async Task HandleAsync(DeleteDistributionRequest req, CancellationToken ct)
    {
        var deleted = await _distributionService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        await SendNoContentAsync(ct);
    }
}
