using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using QuranAnalyzer.WebUI.Layouts;
using QuranAnalyzer.WebUI.Pages;
using QuranAnalyzer.WebUI.Pages.PageMainWindow;
using ReactWithDotNet.UIDesigner;

namespace QuranAnalyzer.WebUI;

static class ReactWithDotNetIntegration
{
    public static void ConfigureReactWithDotNet(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", HomePage);
        endpoints.MapPost("/" + nameof(HandleReactWithDotNetRequest), HandleReactWithDotNetRequest);
        
        endpoints.MapGet("/"+nameof(PageCountInRange), httpContext =>  WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageCountInRange)));
        endpoints.MapGet("/"+nameof(PageVerseFilter), httpContext =>  WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageVerseFilter)));

#if DEBUG // this two endpoints should use only development mode

        endpoints.MapGet("/" + nameof(ReactWithDotNetDesigner), async httpContext =>
        {
            ReactWithDotNetDesigner.IsAttached = true;

            await WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(ReactWithDotNetDesigner));
        });
        endpoints.MapGet("/" + nameof(ReactWithDotNetDesignerComponentPreview), async httpContext =>
        {
            ReactWithDotNetDesigner.IsAttached = true;

            await WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(ReactWithDotNetDesignerComponentPreview));
        });
#endif
    }

    static void BeforeSerializeElementToClient(ReactContext context, Element element, Element parent)
    {
    }

    static async Task HandleReactWithDotNetRequest(HttpContext httpContext)
    {
        httpContext.Response.ContentType = "application/json; charset=utf-8";

        var jsonText = await CalculateRenderInfo(new CalculateRenderInfoInput
        {
            HttpContext                    = httpContext,
            OnReactContextCreated          = OnReactContextCreated,
            BeforeSerializeElementToClient = BeforeSerializeElementToClient
        });

        await httpContext.Response.WriteAsync(jsonText);
    }

    static async Task HomePage(HttpContext httpContext)
    {
        await WriteHtmlResponse(httpContext, typeof(MainLayout), typeof(PageMainWindowView));
    }

    static Task OnReactContextCreated(HttpContext httpContext, ReactContext reactContext)
    {
        KeyForQueryString[reactContext] = httpContext.Request.QueryString.ToString();
        return Task.CompletedTask;
    }

    static async Task WriteHtmlResponse(HttpContext httpContext, Type layoutType, Type mainContentType)
    {
        httpContext.Response.ContentType = "text/html; charset=UTF-8";

        httpContext.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
        httpContext.Response.Headers[HeaderNames.Expires]      = "0";
        httpContext.Response.Headers[HeaderNames.Pragma]       = "no-cache";

        var html = await CalculateFirstRender(new CalculateFirstRenderInput
        {
            LayoutType                     = layoutType,
            MainContentType                = mainContentType,
            HttpContext                    = httpContext,
            QueryString                    = httpContext.Request.QueryString.ToString(),
            OnReactContextCreated          = OnReactContextCreated,
            BeforeSerializeElementToClient = BeforeSerializeElementToClient
        });

        await httpContext.Response.WriteAsync(html);
    }
}