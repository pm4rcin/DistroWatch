using FluentValidation;
using FluentValidation.Results;

using ValueOf;

namespace DistroWatch.Api.Domain.Common;

public class DateOfBirth : ValueOf<DateOnly, DateOfBirth>
{
    protected override void Validate()
    {
        if (Value > DateOnly.FromDateTime(DateTime.Now))
        {
            const string message = "Date must not be in the future";
            throw new ValidationException(message, new[]{
                    new ValidationFailure(nameof (DateOfBirth),message)
                    });
        }
    }
}
