﻿namespace QuranAnalyzer.WebUI.Layouts;

class MainLayout : ReactPureComponent, IPageLayout
{
    public string ContainerDomElementId => "app";

    // After page first rendered in client then connect with react system in background.
    // So user first iteraction time will be minimize.

    public string InitialScript =>
        $$"""
          import {ReactWithDotNet} from '{{IndexJsFilePath}}';

          ReactWithDotNet.StrictMode = false;

          ReactWithDotNet.RequestHandlerPath = '{{RequestHandlerPath}}';

          ReactWithDotNet.RenderComponentIn({
            idOfContainerHtmlElement: '{{ContainerDomElementId}}',
            renderInfo: {{RenderInfo.ToJsonString()}}
          });

          var currentScrollY = 0;

          document.addEventListener('scroll', () => 
          {
              var scrollY = window.scrollY;
          
              function canFireAction()
              {
                  if (scrollY > 0)
                  {
                      return currentScrollY === 0;
                  }
          
                  if (currentScrollY > 0)
                  {
                      return true;
                  }
          
                  return false;
              }
          
              if (canFireAction())
              {
                  currentScrollY = scrollY;
          
                  ReactWithDotNet.DispatchEvent('MainContentDivScrollChangedOverZero', [scrollY]);
              }
              else
              {
                  currentScrollY = scrollY;
              }
          });

          """;

    public ComponentRenderInfo RenderInfo { get; set; }

    protected override Element render()
    {
        return new html
        {
            Lang("tr"),
            DirLtr,

            new head
            {
                new meta { charset = "UTF-8" },
                
                new meta { name    = "viewport", content = "width=device-width, initial-scale=1" },

                new meta { name = "description", content = "19 Sistemi Nedir" },

                new title { "19 Sistemi Nedir" },

                // F A V I C O N
                new link { rel = "icon", href = fav("favicon.ico") },

                new link { rel = "apple-touch-icon", sizes = "180x180", href = fav("apple-touch-icon.png") },

                new link { rel = "icon", type = "image/png", sizes = "32x32", href = fav("favicon-32x32.png") },

                new link { rel = "icon", type = "image/png", sizes = "16x16", href = fav("favicon-16x16.png") },

                new link { rel = "manifest", href = fav("site.webmanifest") },

                new link
                {
                    rel         = "stylesheet",
                    type        = "text/css",
                    href        = IndexCssFilePath,
                    crossOrigin = "anonymous"
                },

                new style
                {
                    """
                    html, body 
                    {
                        height: 100vh;
                        margin: 0;
                        font-family: 'Nunito Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif;
                        font-size: 16px;
                        line-height: 26px;
                        color: rgb(51, 51, 51);
                    }

                    input:focus, textarea:focus, select:focus 
                    {
                        outline: none;
                    }
                    """
                },

                new link { rel = "stylesheet", href = "https://fonts.googleapis.com/css?family=Nunito+Sans:400,700,800,900&amp;display=swap", media = "all" }
            },
            new body
            {
                new div(Id(ContainerDomElementId), WidthFull, Height100vh)
            }
        };

        string fav(string fileName)
        {
            return $"{Context.wwwroot}/img/favicon_io/{fileName}";
        }
    }
}