﻿namespace QuranAnalyzer.WebUI.Components;

public class TextArea : ReactComponent
{
    Expression<Func<InputValueBinder>> ValueBind;

    public static Modifier Bind(Expression<Func<InputValueBinder>> expression)
    {
        return CreateComponentModifier<TextArea>(x => x.ValueBind = expression);
    }

    protected override Element render()
    {
        return new textarea
        {
            valueBind = ValueBind,
            rows      = 6,
            style =
            {
                ComponentBorder,
                BorderRadiusForPanels,

                Focus(Border($"1px solid {BluePrimary}"))
            }
        };
    }
}

public class TextInput : ReactComponent
{
    Expression<Func<InputValueBinder>> ValueBind;

    public static Modifier Bind(Expression<Func<InputValueBinder>> expression)
    {
        return CreateComponentModifier<TextInput>(x => x.ValueBind = expression);
    }

    protected override Element render()
    {
        return new input
        {
            type      = "text",
            valueBind = ValueBind,
            style =
            {
                ComponentBorder,
                BorderRadiusForPanels,
                Padding(5),
                Focus(Border($"1px solid {BluePrimary}"))
            }
        };
    }
}

public class Label : ReactPureComponent
{
    public string Text;

    protected override Element render()
    {
        return new label
        {
            text = Text, style = { FontSize14, FontWeight600 }
        };
    }
}