using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace QuranAnalyzer;

public static class DataAccess
{
    public static readonly IReadOnlyList<Chapter> AllChapters;

    static DataAccess()
    {
        AllChapters = ReadAllChaptersFromXmlFile(getFilePath());

        static string getFilePath()
        {
            var path = Path.GetDirectoryName(typeof(DataAccess).Assembly.Location) + Path.DirectorySeparatorChar;

            var filePath = "quran-uthmani.xml";

            if (File.Exists(path + filePath))
            {
                return path + filePath;
            }

            if (!File.Exists(filePath))
            {
                filePath = Path.Combine("bin", "Debug", "netcoreapp3.1", filePath);
            }

            return filePath;
        }
    }

    static IReadOnlyList<Chapter> ReadAllChaptersFromXmlFile(string xmlFilePath)
    {
        var chapters = ReadChaptersFromXmlFile(xmlFilePath);

        return chapters.AsListOf(chapter => new Chapter
        {
            Name   = chapter.Name,
            Index  = int.Parse(chapter.Index),
            Verses = chapter.AyaList.AsListOf(v => toVerse(chapter, v))
        });

        static Verse toVerse(Sura chapter, Aya v)
        {
            return ToVerse(int.Parse(chapter.Index), int.Parse(v.Index), v.Text, v.Bismillah);
        }
    }

    public static Verse ToVerse(int chapterNumber, int verseNumber, string text, string bismillah)
    {
        var textWithBismillah = bismillah + " " + text;

        var analyzedFullText = AnalyzeText(textWithBismillah);

        var analyzedText = AnalyzeText(text);

        return new Verse
        {
            Index                     = verseNumber.ToString(),
            IndexAsNumber             = verseNumber,
            Bismillah                 = bismillah,
            Text                      = text,
            TextAnalyzed              = analyzedText,
            TextWordList              = analyzedText.GetWords(),
            ChapterNumber             = chapterNumber,
            Id                        = $"{chapterNumber}:{verseNumber}",
            TextWithBismillahWordList = analyzedFullText.GetWords(),
            TextWithBismillahAnalyzed = analyzedFullText,
            TextWithBismillah         = textWithBismillah
        };
    }

    static IReadOnlyList<Sura> ReadChaptersFromXmlFile(string xmlFilePath)
    {
        Quran quran;

        using (var reader = XmlReader.Create(xmlFilePath))
        {
            quran = (Quran)new XmlSerializer(typeof(Quran)).Deserialize(reader);
        }

        if (quran is null)
        {
            throw new ArgumentException($"Xml file not read. @xmlFilePath: {xmlFilePath}");
        }

        return quran.SuraList;
    }

    [XmlRoot(ElementName = "aya")]
    public class Aya
    {
        [XmlAttribute(AttributeName = "bismillah")]
        public string Bismillah { get; set; }

        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }

        [XmlAttribute(AttributeName = "text")]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "quran")]
    public class Quran
    {
        [XmlElement(ElementName = "sura")]
        public List<Sura> SuraList { get; set; }
    }

    [XmlRoot(ElementName = "sura")]
    public class Sura
    {
        [XmlElement(ElementName = "aya")]
        public List<Aya> AyaList { get; set; }

        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}

[Serializable]
public sealed class Chapter
{
    public int Index { get; init; }
    public string Name { get; init; }
    public IReadOnlyList<Verse> Verses { get; init; }
}

[Serializable]
public sealed class Verse
{
    public string Bismillah { get; init; }
    public int ChapterNumber { get; init; }

    public string Id { get; init; }
    public string Index { get; init; }
    public int IndexAsNumber { get; init; }
    public string Text { get; init; }
    public IReadOnlyList<LetterInfo> TextAnalyzed { get; set; }
    public string TextWithBismillah { get; init; }

    /// <summary>
    ///     bismillah + text
    /// </summary>
    public IReadOnlyList<LetterInfo> TextWithBismillahAnalyzed { get; init; }

    public IReadOnlyList<IReadOnlyList<LetterInfo>> TextWithBismillahWordList { get; init; }

    public IReadOnlyList<IReadOnlyList<LetterInfo>> TextWordList { get; set; }
}