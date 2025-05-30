﻿using System.Numerics;
using static QuranAnalyzer.WebUI.Pages.PageAllInitialLettersCombined.Extensions;

namespace QuranAnalyzer.WebUI.Pages.PageAllInitialLettersCombined;

class TotalCounts : ReactComponent
{
    public bool IsDisplayingResults { get; set; }

    public IReadOnlyList<InitialLetterCountInfo> Records { get; set; } = AllInitialLetterTotalCounts;

    protected override Element render()
    {
        var animationDelays = CreateAnimationDelays(50);

        return new FlexColumn(Gap(10), AlignItemsCenter)
        {
            new FlexColumn(AlignItemsCenter)
            {
                new FlexRow(Gap(5), FlexWrap, JustifyContentCenter)
                {
                    Records.Select((_, i) => CreateWithCount(i, animationDelays[i] - 100))
                }
            },

            new FlexRow
            {
                new ActionButton { Label = "Hesapla", OnClick = Calculate } + When(IsDisplayingResults, DisplayNone)
            },

            SpaceY(20),

            When(IsDisplayingResults, () => new FlexColumn
            {
                new FlexRowCentered(FlexWrap)
                {
                    Records.Select((_, i) => AnimateRecord(i, animationDelays[i]))
                },

                EqualsTo(animationDelays[Records.Count]),

                new FlexRowCentered
                {
                    InFadeAnimation(new FlexRow { CalculateResult() }, animationDelays[Records.Count + 1])
                }
            })
        };
    }

    static string GetIdOf(bool isBegin, int recordIndex)
    {
        return string.Join("-",
                           nameof(TotalCounts),
                           isBegin ? "begin" : "end",
                           nameof(recordIndex),
                           recordIndex);
    }

    static Element InFadeAnimation(Element element, int delay)
    {
        return new Fade
        {
            triggerOnce = true,
            delay       = delay,
            children =
            {
                element
            }
        };
    }

    Element AnimateRecord(int recordIndex, int delayForAnimation)
    {
        var record = Records[recordIndex];

        var needArrow = recordIndex < 3 || recordIndex + 3 >= Records.Count;

        return InFadeAnimation(new div
        {
            needArrow ? new Arrow { start = GetIdOf(true, recordIndex), end = GetIdOf(false, recordIndex) } : null,

            new Fade
            {
                triggerOnce = true,
                direction   = "down",
                delay       = delayForAnimation + 200,
                children =
                {
                    new FlexRowCentered(ComponentBorder, BorderRadius(3), Id(GetIdOf(false, recordIndex)), OverflowWrapNormal) { record.Count }
                }
            }
        }, delayForAnimation);
    }

    Task Calculate()
    {
        IsDisplayingResults = true;
        
        return Task.CompletedTask;
    }

    Element CalculateResult()
    {
        var bigNumber = BigInteger.Parse(string.Join(string.Empty, Records.Select(x => x.Count)));

        if (bigNumber % 19 == 0)
        {
            return new FlexRow(AlignItemsFlexStart, Gap(3))
            {
                (strong)"19" + MarginTop(-2), (small)"x", (small)(bigNumber / 19).ToString() + OverflowWrapAnywhere
            };
        }

        return new div { bigNumber.ToString() } + OverflowWrapAnywhere;
    }

    Element CreateInput(Expression<Func<InputValueBinder>> bindingExpression, HtmlElementModifier htmlElementModifier, int delay)
    {
        var element = new input(Width(40), TextAlignCenter, Border(Solid(0.1, ColorForBorder)))
        {
            type                     = "text",
            valueBind                = bindingExpression,
            valueBindDebounceTimeout = 200,
            valueBindDebounceHandler = RecalculateTotalCounts
        } + htmlElementModifier;

        if (IsDisplayingResults)
        {
            return new AttentionSeeker
            {
                effect      = "flash",
                delay       = delay,
                triggerOnce = true,
                children =
                {
                    element
                }
            };
        }

        return element;
    }

    Element CreateWithCount(int recordIndex, int delay)
    {
        return new FlexColumn(ComponentBorder, BorderRadiusForPanels, Padding(3), Gap(4))
        {
            Records[recordIndex].Label is not null? new FlexRow(JustifyContentCenter)
            {
                Records[recordIndex].Label
            }:null,
            Records[recordIndex].Label is null? new FlexRow(JustifyContentCenter)
            {
                AsLetter(Records[recordIndex].Text)
            }:null,
            new FlexRowCentered
            {
                CreateInput(() => Records[recordIndex].Count, Id(GetIdOf(true, recordIndex)), delay)
            }
        };
    }

    Element EqualsTo(int delayForAnimation)
    {
        return new FlexRowCentered
        {
            new Fade
            {
                triggerOnce = true,
                delay       = delayForAnimation,
                children =
                {
                    new img(MarginTopBottom(10))
                    {
                        src    = FileAtImgFolder("arrow-down-double.svg"),
                        width  = "40",
                        height = "40"
                    }
                }
            }
        };
    }

    Task RecalculateTotalCounts()
    {
        Records.SkipLast(1).SumOf(x => ParseInt(x.Count)).Then(total => Records[^1].Count = total.ToString());
        
        return Task.CompletedTask;
    }

    class Arrow : ReactPureComponent
    {
        public string end;
        public string start;

        protected override Element render()
        {
            const string color = "#e02020";

            return new Xarrow
            {
                start       = start,
                end         = end,
                path        = "smooth",
                color       = color,
                strokeWidth = 1,
                startAnchor = "bottom",
                dashness    = true,
                endAnchor   = "top",
                lineColor   = color,
                headColor   = color
            };
        }
    }
}