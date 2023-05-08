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
        var verseNumber   = int.Parse(arr[1]);

        return AllChapters[chapterNumber - 1].Verses[verseNumber - 1];
    }

    public static Response<IReadOnlyList<Verse>> GetVerseList(string searchScript)
    {
        if (string.IsNullOrWhiteSpace(searchScript))
        {
            return "Arama kriteri boş olamaz";
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
            if (response.IsFail)
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

        static Response<IReadOnlyList<Verse>> byRange(string begin, string end)
        {
            var verseBegin = getVerseById(begin);
            var verseEnd   = getVerseById(end);

            if (verseBegin.IsFail)
            {
                return verseBegin.FailMessage;
            }

            if (verseEnd.IsFail)
            {
                return verseEnd.FailMessage;
            }

            if (verseBegin.Value.ChapterNumber > verseEnd.Value.ChapterNumber)
            {
                return $"Başlangıç {verseBegin.Value.ChapterNumber} bitişten {verseEnd.Value.ChapterNumber} büyük olamaz.";
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

        static Response<Verse> getVerseById(string verseId)
        {
            var arr = verseId.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            if (arr.Length != 2)
            {
                return (Error)$"arama kriterlerinde hata var.{verseId}";
            }

            var chapter = ParseInt(arr[0]).Then(findChapterByNumber);
            if (chapter.IsFail)
            {
                return chapter.FailMessage;
            }

            if (verseFilterHasSpecificRange(verseFilter: arr[1]))
            {
                return getVerseWithSpecificRange(chapter.Value, verseFilter: arr[1]);
            }

            var verseNumber = ParseInt(arr[1]);
            if (verseNumber.IsFail)
            {
                return verseNumber.FailMessage;
            }

            if (verseNumber.Value <= 0 || verseNumber.Value > chapter.Value.Verses.Count)
            {
                return (Error)$"Sure seçiminde yanlışlık var.{verseId}";
            }

            return chapter.Value.Verses[--verseNumber.Value];
        }

        static Response<Chapter> findChapterByNumber(int chapterNumber)
        {
            if (chapterNumber <= 0 || chapterNumber > AllChapters.Count)
            {
                return (Error)$"Sure seçiminde yanlışlık var.{chapterNumber}";
            }

            return AllChapters[--chapterNumber];
        }

        Response<IReadOnlyList<Verse>> process(string searchItem)
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

            return parseChapterNumber()
                  .Then(findChapterByNumber)
                  .Then(chapter => collectVerseList(chapter, arr[1]));

            Response<int> parseChapterNumber()
            {
                return ParseInt(arr[0]);
            }

            Response<IReadOnlyList<Verse>> collectVerseList(Chapter chapter, string verseFilter)
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
                        return getVerseWithSpecificRange(chapter, verseFilter).ToReadOnlyList();
                    }

                    return ParseInt(filters[0]).Then(selectOne);
                }

                if (filters.Length == 2)
                {
                    return Apply(selectMultiple, ParseInt(filters[0]), ParseInt(filters[1]));
                }

                return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";

                Response<IReadOnlyList<Verse>> selectOne(int verseIndex)
                {
                    if (verseIndex <= 0 || verseIndex > chapter.Verses.Count)
                    {
                        return (Error)$"Sure seçiminde yanlışlık var.{searchItem}";
                    }

                    return new[] { chapter.Verses[--verseIndex] };
                }

                Response<IReadOnlyList<Verse>> selectMultiple(int verseStartIndex, int verseEndIndex)
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

        static Response<Verse> getVerseWithSpecificRange(Chapter chapter, string verseFilter)
        {
            var parseError = (Error)$"Sure seçiminde yanlışlık var.{verseFilter}";

            // 2[6..] select verse number 2 then select charachters after 6
            var verseNumberWithSpecificRangeArray = verseFilter.Split("[]".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (verseNumberWithSpecificRangeArray.Length != 2)
            {
                return parseError;
            }

            return ParseInt(verseNumberWithSpecificRangeArray[0]).Then(selectOne).Then(selectSpecificRange);

            Response<Verse> selectSpecificRange(Verse selectedVerse)
            {
                var verse = Clone(selectedVerse);

                var indexArray = verseNumberWithSpecificRangeArray[1].Split('.', StringSplitOptions.RemoveEmptyEntries);
                if (indexArray.Length == 2)
                {
                    return (ParseInt(indexArray[0]), ParseInt(indexArray[1]))
                          .Then(startIndexAndEndIndexShouldBeInValidRangeForVerse)
                          .Then(tuple => verse.Text.Substring(tuple.startIndex, tuple.endIndex - tuple.startIndex))
                          .Then(subText);
                }

                if (indexArray.Length == 1)
                {
                    if (verseNumberWithSpecificRangeArray[1].EndsWith(".."))
                    {
                        return ParseInt(indexArray[0])
                              .Then(startIndexShouldBeInValidRangeForVerse)
                              .Then(startIndex => verse.Text.Substring(startIndex))
                              .Then(subText);
                    }

                    return ParseInt(indexArray[0])
                          .Then(endIndexShouldBeInValidRangeForVerse)
                          .Then(endIndex => verse.Text.Substring(0, endIndex))
                          .Then(subText);
                }

                return parseError;

                Response<int> endIndexShouldBeInValidRangeForVerse(int endIndex)
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

                Response<int> startIndexShouldBeInValidRangeForVerse(int startIndex)
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

                Response<(int startIndex, int endIndex)> startIndexAndEndIndexShouldBeInValidRangeForVerse(int startIndex, int endIndex)
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

                Response<Verse> subText(string verseText2)
                {
                    return ToVerse(verse.ChapterNumber, verse.IndexAsNumber, verseText2, verse.Bismillah);
                }
            }

            Response<Verse> selectOne(int verseIndex)
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
        => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(instance));
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