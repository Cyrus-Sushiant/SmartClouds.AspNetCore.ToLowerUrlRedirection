using Microsoft.AspNetCore.Rewrite;

namespace Microsoft.AspNetCore.Builder
{
    public static class RewriteOptionsExtensions
    {
        public static RewriteOptions AddRedirectToLowerUrl(this RewriteOptions options)
        {
            options.Rules.Add(new RedirectToToLowerRule());
            return options;
        }
    }
}
