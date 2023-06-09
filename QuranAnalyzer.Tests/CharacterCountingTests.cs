﻿using static QuranAnalyzer.QuranAnalyzerMixin;
using static QuranAnalyzer.ArabicLetterOrder;
using static QuranAnalyzer.VerseFilter;

namespace QuranAnalyzer;

[TestClass]
public class CharacterCountingTests
{
    static readonly MushafOption AlifAccordingToTanzil = new() { UseElifReferencesFromTanzil = true };

    [TestMethod]
    public void AnalyzeVerseTest()
    {
        CountShouldBe("*", Daad, 1686);
    }

    [TestMethod]
    public void Chapter_10()
    {
        CountShouldBe("10:*", Raa, 257);
        CountShouldBe("10:*", Laam, 913);
        CountShouldBe("10:*", Alif, AlifAccordingToTanzil, 1323);
        CountShouldBe("10:*", Alif, 1319);
    }

    [TestMethod]
    public void Chapter_11()
    {
        CountShouldBe("11:*", Raa, 325);
        CountShouldBe("11:*", Laam, new MushafOption { Use_Laam_SpecifiedByTanzil = true }, 795);
        CountShouldBe("11:*", Laam, 794);
        CountShouldBe("11:*", Alif, AlifAccordingToTanzil, 1373);
        CountShouldBe("11:*", Alif, 1370);
    }

    [TestMethod]
    public void Chapter_12()
    {
        CountShouldBe("12:*", Raa, 257);
        CountShouldBe("12:*", Laam, 812);
        CountShouldBe("12:*", Alif, AlifAccordingToTanzil, 1315);
        CountShouldBe("12:*", Alif, 1306);
    }

    [TestMethod]
    public void Chapter_13()
    {
        CountShouldBe("13:*", Raa, 137);
        CountShouldBe("13:*", Miim, 260);
        CountShouldBe("13:*", Laam, 480);
        CountShouldBe("13:*", Alif, AlifAccordingToTanzil, 610);
        CountShouldBe("13:*", Alif, 605);
    }

    [TestMethod]
    public void Chapter_14()
    {
        CountShouldBe("14:*", Raa, 160);
        CountShouldBe("14:*", Laam, 452);
        CountShouldBe("14:*", Alif, AlifAccordingToTanzil, 589);
        CountShouldBe("14:*", Alif, 585);
    }

    [TestMethod]
    public void Chapter_15()
    {
        CountShouldBe("15:*", Raa, 96);
        CountShouldBe("15:*", Laam, 323);
        CountShouldBe("15:*", Alif, AlifAccordingToTanzil, 493);
        CountShouldBe("15:*", Alif, 493);
    }

    [TestMethod]
    public void Chapter_19()
    {
        CountShouldBe("19:*", Kaaf, 137);
        CountShouldBe("19:*", Haa_, 175);
        CountShouldBe("19:*", Yaa, 343);
        CountShouldBe("19:*", Ayn, 117);
        CountShouldBe("19:*", Saad, 26);
    }

    [TestMethod]
    public void Chapter_2()
    {
        CountShouldBe("2:*", Miim, 2195);
        CountShouldBe("2:*", Laam, 3202);
        CountShouldBe("2:*", Alif, AlifAccordingToTanzil, 4504);
        CountShouldBe("2:*", Alif, 4502);
    }

    [TestMethod]
    public void Chapter_20_26_27_28()
    {
        CountShouldBe("19:*", Haa_, 175);
        CountShouldBe("20:*", Haa_, 251);

        CountShouldBe("20:*", Taa_, 28);
        CountShouldBe("26:*", Taa_, 33);
        CountShouldBe("27:*", Taa_, 27);
        CountShouldBe("28:*", Taa_, 19);

        CountShouldBe("26:*", Siin, 94);
        CountShouldBe("27:*", Siin, 94);
        CountShouldBe("28:*", Siin, 102);

        CountShouldBe("26:*", Miim, 484);
        CountShouldBe("28:*", Miim, 460);
    }

    [TestMethod]
    public void Chapter_3()
    {
        CountShouldBe("3:*", Miim, 1249);
        CountShouldBe("3:*", Laam, 1892);
        CountShouldBe("3:*", Alif, AlifAccordingToTanzil, 2511);
        CountShouldBe("3:*", Alif, 2521);
    }

    [TestMethod]
    public void Chapter_36()
    {
        CountShouldBe("36:*", Yaa, 237);
        CountShouldBe("36:*", Siin, 48);
    }

    [TestMethod]
    public void Chapter_40_41_42_43_44_45_46_Ha_Mim()
    {
        CountShouldBe("40:*,41:*,42:*,43:*,44:*,45:*,46:*", Haa, 292);
        CountShouldBe("40:*,41:*,42:*,43:*,44:*,45:*,46:*", Miim, 1855);
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
        CountShouldBe("68:*", Nun, new MushafOption { Chapter_68_Should_Single_Nun = false }, 133);
        CountShouldBe("68:*", Nun, new MushafOption { Chapter_68_Should_Single_Nun = true }, 132);
    }

    [TestMethod]
    public void Chapter_7()
    {
        CountShouldBe("7:*", Saad, 97);
        CountShouldBe("7:*", Saad, new MushafOption { Use_Sad_in_Surah_7_Verse_69_in_word_bestaten = true }, 98);

        CountShouldBe("7:*", Miim, 1164);
        CountShouldBe("7:*", Laam, 1530);
        CountShouldBe("7:*", Alif, AlifAccordingToTanzil, 2521);
        CountShouldBe("7:*", Alif, 2529);
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
        CountShouldBe("40:*", Haa, 64);
        CountShouldBe("44:*", Haa, 16);
        CountShouldBe("45:*", Haa, 31);
        CountShouldBe("46:*", Haa, 36);

        CountShouldBe("40:*", Miim, 380);
        CountShouldBe("44:*", Miim, 150);
        CountShouldBe("45:*", Miim, 200);
        CountShouldBe("46:*", Miim, 225);
    }

    [TestMethod]
    public void Section_38()
    {
        CountShouldBe("42:*", Ayn, 98);
        CountShouldBe("42:*", Siin, 54);
        CountShouldBe("42:*", Qaaf, 57);
    }

    static void CountShouldBe(string searchScript, int arabicLetterOrder, int expectedCount)
    {
        GetVerseList(searchScript).Then(verses => GetCountOfLetter(verses, arabicLetterOrder)).ShouldBe(expectedCount);
    }

    static void CountShouldBe(string searchScript, int arabicLetterOrder, MushafOption option, int expectedCount)
    {
        GetVerseList(searchScript).Then(verses => GetCountOfLetter(verses, arabicLetterOrder, option)).ShouldBe(expectedCount);
    }
}