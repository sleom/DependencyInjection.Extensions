﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Neleus.DependencyInjection.Extensions
{
    internal class ServiceByNameFactory<TService> : IServiceByNameFactory<TService>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<string, Type> _registrations;

        public ServiceByNameFactory(IServiceProvider serviceProvider, IDictionary<string, Type> registrations)
        {
            _serviceProvider = serviceProvider;
            _registrations = registrations;
        }

        public TService GetByName(string name)
        {
            Type implementationType;
            if (!_registrations.TryGetValue(name, out implementationType))
                throw new ArgumentException("No service is registered for given name");
            return (TService)_serviceProvider.GetService(implementationType);
        }

        public TService GetByName(string name, params object[] args)
        {
            if (!_registrations.TryGetValue(name, out Type implementationType))
                throw new ArgumentException("No service is registered for given name");
            return (TService)ActivatorUtilities.CreateInstance(_serviceProvider, implementationType, args);
        }
    }
}
