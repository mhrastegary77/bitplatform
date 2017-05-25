﻿using System;
using Bit.Owin.Contracts.Metadata;

namespace Bit.Owin.Implementations.Metadata
{
    public class DefaultProjectMetadataBuilder : DefaultMetadataBuilder, IProjectMetadataBuilder
    {
        public virtual IProjectMetadataBuilder AddProjectMetadata(ProjectMetadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException(nameof(metadata));

            AllMetadata.Add(metadata);

            return this;
        }
    }
}
