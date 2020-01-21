using Microsoft.AspNetCore.Rewrite;
using System;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods for the ToLowerUrlRequirement middleware.
    /// </summary>
    public static class ToLowerUrlRequirementBuilderExtensions
    {
        /// <summary>
        /// Adds middleware for redirecting upper chars url Requests to lower chars url.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance this method extends.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> for ToLowerUrlRedirection.</returns>
        public static IApplicationBuilder UseToLowerUrlRedirection(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var options = new RewriteOptions();
            options.AddRedirectToLowerUrl();
            app.UseRewriter(options);
            return app;
        }
    }
}
