﻿using System;
using System.Reflection;
using System.Web.OData.Builder;
using Bit.Api.ApiControllers;
using Bit.Api.Contracts.Project;
using Bit.Api.Middlewares.WebApi.OData.Contracts;

namespace Bit.Api.Implementations.Project
{
    public class FoundationEdmModelProvider : IEdmModelProvider
    {
        private readonly IAutoEdmBuilder _autoEdmBuilder;

        public FoundationEdmModelProvider(IAutoEdmBuilder autoEdmBuilder)
        {
            if (autoEdmBuilder == null)
                throw new ArgumentNullException(nameof(autoEdmBuilder));

            _autoEdmBuilder = autoEdmBuilder;
        }

        protected FoundationEdmModelProvider()
        {

        }

        public virtual void BuildEdmModel(ODataModelBuilder edmModelBuilder)
        {
            _autoEdmBuilder.AutoBuildEdmFromTypes(new[] { typeof(ClientsLogsController).GetTypeInfo(), typeof(JobsInfoController).GetTypeInfo(), typeof(UsersSettingsController).GetTypeInfo() }, edmModelBuilder);
        }

        public virtual string GetEdmName()
        {
            return "Bit";
        }
    }
}