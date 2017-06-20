namespace Neleus.DependencyInjection.Extensions
{
    /// <summary>
    /// Provides instances of registered services by name
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IServiceByNameFactory<out TService>
    {
        /// <summary>
        /// Provides instance of registered service by name
        /// </summary>
        TService GetByName(string name);

        /// <summary>
        /// Provides instance of registered service by name using args to create
        /// </summary>
        TService GetByName(string name, params object[] args);
    }
}