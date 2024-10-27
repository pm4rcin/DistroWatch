using ValueOf;


namespace DistroWatch.Api.Domain.Common;

public class Creator : ValueOf<string, Creator>
{
    protected override void Validate()
    {
        if (Value == string.Empty)
        {
            throw new ArgumentException("DustributionId cannot be empty", nameof(Creator));
        }
    }
}
