using ValueOf;

namespace DistroWatch.Api.Domain.Common;

public class Name : ValueOf<string, Name>
{
    protected override void Validate()
    {
        if (Value == string.Empty)
        {
            throw new ArgumentException("Name of distribution cannot be empty", nameof(Name));
        }
    }
}
