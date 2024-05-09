namespace QuranAnalyzer;

public static class QuranQuery
{
    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> Contains(this IReadOnlyList<LetterInfo> source, IReadOnlyList<LetterInfo> search)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (search is null)
        {
            throw new ArgumentNullException(nameof(search));
        }

        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        source = source.Where(IsValidForWordSearch).ToList();
        search = search.Where(IsValidForWordSearch).ToList();

        if (search.Count > source.Count)
        {
            return returnList;
        }

        int i;

        for (i = 0; i < source.Count; i++)
        {
            if (i + search.Count > source.Count)
            {
                return returnList;
            }

            var isMatch = true;
            int j;
            for (j = 0; j < search.Count; j++)
            {
                if (!source[i + j].HasValueAndSameAs(search[j]))
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                returnList.Add((start: source[i], end: source[i + j - 1]));
            }
        }

        return returnList;
    }

    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> EndsWith(this IReadOnlyList<LetterInfo> source, IReadOnlyList<LetterInfo> search)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (search is null)
        {
            throw new ArgumentNullException(nameof(search));
        }

        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        source = source.Where(IsValidForWordSearch).ToList();
        search = search.Where(IsValidForWordSearch).ToList();

        if (search.Count > source.Count)
        {
            return returnList;
        }

        var sourceIndex = source.Count - search.Count;

        for (var i = 0; i < search.Count; i++)
        {
            if (!source[sourceIndex + i].HasValueAndSameAs(search[i]))
            {
                return returnList;
            }
        }

        returnList.Add((source[sourceIndex], source[sourceIndex + search.Count - 1]));

        return returnList;
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
            returnList.AddRange(word.EndsWith(searchWord));
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
            returnList.AddRange(word.StartsWith(searchWord));
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

                currentWord = new List<LetterInfo>();

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

        wordA = wordA.Where(IsValidForWordSearch).ToList();
        wordB = wordB.Where(IsValidForWordSearch).ToList();

        if (wordA.Count != wordB.Count)
        {
            return false;
        }

        var length = wordA.Count;

        for (var i = 0; i < length; i++)
        {
            if (!wordA[i].HasValueAndSameAs(wordB[i]))
            {
                return false;
            }
        }

        return true;
    }

    // todo check performans and write test code
    public static bool Same2(this IReadOnlyList<LetterInfo> wordA, IReadOnlyList<LetterInfo> wordB)
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

    
    public static IReadOnlyList<(LetterInfo start, LetterInfo end)> StartsWith(this IReadOnlyList<LetterInfo> source, IReadOnlyList<LetterInfo> search)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (search is null)
        {
            throw new ArgumentNullException(nameof(search));
        }

        var returnList = new List<(LetterInfo start, LetterInfo end)>();

        source = source.Where(IsValidForWordSearch).ToList();
        search = search.Where(IsValidForWordSearch).ToList();

        if (search.Count > source.Count)
        {
            return returnList;
        }

        for (var i = 0; i < search.Count; i++)
        {
            if (!source[i].HasValueAndSameAs(search[i]))
            {
                return returnList;
            }
        }

        returnList.Add((source[0], source[search.Count - 1]));

        return returnList;
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