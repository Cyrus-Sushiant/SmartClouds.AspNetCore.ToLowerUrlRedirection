using Microsoft.AspNetCore.Rewrite;

namespace Microsoft.AspNetCore.Builder
{
    public static class RewriteOptionsExtensions
    {
        public static RewriteOptions AddRedirectToLowerUrl(this RewriteOptions options, bool excludeQueryString = false)
        {
            if (excludeQueryString)
                options.Rules.Add(new RedirectToToLowerExcludeQueryStringRule());
            else
                options.Rules.Add(new RedirectToToLowerRule());

            return options;
        }
    }
}
