using System.IO.Compression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;

namespace QuranAnalyzer.WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var services = builder.Services;

        // C O N F I G U R E     S E R V I C E S
        services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<GzipCompressionProvider>();
        });

        // C O N F I G U R E     A P P L I C A T I O N
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles(new StaticFileOptions
        {
            RequestPath = new("/wwwroot"),
            OnPrepareResponse = ctx =>
            {
                var maxAge = TimeSpan.FromDays(365).TotalSeconds;

                ctx.Context.Response.Headers.Append(HeaderNames.CacheControl, $"max-age={maxAge},public,immutable");
            }
        });

        app.UseResponseCompression();

        app.ConfigureReactWithDotNet();

        app.Run();
    }
}