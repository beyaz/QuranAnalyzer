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

    public static Verse ToVerse(int chapterNumber, int verseNumber, string text, string bismillah)
    {
        var textWithBismillah = bismillah + " " + text;

        var analyzedFullText = AnalyzeText(textWithBismillah);

        var analyzedText = AnalyzeText(text);

        return new Verse
        {
            VerseNumber             = verseNumber,
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

    static IReadOnlyList<Chapter> ReadAllChaptersFromXmlFile(string xmlFilePath)
    {
        var chapters = ReadChaptersFromXmlFile(xmlFilePath);

        return
        [
            .. from chapter in chapters
               select new Chapter
               {
                   Name   = chapter.Name,
                   ChapterNumber  = int.Parse(chapter.Index),
                   Verses = [.. from v in chapter.AyaList select toVerse(chapter, v)]
               }
        ];

        static Verse toVerse(Sura chapter, Aya v)
        {
            return ToVerse(int.Parse(chapter.Index), int.Parse(v.Index), v.Text, v.Bismillah);
        }
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
    //@formatter:off
    public int ChapterNumber { get; init; }
    
    public string Name { get; init; }
    
    public IReadOnlyList<Verse> Verses { get; init; }
    //@formatter:on
}

[Serializable]
public sealed class Verse
{
    // @formatter:off
    public int ChapterNumber { get; init; }
    
    public int VerseNumber { get; init; }
    
    public string Bismillah { get; init; }
    
    // T e x t
    public string Text { get; init; }

    public IReadOnlyList<LetterInfo> TextAnalyzed { get; set; }
    
    public IReadOnlyList<IReadOnlyList<LetterInfo>> TextWordList { get; set; }


    // T e x t  +  B i s m i l l a h
    public string TextWithBismillah { get; init; }
  
    public IReadOnlyList<LetterInfo> TextWithBismillahAnalyzed { get; init; }

    public IReadOnlyList<IReadOnlyList<LetterInfo>> TextWithBismillahWordList { get; init; }
    
    
    public string Id { get; init; }
   
    // @formatter:on
}