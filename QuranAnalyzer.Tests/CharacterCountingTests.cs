using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer;

[TestClass]
public class CharacterCountingTests
{
    static readonly MushafOption AlefAccordingToTanzil = new() { UseElifReferencesFromTanzil = true };

    [TestMethod]
    public void AnalyzeVerseTest()
    {
        CountShouldBe("*", Daad, 1686);
    }

    [TestMethod]
    public void Chapter_10()
    {
        CountShouldBe("10:*", Raa, 257);
        CountShouldBe("10:*", Lam, 913);
        CountShouldBe("10:*", Alef, AlefAccordingToTanzil, 1323);
        CountShouldBe("10:*", Alef, 1319);
    }

    [TestMethod]
    public void Chapter_11()
    {
        CountShouldBe("11:*", Raa, 325);
        CountShouldBe("11:*", Lam, new MushafOption { Use_Lam_SpecifiedByTanzil = true }, 795);
        CountShouldBe("11:*", Lam, 794);
        CountShouldBe("11:*", Alef, AlefAccordingToTanzil, 1373);
        CountShouldBe("11:*", Alef, 1370);
    }

    [TestMethod]
    public void Chapter_12()
    {
        CountShouldBe("12:*", Raa, 257);
        CountShouldBe("12:*", Lam, 812);
        CountShouldBe("12:*", Alef, AlefAccordingToTanzil, 1315);
        CountShouldBe("12:*", Alef, 1306);
    }

    [TestMethod]
    public void Chapter_13()
    {
        CountShouldBe("13:*", Raa, 137);
        CountShouldBe("13:*", Meem, 260);
        CountShouldBe("13:*", Lam, 480);
        CountShouldBe("13:*", Alef, AlefAccordingToTanzil, 610);
        CountShouldBe("13:*", Alef, 605);
    }

    [TestMethod]
    public void Chapter_14()
    {
        CountShouldBe("14:*", Raa, 160);
        CountShouldBe("14:*", Lam, 452);
        CountShouldBe("14:*", Alef, AlefAccordingToTanzil, 589);
        CountShouldBe("14:*", Alef, 585);
    }

    [TestMethod]
    public void Chapter_15()
    {
        CountShouldBe("15:*", Raa, 96);
        CountShouldBe("15:*", Lam, 323);
        CountShouldBe("15:*", Alef, AlefAccordingToTanzil, 493);
        CountShouldBe("15:*", Alef, 493);
    }

    [TestMethod]
    public void Chapter_19()
    {
        CountShouldBe("19:*", Kaf, 137);
        CountShouldBe("19:*", Heh, 175);
        CountShouldBe("19:*", Yeh, 343);
        CountShouldBe("19:*", Ain, 117);
        CountShouldBe("19:*", Saad, 26);
    }

    [TestMethod]
    public void Chapter_2()
    {
        CountShouldBe("2:*", Meem, 2195);
        CountShouldBe("2:*", Lam, 3202);
        CountShouldBe("2:*", Alef, AlefAccordingToTanzil, 4504);
        CountShouldBe("2:*", Alef, 4502);
    }

    [TestMethod]
    public void Chapter_20_26_27_28()
    {
        CountShouldBe("19:*", Heh, 175);
        CountShouldBe("20:*", Heh, 251);

        CountShouldBe("20:*", Tah, 28);
        CountShouldBe("26:*", Tah, 33);
        CountShouldBe("27:*", Tah, 27);
        CountShouldBe("28:*", Tah, 19);

        CountShouldBe("26:*", Seen, 94);
        CountShouldBe("27:*", Seen, 94);
        CountShouldBe("28:*", Seen, 102);

        CountShouldBe("26:*", Meem, 484);
        CountShouldBe("28:*", Meem, 460);
    }

    [TestMethod]
    public void Chapter_3()
    {
        CountShouldBe("3:*", Meem, 1249);
        CountShouldBe("3:*", Lam, 1892);
        CountShouldBe("3:*", Alef, AlefAccordingToTanzil, 2511);
        CountShouldBe("3:*", Alef, 2521);
    }

    [TestMethod]
    public void Chapter_36()
    {
        CountShouldBe("36:*", Yeh, 237);
        CountShouldBe("36:*", Seen, 48);
    }

    [TestMethod]
    public void Chapter_40_41_42_43_44_45_46_Ha_Mim()
    {
        CountShouldBe("40:*,41:*,42:*,43:*,44:*,45:*,46:*", Hah, 292);
        CountShouldBe("40:*,41:*,42:*,43:*,44:*,45:*,46:*", Meem, 1855);
    }

    [TestMethod]
    public void Chapter_42()
    {
        CountShouldBe("42:*", Qaaf, 57);
    }

    [TestMethod]
    public void Chapter_50()
    {
        CountShouldBe("50:*", Qaaf, 57);
    }

    [TestMethod]
    public void Chapter_68()
    {
        CountShouldBe("68:*", Noon, new MushafOption { Chapter_68_Should_Single_Noon = false }, 133);
        CountShouldBe("68:*", Noon, new MushafOption { Chapter_68_Should_Single_Noon = true }, 132);
    }

    [TestMethod]
    public void Chapter_7()
    {
        CountShouldBe("7:*", Saad, 97);
        CountShouldBe("7:*", Saad, new MushafOption { Use_Sad_in_Surah_7_Verse_69_in_word_bestaten = true }, 98);

        CountShouldBe("7:*", Meem, 1164);
        CountShouldBe("7:*", Lam, 1530);
        CountShouldBe("7:*", Alef, AlefAccordingToTanzil, 2521);
        CountShouldBe("7:*", Alef, 2529);
    }

    [TestMethod]
    public void Sad_in_38_and_19_and_7()
    {
        CountShouldBe("38:*", Saad, 29);
        CountShouldBe("19:*", Saad, 26);
        CountShouldBe("7:* ", Saad, 97);
    }

    [TestMethod]
    public void Section_37()
    {
        CountShouldBe("40:*", Hah, 64);
        CountShouldBe("44:*", Hah, 16);
        CountShouldBe("45:*", Hah, 31);
        CountShouldBe("46:*", Hah, 36);

        CountShouldBe("40:*", Meem, 380);
        CountShouldBe("44:*", Meem, 150);
        CountShouldBe("45:*", Meem, 200);
        CountShouldBe("46:*", Meem, 225);
    }

    [TestMethod]
    public void Section_38()
    {
        CountShouldBe("42:*", Ain, 98);
        CountShouldBe("42:*", Seen, 54);
        CountShouldBe("42:*", Qaaf, 57);
    }

    static void CountShouldBe(string searchScript, int arabicLetterOrder, int expectedCount)
    {
        (from verses in GetVerseList(searchScript) select GetCountOfLetter(verses, arabicLetterOrder)).ShouldBe(expectedCount);
    }

    static void CountShouldBe(string searchScript, int arabicLetterOrder, MushafOption option, int expectedCount)
    {
        (from verses in GetVerseList(searchScript) select GetCountOfLetter(verses, arabicLetterOrder, option)).ShouldBe(expectedCount);
    }
}