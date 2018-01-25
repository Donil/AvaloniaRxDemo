using System;

namespace AvaloniaRxDemo
{
    public static class ServiceLocator
    {
        private static IServiceProvider serviceProvider;

        public static void Init(IServiceProvider serviceProvider)
        {
            ServiceLocator.serviceProvider = serviceProvider;
        }

        public static T Resolve<T>()
            where T: class
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
