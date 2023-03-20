﻿using System.IO.Compression;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace Greenlight.Data.Configurations.ConfigureServices
{
    public static class MvcConfig
    {
        public static void AddJsonMvcConfigure(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault);
        }
    }
}