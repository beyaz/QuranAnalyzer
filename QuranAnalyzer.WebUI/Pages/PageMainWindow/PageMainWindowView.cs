﻿using QuranAnalyzer.WebUI.Pages.CountOfAllahPage;
using QuranAnalyzer.WebUI.Pages.PageAllInitialLettersCombined;
using QuranAnalyzer.WebUI.Pages.PageCharacterCounting;
using QuranAnalyzer.WebUI.Pages.PageInitialLetters;
using QuranAnalyzer.WebUI.Pages.PageVerseListContainsAllInitialLetters;
using QuranAnalyzer.WebUI.Pages.PageWordSearching;

namespace QuranAnalyzer.WebUI.Pages.PageMainWindow;

class PageMainWindowView : ReactPureComponent
{
    string SelectedPageId => Query[QueryKey.Page] ?? PageId.MainWindow;

    protected override Element render()
    {
        return new div(WidthFull, HeightAuto)
        {
            new FixedTopPanelContainer(),

            new main(DisplayFlex, FlexDirectionRow, JustifyContentCenter, HeightAuto)
            {
                new MainContentContainer
                {
                    MarginTopBottom(30),

                    new LeftMenu
                    {
                        SelectedPageId = SelectedPageId,
                        style =
                        {
                            MinWidth(230),
                            MarginTop(101),
                            WhenMediaMaxWidth(MD,new Style { DisplayNone })
                        }
                    },

                    buildMainContent()
                }
            }
        };

        Element buildMainContent()
        {
            return SelectedPageId switch
            {
                PageId.MainWindow                         => new MainPageContent(),
                PageId.SecuringDataWithCurrentTechnology  => new PageSecuringDataWithCurrentTechnology(),
                PageId.PreInformation                     => new PagePreInformation(),
                PageId.InitialLetters                     => new PageInitialLettersView(),
                PageId.QuestionAnswer                     => new PageQuestionAnswer(),
                PageId.Contact                            => new PageContact(),
                PageId.CharacterCounting                  => new PageCharacterCountingView(),
                PageId.WordSearching                      => new WordSearchingView(),
                PageId.AlternativeSystems                 => new PageAlternativeSystems(),
                PageId.SimpleDefinition                   => new PageSimpleDefinition(),
                PageId.MushafOptionsDetail                => new PageMushafOptionsDetail(),
                PageId.WhoIsRashadKhalifaPage             => new PageWhoIsRashadKhalifa(),
                PageId.WhyFamousPeopleAreSilent           => new PageWhyFamousPeopleAreSilent(),
                PageId.AboutEdipYuksel                    => new PageAboutEdipYuksel(),
                PageId.VerseListContainsAllInitialLetters => new PageVerseListContainsAllInitialLettersView(),
                PageId.AdditionalVerses                   => new PageAdditionalVerses(),
                PageId.CountOfAllah                       => new PageCountOfAllahView(),
                PageId.AllInitialLettersCombined          => new PageAllInitialLettersCombinedView(),
                PageId.WhereIsTheProblem                  => new PageWhereIsTheProblem(),
                PageId.IsHeMessenger                      => new PageIsHeMessenger(),
                PageId.IsThereAnyCommunity                => new PageIsThereAnyCommunity(),
                PageId.MobileMenu                         => new LeftMenu { SelectedPageId = SelectedPageId },
                _                                         => new MainPageContent()
            };
        }
    }
}