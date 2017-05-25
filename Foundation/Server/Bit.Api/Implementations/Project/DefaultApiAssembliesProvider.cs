﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Bit.Api.Contracts.Project;

namespace Bit.Api.Implementations.Project
{
    public class DefaultApiAssembliesProvider : IApiAssembliesProvider
    {
        protected DefaultApiAssembliesProvider()
        {

        }

        private readonly IEnumerable<Assembly> _assemblies;

        public DefaultApiAssembliesProvider(IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null)
                throw new ArgumentNullException(nameof(assemblies));

            _assemblies = assemblies;
        }

        public virtual IEnumerable<Assembly> GetApiAssemblies()
        {
            return _assemblies;
        }
    }
}
