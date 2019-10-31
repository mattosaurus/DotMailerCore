using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotMailerCore.Clients
{
    public static class DotMailerCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddDotMailer(this IServiceCollection collection,
            Action<DotMailerCoreOptions> setupAction)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            collection.Configure(setupAction);
            return collection.AddSingleton<IDotMailerCoreClient, DotMailerCoreClient>();
        }
    }
}
