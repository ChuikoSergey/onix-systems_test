﻿using DataGraph.Core;
using DataGraph.Core.Services.DataScheme;
using DataGraph.Data;
using DataGraph.Domain.Services.DataScheme;

namespace DataGraph.Web.Extensions;

public static class ServiceCollectionExtenstions
{
    public static void AddNonDataService(this WebApplicationBuilder builder)
    {
        builder.Services.Add(new ServiceDescriptor(typeof(IDataSchemeProvider), typeof(DataSchemeProvider), ServiceLifetime.Transient));
        builder.Services.Add(new ServiceDescriptor(typeof(IDataSchemaService), typeof(DataSchemeService), ServiceLifetime.Transient));
    }
}
