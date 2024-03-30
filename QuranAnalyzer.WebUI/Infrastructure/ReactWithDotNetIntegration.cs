using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using QuranAnalyzer.WebUI.Layouts;
using QuranAnalyzer.WebUI.Pages;
using QuranAnalyzer.WebUI.Pages.PageMainWindow;
using ReactWithDotNet.UIDesigner;

namespace QuranAnalyzer.WebUI;

static class ReactWithDotNetIntegration
{
    public static void ConfigureReactWithDotNet(this WebApplication app)
    {
        app.MapGet("/", HomePage);

        app.MapGet("/" + nameof(PageCountInRange), httpContext => WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageCountInRange)));
        app.MapGet("/" + nameof(PageVerseFilter), httpContext => WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageVerseFilter)));
        app.MapGet("/" + nameof(PageChapterNameContainsSAD), httpContext => WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageChapterNameContainsSAD)));

        RegisterSpecificEndpoints(app);
    }

    static void BeforeSerializeElementToClient(ReactContext context, Element element, Element parent)
    {
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

    static Task HomePage(HttpContext httpContext)
    {
        return WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageMainWindowView));
    }

    static Task OnReactContextCreated(HttpContext httpContext, ReactContext reactContext)
    {
        KeyForQueryString[reactContext] = httpContext.Request.QueryString.ToString();
        return Task.CompletedTask;
    }

    [Conditional("DEBUG")]
    static void RegisterReactWithDotNetDevelopmentTools(WebApplication app)
    {
        app.MapGet("/$", httpContext =>
        {
            DesignMode = true;

            return WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(ReactWithDotNetDesigner));
        });
        app.MapGet("/" + nameof(ReactWithDotNetDesignerComponentPreview), httpContext =>
        {
            DesignMode= true;

            return WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(ReactWithDotNetDesignerComponentPreview));
        });
    }

    static void RegisterSpecificEndpoints(WebApplication app)
    {
        RegisterReactWithDotNetDevelopmentTools(app);
        app.MapPost($"/{nameof(HandleReactWithDotNetRequest)}", HandleReactWithDotNetRequest);
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
            QueryString                    = httpContext.Request.QueryString.ToString(),
            OnReactContextCreated          = OnReactContextCreated,
            BeforeSerializeElementToClient = BeforeSerializeElementToClient
        });
    }
}