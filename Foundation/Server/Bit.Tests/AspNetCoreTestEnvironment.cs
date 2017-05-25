﻿using Bit.Core.Contracts;
using Bit.Test;
using Bit.Test.Server;
using Bit.Tests.Api.Implementations;

namespace Bit.Tests
{
    public class AspNetCoreTestEnvironment : TestEnvironment
    {
        public AspNetCoreTestEnvironment(TestEnvironmentArgs args = null)
            : base(args)
        {

        }

        protected override ITestServer GetTestServer(TestEnvironmentArgs args)
        {
            if (args.UseRealServer == true)
                return new AspNetCoreSelfHostTestServer();
            else
                return new AspNetCoreEmbeddedTestServer();
        }

        protected override IDependenciesManagerProvider GetDependenciesManagerProvider(TestEnvironmentArgs args)
        {
            return args.CustomDependenciesManagerProvider ?? new FoundationAspNetCoreTestServerDependenciesManagerProvider(args);
        }
    }
}
