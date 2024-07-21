

// import core library
import ReactWithDotNet from "./react-with-dotnet/react-with-dotnet";

// you can comment these imports according to your project dependency
import "./react-with-dotnet/libraries/mui-core/all";
import "./react-with-dotnet/libraries/react-awesome-reveal/all";
import "./react-with-dotnet/libraries/react-free-scrollbar/all";
import "./react-with-dotnet/libraries/react-xarrows/all";
import "./react-with-dotnet/libraries/framer-motion/all";

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


export { ReactWithDotNet };


import React, { useState } from 'react';

function getSelectedText() 
{
    if (window.getSelection)
    {
        return window.getSelection() + '';
    }

    if (document.getSelection)
    {
        return document.getSelection() + '';
    }

    if (document.selection)
    {
        return document.selection.createRange().text + '';
    }

    return '';
}

ReactWithDotNet.RegisterExternalJsObject('QuranAnalyzer.WebUI.Pages.Shared.CollapseContainer', props =>
{
    const [isOpen, setIsOpen] = useState(false);

    var onClick = e =>
    {
        if (e.target.tagName === 'INPUT' || getSelectedText().length > 0)
        {
            return;
        }

        setIsOpen(!isOpen);
    };
    return (
        <div onClick={onClick}>
            {isOpen ? props.ContentOnOpened : props.ContentOnClosed}
        </div>
    );
});