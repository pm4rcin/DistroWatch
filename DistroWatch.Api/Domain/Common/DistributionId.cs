using ValueOf;

namespace DistroWatch.Api.Domain.Common;

public class DistributionId : ValueOf<Guid, DistributionId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
        {
            throw new ArgumentException("DustributionId cannot be empty", nameof(DistributionId));
        }
    }
}
