using Microsoft.Extensions.Hosting;
using System;

namespace App.Shared
{
    public static class ServiceProviderContainer
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static T GetService<T>()
        {
            return (T)ServiceProvider.GetService(typeof(T));
        }

    }
}
