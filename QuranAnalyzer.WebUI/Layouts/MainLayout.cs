﻿namespace QuranAnalyzer.WebUI.Layouts;

class MainLayout : ReactPureComponent
{
    public Element Page { get; set; }

    public string QueryString { get; set; }

    public string RenderInfo { get; set; }

    protected override Element render()
    {
        const string root = "wwwroot";

        return new html
        {
            Lang("tr"),
            DirLtr,

            new head
            {
                new meta { charset = "UTF-8" },
                new meta { name    = "viewport", content = "width=device-width, initial-scale=1" },
                new title { "19 Sistemi Nedir" },

                new style
                {
                    @"
                   html, body {
                       height: 100vh;
                       margin: 0;
                       font-family: 'Nunito Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif;
                       font-size: 16px;
                       color: rgb(51, 51, 51);
                   }
                   
                   input:focus, textarea:focus, select:focus {
                       outline: none;
                   }
"
                },

                new link { rel = "stylesheet", href = "https://fonts.googleapis.com/css?family=Nunito+Sans:400,700,800,900&amp;display=swap", media = "all" }
            },
            new body
            {
                new div(Id("app"), WidthMaximized, Height100vh)
                {
                    Page
                },

                // After page first rendered in client then connect with react system in background.
                // So user first iteraction time will be minimize.

                new script { type = "module", src = $"{root}/dist/index.js" },

                new script
                {
                    type = "module",
                    text =
                        $@"

import {{ReactWithDotNet}} from './{root}/dist/index.js';

ReactWithDotNet.RenderComponentIn({{
  idOfContainerHtmlElement: 'app',
  renderInfo: {RenderInfo}
}});

"
                }
            }
        };
    }
}