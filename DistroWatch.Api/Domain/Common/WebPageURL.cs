using System.Text.RegularExpressions;

using ValueOf;

namespace DistroWatch.Api.Domain.Common;

public class WebPageURL : ValueOf<string, WebPageURL>
{
    private static readonly Regex WebPageURLRegex = new(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    protected override void Validate()
    {
        if (!WebPageURLRegex.IsMatch(Value))
        {
            string message = $"{Value} is not valid URL";
        }
    }
}
