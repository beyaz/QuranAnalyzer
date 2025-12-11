using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using QuranAnalyzer.WebUI.Layouts;
using ReactWithDotNet.UIDesigner;

namespace QuranAnalyzer.WebUI;

static class ReactWithDotNetIntegration
{
    public static void ConfigureReactWithDotNet(this WebApplication app)
    {
        RequestHandlerPath = $"/{nameof(HandleReactWithDotNetRequest)}";

        app.UseMiddleware<ReactWithDotNetJavaScriptFiles>();
        
        var routes = RouteHelper.GetRoutesFrom(typeof(ReactWithDotNetIntegration).Assembly);

        app.Use(async (httpContext, next) =>
        {
            var path = httpContext.Request.Path.Value ?? string.Empty;

            if (path == RequestHandlerPath)
            {
                await HandleReactWithDotNetRequest(httpContext);
                return;
            }
            
            if (routes.TryGetValue(path, out var route))
            {
                await WriteHtmlResponse(httpContext, typeof(MainLayout), route.Page);
                return;
            }

            #if DEBUG
            if (path == ReactWithDotNetDesigner.UrlPath)
            {
                await WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(ReactWithDotNetDesigner));
                return;
            }
            #endif

            await next();
        });
    }

    static Task BeforeSerializeElementToClient(ReactContext context, Element element, Element parent)
    {
        return Task.CompletedTask;
    }

    static Task HandleReactWithDotNetRequest(HttpContext httpContext)
    {
        httpContext.Response.ContentType = "application/json; charset=utf-8";

        return ProcessReactWithDotNetComponentRequest(new()
        {
            HttpContext                    = httpContext,
            OnReactContextCreated          = OnReactContextCreated,
            BeforeSerializeElementToClient = BeforeSerializeElementToClient
        });
    }

    static Task OnReactContextCreated(ReactContext reactContext)
    {
        KeyForQueryString[reactContext] = reactContext.HttpContext.Request.QueryString.ToString();
        return Task.CompletedTask;
    }

    static Task WriteHtmlResponse(HttpContext httpContext, Type layoutType, Type mainContentType)
    {
        httpContext.Response.ContentType = "text/html; charset=UTF-8";

        httpContext.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
        httpContext.Response.Headers[HeaderNames.Expires]      = "0";
        httpContext.Response.Headers[HeaderNames.Pragma]       = "no-cache";

        return ProcessReactWithDotNetPageRequest(new()
        {
            LayoutType                     = layoutType,
            MainContentType                = mainContentType,
            HttpContext                    = httpContext,
            OnReactContextCreated          = OnReactContextCreated,
            BeforeSerializeElementToClient = BeforeSerializeElementToClient
        });
    }
}