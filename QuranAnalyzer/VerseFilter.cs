using System.Text.Json;
using static QuranAnalyzer.DataAccess;
using static QuranAnalyzer.FpExtensions;

namespace QuranAnalyzer;

public static class VerseFilter
{
    public static Verse GetVerseById(string verseId)
    {
        var arr = verseId.Split(':');

        var chapterNumber = int.Parse(arr[0]);
        var verseNumber = int.Parse(arr[1]);

        return AllChapters[chapterNumber - 1].Verses[verseNumber - 1];
    }

    public static Result<IReadOnlyList<Verse>> GetVerseList(string searchScript)
    {
        if (string.IsNullOrWhiteSpace(searchScript))
        {
            return (Error)"Arama kriteri boş olamaz";
        }

        if (searchScript.Trim() == "*")
        {
            return AllChapters.SelectMany(x => x.Verses).ToList();
        }

        var returnList = new List<Verse>();

        var items = searchScript.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

        foreach (var item in items)
        {
            var shouldExtract = item[0] == '-';

            var response = process(item.RemoveFromStart("-"));
            if (response.HasError)
            {
                return response;
            }

            if (shouldExtract)
            {
                returnList.RemoveAll(x => response.Value.Any(y => y.Id == x.Id));
            }
            else
            {
                returnList.AddRange(response.Value);
            }
        }

        return returnList;

        static Result<IReadOnlyList<Verse>> byRange(string begin, string end)
        {
            var verseBegin = getVerseById(begin);
            var verseEnd = getVerseById(end);

            if (verseBegin.HasError)
            {
                return verseBegin.Error;
            }

            if (verseEnd.HasError)
            {
                return verseEnd.Error;
            }

            if (verseBegin.Value.ChapterNumber > verseEnd.Value.ChapterNumber)
            {
                return (Error)$"Başlangıç {verseBegin.Value.ChapterNumber} bitişten {verseEnd.Value.ChapterNumber} büyük olamaz.";
            }

            var returnList = new List<Verse>();

            foreach (var chapter in AllChapters)
            {
                if (chapter.Index < verseBegin.Value.ChapterNumber || chapter.Index > verseEnd.Value.ChapterNumber)
                {
                    continue;
                }

                foreach (var verse in chapter.Verses)
                {
                    if (chapter.Index == verseBegin.Value.ChapterNumber && verse.IndexAsNumber < verseBegin.Value.IndexAsNumber)
                    {
                        continue;
                    }

                    if (chapter.Index == verseEnd.Value.ChapterNumber && verse.IndexAsNumber > verseEnd.Value.IndexAsNumber)
                    {
                        continue;
                    }

                    if (chapter.Index == verseBegin.Value.ChapterNumber && verse.IndexAsNumber == verseBegin.Value.IndexAsNumber)
                    {
                        returnList.Add(verseBegin.Value);
                        continue;
                    }

                    if (chapter.Index == verseEnd.Value.ChapterNumber && verse.IndexAsNumber == verseEnd.Value.IndexAsNumber)
                    {
                        returnList.Add(verseEnd.Value);
                        continue;
                    }

                    returnList.Add(verse);
                }
            }

            return returnList;
        }

        static Result<Verse> getVerseById(string verseId)
        {
            var arr = verseId.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            if (arr.Length != 2)
            {
                return (Error)$"arama kriterlerinde hata var.{verseId}";
            }

            var chapter = from chapterNumber in ParseInt(arr[0]) from x in findChapterByNumber(chapterNumber) select x;
            if (chapter.HasError)
            {
                return chapter.Error;
            }

            if (verseFilterHasSpecificRange(arr[1]))
            {
                return getVerseWithSpecificRange(chapter.Value, arr[1]);
            }

            var verseNumber = ParseInt(arr[1]);
            if (verseNumber.HasError)
            {
                return verseNumber.Error;
            }

            if (verseNumber.Value <= 0 || verseNumber.Value > chapter.Value.Verses.Count)
            {
                return (Error)$"Sure seçiminde yanlışlık var.{verseId}";
            }

            return chapter.Value.Verses[verseNumber.Value - 1];
        }

        static Result<Chapter> findChapterByNumber(int chapterNumber)
        {
            if (chapterNumber <= 0 || chapterNumber > AllChapters.Count)
            {
                return (Error)$"Sure seçiminde yanlışlık var.{chapterNumber}";
            }

            return AllChapters[--chapterNumber];
        }

        Result<IReadOnlyList<Verse>> process(string searchItem)
        {
            if (searchItem.Trim() == "*")
            {
                return AllChapters.SelectMany(x => x.Verses).ToList();
            }

            // is range
            if (searchItem.Trim().Contains("-->", StringComparison.OrdinalIgnoreCase))
            {
                var range = searchItem.Split("-->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (range.Length != 2)
                {
                    return (Error)$"arama kriterlerinde hata var.{searchItem}";
                }

                return byRange(range[0], range[1]);
            }

            var arr = searchItem.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length != 2)
            {
                return (Error)$"arama kriterlerinde hata var.{searchItem}";
            }

            return from chapterNumber in parseChapterNumber()
                   from chapter in findChapterByNumber(chapterNumber)
                   from verses in collectVerseList(chapter, arr[1]) select verses;

            Result<int> parseChapterNumber()
            {
                return ParseInt(arr[0]);
            }

            Result<IReadOnlyList<Verse>> collectVerseList(Chapter chapter, string verseFilter)
            {
                verseFilter = verseFilter.Trim();

                var filters = verseFilter.Split("-".ToCharArray()).Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()).ToArray();

                if (filters.Length == 1)
                {
                    if (filters[0] == "*")
                    {
                        return chapter.Verses.ToArray();
                    }

                    if (verseFilterHasSpecificRange(verseFilter))
                    {
                        return from verse in getVerseWithSpecificRange(chapter, verseFilter) select (IReadOnlyList<Verse>)[verse];
                    }

                    return from verseIndex in ParseInt(filters[0]) select selectOne(verseIndex);
                }

                if (filters.Length == 2)
                {
                    return from verseStartIndex in ParseInt(filters[0])
                           from verseEndIndex in ParseInt(filters[1])
                           from x in selectMultiple(verseStartIndex, verseEndIndex)
                           select x;
                }

                return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";

                Result<IReadOnlyList<Verse>> selectOne(int verseIndex)
                {
                    if (verseIndex <= 0 || verseIndex > chapter.Verses.Count)
                    {
                        return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";
                    }

                    return new[] { chapter.Verses[--verseIndex] };
                }

                Result<IReadOnlyList<Verse>> selectMultiple(int verseStartIndex, int verseEndIndex)
                {
                    if (verseStartIndex <= 0 || verseStartIndex > chapter.Verses.Count)
                    {
                        return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";
                    }

                    if (verseEndIndex <= 0 || verseEndIndex > chapter.Verses.Count)
                    {
                        return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";
                    }

                    if (verseStartIndex > verseEndIndex)
                    {
                        return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";
                    }

                    return chapter.Verses.ToList().GetRange(verseStartIndex - 1, verseEndIndex - verseStartIndex + 1);
                }
            }
        }

        static bool verseFilterHasSpecificRange(string verseFilter)
        {
            return verseFilter.Contains('[') && verseFilter.Contains(']') && verseFilter.Contains("..");
        }

        static Result<Verse> getVerseWithSpecificRange(Chapter chapter, string verseFilter)
        {
            var parseError = (Error)$"Sure seçiminde yanlışlık var.{verseFilter}";

            // 2[6..] select verse number 2 then select charachters after 6
            var verseNumberWithSpecificRangeArray = verseFilter.Split("[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (verseNumberWithSpecificRangeArray.Length != 2)
            {
                return parseError;
            }

            return from verseIndex in ParseInt(verseNumberWithSpecificRangeArray[0])
                   from verse in selectOne(verseIndex)
                   from x in selectSpecificRange(verse) select x;

            Result<Verse> selectSpecificRange(Verse selectedVerse)
            {
                var verse = Clone(selectedVerse);

                var indexArray = verseNumberWithSpecificRangeArray[1].Split('.', StringSplitOptions.RemoveEmptyEntries);
                if (indexArray.Length == 2)
                {
                    return 
                    from startIndex in ParseInt(indexArray[0])
                        from endIndex in ParseInt(indexArray[1])
                        from range in startIndexAndEndIndexShouldBeInValidRangeForVerse(startIndex, endIndex)
                        let text = verse.Text.Substring(range.startIndex, range.endIndex - range.startIndex)
                        from x in subText(text) select x;
                            
                }

                if (indexArray.Length == 1)
                {
                    if (verseNumberWithSpecificRangeArray[1].EndsWith(".."))
                    {
                        return from index in ParseInt(indexArray[0])
                               from startIndex in startIndexShouldBeInValidRangeForVerse(index)
                               let text = verse.Text[startIndex..]
                               from x in subText(text)
                               select x;
                    }

                    return from endIndex in ParseInt(indexArray[0])
                               from validEndIndex in endIndexShouldBeInValidRangeForVerse(endIndex)
                               let text = verse.Text[..validEndIndex]
                               from x in subText(text) select x;
                }

                return parseError;

                Result<int> endIndexShouldBeInValidRangeForVerse(int endIndex)
                {
                    if (endIndex <= 0)
                    {
                        return parseError;
                    }

                    if (endIndex > verse.Text.Length)
                    {
                        return parseError;
                    }

                    return endIndex;
                }

                Result<int> startIndexShouldBeInValidRangeForVerse(int startIndex)
                {
                    // normalize for .net
                    startIndex -= 1;

                    if (startIndex < 0)
                    {
                        return parseError;
                    }

                    if (startIndex >= verse.Text.Length)
                    {
                        return parseError;
                    }

                    return startIndex;
                }

                Result<(int startIndex, int endIndex)> startIndexAndEndIndexShouldBeInValidRangeForVerse(int startIndex, int endIndex)
                {
                    // normalize for .net
                    startIndex -= 1;

                    if (startIndex < 0)
                    {
                        return parseError;
                    }

                    if (startIndex >= verse.Text.Length)
                    {
                        return parseError;
                    }

                    if (endIndex <= 0)
                    {
                        return parseError;
                    }

                    if (endIndex > verse.Text.Length)
                    {
                        return parseError;
                    }

                    return (startIndex, endIndex);
                }

                Result<Verse> subText(string verseText2)
                {
                    return ToVerse(verse.ChapterNumber, verse.IndexAsNumber, verseText2, verse.Bismillah);
                }
            }

            Result<Verse> selectOne(int verseIndex)
            {
                if (verseIndex <= 0 || verseIndex > chapter.Verses.Count)
                {
                    return (Error)$"Sure seçiminde yanlışlık var.{verseFilter}";
                }

                return chapter.Verses[--verseIndex];
            }
        }
    }

    static T Clone<T>(this T instance)
    {
        return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(instance));
    }
}

public class VerseNumberComparer : IComparer<string>
{
    public int Compare(string verseIdA, string verseIdB)
    {
        if (verseIdA == null)
        {
            throw new ArgumentNullException(nameof(verseIdA));
        }

        if (verseIdB == null)
        {
            throw new ArgumentNullException(nameof(verseIdB));
        }

        if (verseIdA == verseIdB)
        {
            return 0;
        }

        var a = verseIdA.Split(':');
        var b = verseIdB.Split(':');

        if (int.Parse(a[0]) > int.Parse(b[0]))
        {
            return 1;
        }

        if (int.Parse(a[0]) == int.Parse(b[0]))
        {
            if (int.Parse(a[1]) > int.Parse(b[1]))
            {
                return 1;
            }
        }

        return -1;
    }
}