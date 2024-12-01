namespace QuranAnalyzer;

public static class QuranQuery
{
    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> Contains(this IReadOnlyList<LetterInfo> wordA, IReadOnlyList<LetterInfo> wordB)
    {
        if (wordB == null || wordA == null)
        {
            return [];
        }

        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        var a = 0;
        while (a < wordA.Count)
        {
            var item = StartsWith(wordA, a, wordB, 0);
            if (item is null)
            {
                a++;
                continue;
            }

            returnList.Add(item.Value);

            a = item.Value.end.StartIndex + 1;
        }

        return returnList;
    }

    public static (LetterInfo start, LetterInfo end)? EndsWith(this IReadOnlyList<LetterInfo> wordA, IReadOnlyList<LetterInfo> wordB)
    {
        if (wordB == null || wordA == null)
        {
            return null;
        }

        var a = wordA.Count - 1;
        var b = wordB.Count - 1;

        while (true)
        {
            // come to next valid value
            LetterInfo letterB;
            {
                // is end of search word
                if (b == -1)
                {
                    return (wordA[a + 1], wordA[^1]);
                }

                letterB = wordB[b];

                if (!IsValidForWordSearch(letterB))
                {
                    b--;
                    continue;
                }
            }

            // come to next valid value
            LetterInfo letterA;
            {
                // source has no value
                if (a == -1)
                {
                    return null;
                }

                letterA = wordA[a];

                if (!IsValidForWordSearch(letterA))
                {
                    a--;
                    continue;
                }
            }

            if (!letterB.HasValueAndSameAs(letterA))
            {
                return null;
            }

            a--;
            b--;
        }
    }

    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> GetStartAndEndPointsOfContainsWords(this Verse verse, IReadOnlyList<LetterInfo> searchWord)
    {
        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        foreach (var word in verse.TextWordList)
        {
            returnList.AddRange(word.Contains(searchWord));
        }

        return returnList;
    }

    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> GetStartAndEndPointsOfEndsWithWords(this Verse verse, IReadOnlyList<LetterInfo> searchWord)
    {
        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        foreach (var word in verse.TextWordList)
        {
            var item = word.EndsWith(searchWord);
            if (item is null)
            {
                continue;
            }

            returnList.Add(item.Value);
        }

        return returnList;
    }

    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> GetStartAndEndPointsOfSameWords(this Verse verse, IReadOnlyList<LetterInfo> searchWord)
    {
        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        foreach (var word in verse.TextWordList)
        {
            if (word.Same(searchWord))
            {
                returnList.Add((word[0], word[^1]));
            }
        }

        return returnList;
    }

    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> GetStartAndEndPointsOfStartsWithWords(this Verse verse, IReadOnlyList<LetterInfo> searchWord)
    {
        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        foreach (var word in verse.TextWordList)
        {
            var item = word.StartsWith(searchWord);
            if (item is null)
            {
                continue;
            }

            returnList.Add(item.Value);
        }

        return returnList;
    }

    public static IReadOnlyList<IReadOnlyList<LetterInfo>> GetWords(this IReadOnlyList<LetterInfo> text)
    {
        var returnList = new List<IReadOnlyList<LetterInfo>>();

        var length = text.Count;

        var currentWord = new List<LetterInfo>();

        for (var i = 0; i < length; i++)
        {
            if (text[i].Letter == ' ')
            {
                if (currentWord.Count == 0)
                {
                    continue;
                }

                returnList.Add(currentWord);

                currentWord = new();

                continue;
            }

            currentWord.Add(text[i]);
        }

        if (currentWord.Count > 0)
        {
            returnList.Add(currentWord);
        }

        return returnList;
    }

    public static bool Same(this IReadOnlyList<LetterInfo> wordA, IReadOnlyList<LetterInfo> wordB)
    {
        if (wordA == null || wordB == null)
        {
            return false;
        }

        var a = 0;
        var b = 0;

        var lengthA = wordA.Count;
        var lengthB = wordB.Count;

        while (a < lengthA)
        {
            // come to next valid value
            while (a < lengthA && !IsValidForWordSearch(wordA[a]))
            {
                a++;
            }

            // come to next valid value
            while (b < lengthB && !IsValidForWordSearch(wordB[b]))
            {
                b++;
            }

            if (a == lengthA)
            {
                if (b == lengthB)
                {
                    return true;
                }

                return false;
            }

            if (b == lengthB)
            {
                return false;
            }

            if (!wordA[a].HasValueAndSameAs(wordB[b]))
            {
                return false;
            }

            a++;
            b++;
        }

        // come to next valid value
        while (a < lengthA && !IsValidForWordSearch(wordA[a]))
        {
            a++;
        }

        // come to next valid value
        while (b < lengthB && !IsValidForWordSearch(wordB[b]))
        {
            b++;
        }

        if (a != lengthA || b != lengthB)
        {
            return false;
        }

        return true;
    }

    public static (LetterInfo start, LetterInfo end)? StartsWith(this IReadOnlyList<LetterInfo> wordA, IReadOnlyList<LetterInfo> wordB)
    {
        return StartsWith(wordA, 0, wordB, 0);
    }

    public static (LetterInfo start, LetterInfo end)? StartsWith(this IReadOnlyList<LetterInfo> wordA, int startIndexA, IReadOnlyList<LetterInfo> wordB, int startIndexB)
    {
        if (wordB == null || wordA == null)
        {
            return null;
        }

        var a = startIndexA;
        var b = startIndexB;

        var lengthA = wordA.Count;
        var lengthB = wordB.Count;

        while (true)
        {
            // come to next valid value
            LetterInfo letterB;
            {
                // is end of search word
                if (b == lengthB)
                {
                    return (wordA[0], wordA[a - 1]);
                }

                letterB = wordB[b];

                if (!IsValidForWordSearch(letterB))
                {
                    b++;
                    continue;
                }
            }

            // come to next valid value
            LetterInfo letterA;
            {
                // source has no value
                if (a == lengthA)
                {
                    return null;
                }

                letterA = wordA[a];

                if (!IsValidForWordSearch(letterA))
                {
                    a++;
                    continue;
                }
            }

            if (!letterB.HasValueAndSameAs(letterA))
            {
                return null;
            }

            a++;
            b++;
        }
    }

    static bool IsValidForWordSearch(LetterInfo info)
    {
        if (info.NumericValue > 0 && info.Letter != HamzaAbove)
        {
            return true;
        }

        return false;
    }
}