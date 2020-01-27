using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Linq;

namespace Microsoft.AspNetCore.Builder
{
    public class RedirectToToLowerRule : IRule
    {
        public virtual void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;

            if (req.Method != "GET" || !(req.Host.Value.Any(ch => char.IsUpper(ch)) || req.Path.Value.Any(ch => char.IsUpper(ch)) || req.QueryString.Value.Any(ch => char.IsUpper(ch))))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            var newUrl = UriHelper.BuildAbsolute(req.Scheme, req.Host, req.PathBase, req.Path, req.QueryString).ToLower();
            var response = context.HttpContext.Response;
            response.StatusCode = 301;
            response.Headers[HeaderNames.Location] = newUrl;
            context.Result = RuleResult.EndResponse;
        }
    }
}
