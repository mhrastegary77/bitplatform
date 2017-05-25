﻿using System;
using System.Linq;
using Bit.Core.Contracts;
using Bit.Owin.Implementations;
using Bit.Test.Core.Implementations;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bit.Tests.Api
{
    [TestClass]
    public class AppStartupTests
    {
        [TestMethod]
        [TestCategory("Hosting")]
        [ExpectedException(typeof(ObjectDisposedException))]
        public virtual void ContainerMustBeDisposedFinally()
        {
            using (new TestEnvironment())
            {

            }

            DefaultDependencyManager.Current.Resolve<IDependencyManager>();
        }

        [TestMethod]
        [TestCategory("Hosting")]
        public virtual void AllOnAppEndEventsMustBeCalledAtEnd()
        {
            using (new TestEnvironment())
            {

            }

            foreach (IAppEvents appEvents in TestDependencyManager.CurrentTestDependencyManager.Objects
                .OfType<IAppEvents>().ToList())
            {
                A.CallTo(() => appEvents.OnAppEnd())
                    .MustHaveHappened(Repeated.Exactly.Once);
            }
        }

        [TestMethod]
        [TestCategory("Hosting")]
        public virtual void AllOnAppStartsMustBeCalledOnceAtStartup()
        {
            using (new TestEnvironment())
            {
                foreach (IAppEvents appEventse in
                    TestDependencyManager.CurrentTestDependencyManager.Objects.OfType<IAppEvents>().ToList())
                {
                    A.CallTo(() => appEventse.OnAppStartup())
                        .MustHaveHappened(Repeated.Exactly.Once);
                }
            }
        }
    }
}
