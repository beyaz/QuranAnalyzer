namespace QuranAnalyzer;

[TestClass]
public class VerseFilterTest
{
    [TestMethod]
    public void _4()
    {
        VerseFilter.GetVerseList("1:*, -1:3, -1:4").HasError.ShouldBeFalse();
    }

    [TestMethod]
    public void _5()
    {
        VerseFilter.GetVerseList("1:3 --> 1:7").Unwrap().Count.ShouldBe(5);

        VerseFilter.GetVerseList("1:3 --> 2:4").Unwrap().Count.ShouldBe(9);

        VerseFilter.GetVerseList("1:3 --> 4:7").HasError.ShouldBeFalse();
    }

    [TestMethod]
    public void FilterWithSpecificRange()
    {
        var records = VerseFilter.GetVerseList(" 42 : 3 ").Value;

        records[0].Text.ShouldBe("كَذَٰلِكَ يُوحِىٓ إِلَيْكَ وَإِلَى ٱلَّذِينَ مِن قَبْلِكَ ٱللَّهُ ٱلْعَزِيزُ ٱلْحَكِيمُ");

        records[0].Text.Length.ShouldBe(87);

        records = VerseFilter.GetVerseList(" 42  : 3[1..] ").Value;

        records[0].Text.ShouldBe("كَذَٰلِكَ يُوحِىٓ إِلَيْكَ وَإِلَى ٱلَّذِينَ مِن قَبْلِكَ ٱللَّهُ ٱلْعَزِيزُ ٱلْحَكِيمُ");

        records[0].Text.Length.ShouldBe(87);

        records = VerseFilter.GetVerseList(" 42  : 3[2..] ").Value;

        records[0].Text.Length.ShouldBe(86);

        records = VerseFilter.GetVerseList(" 42  : 3[1..87] ").Value;
        records[0].Text.Length.ShouldBe(87);

        records = VerseFilter.GetVerseList(" 42  : 3[1..86] ").Value;
        records[0].Text.Length.ShouldBe(86);

        records = VerseFilter.GetVerseList(" 42  : 3[..86] ").Value;
        records[0].Text.Length.ShouldBe(86);

        records = VerseFilter.GetVerseList(" 42  : 3[..4] ").Value;
        records[0].Text.Length.ShouldBe(4);

        records = VerseFilter.GetVerseList(" 42 : 3[50..] -->  42 : 4[..5]").Value;
        records[1].Text.Length.ShouldBe(5);
    }

    [TestMethod]
    public void FilterWithStar()
    {
        var records = VerseFilter.GetVerseList(" 42  : * ").Value;

        records.Count.ShouldBe(53);

        records[2].Text.ShouldBe("كَذَٰلِكَ يُوحِىٓ إِلَيْكَ وَإِلَى ٱلَّذِينَ مِن قَبْلِكَ ٱللَّهُ ٱلْعَزِيزُ ٱلْحَكِيمُ");
    }

    [TestMethod]
    public void FilterWithStarWithMany()
    {
        var records = VerseFilter.GetVerseList(" 42  : * , 114 : *").Value;

        records.Count.ShouldBe(53 + 6);

        records[2].Text.ShouldBe("كَذَٰلِكَ يُوحِىٓ إِلَيْكَ وَإِلَى ٱلَّذِينَ مِن قَبْلِكَ ٱللَّهُ ٱلْعَزِيزُ ٱلْحَكِيمُ");

        records[52 + 6].Text.ShouldBe("مِنَ ٱلْجِنَّةِ وَٱلنَّاسِ");
    }

    [TestMethod]
    public void FilterWithStarWithManyWithSpecificAyahNumber()
    {
        var records = VerseFilter.GetVerseList(" 42  : * , 114 : *, 77:50").Value;

        records.Count.ShouldBe(53 + 6 + 1);

        records[2].Text.ShouldBe("كَذَٰلِكَ يُوحِىٓ إِلَيْكَ وَإِلَى ٱلَّذِينَ مِن قَبْلِكَ ٱللَّهُ ٱلْعَزِيزُ ٱلْحَكِيمُ");

        records[52 + 6].Text.ShouldBe("مِنَ ٱلْجِنَّةِ وَٱلنَّاسِ");

        records[52 + 6 + 1].Text.ShouldBe("فَبِأَىِّ حَدِيثٍۭ بَعْدَهُۥ يُؤْمِنُونَ");
    }

    [TestMethod]
    public void FilterWithStarWithManyWithSpecificAyahNumber_with_Error()
    {
        VerseFilter.GetVerseList(" 42  : * , 114 : *, 77:50, 115:*").HasError.ShouldBeTrue();
    }

    [TestMethod]
    public void SpecifiedWithRange()
    {
        var records = VerseFilter.GetVerseList(" 20  : 4- 7").Value;

        records.Count.ShouldBe(4);
        records[0].ChapterNumber.ShouldBe(20);
        records[1].ChapterNumber.ShouldBe(20);
        records[2].ChapterNumber.ShouldBe(20);
        records[3].ChapterNumber.ShouldBe(20);

        records[0].Index.ShouldBe(4);
        records[1].Index.ShouldBe(5);
        records[2].Index.ShouldBe(6);
        records[3].Index.ShouldBe(7);
    }
}