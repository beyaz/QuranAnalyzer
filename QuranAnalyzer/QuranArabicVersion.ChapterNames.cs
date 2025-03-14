﻿namespace QuranAnalyzer;

public static class QuranArabicVersionChapterNames
{
    public static readonly IReadOnlyList<string> ChapterNames
        = Parse(
                """
                الفاتحة
                البقرة
                آل عمران
                النساء
                المائدة
                الأنعام
                الأعراف
                الأنفال
                بَرَاءةٌ
                يونس
                هود
                يوسف
                الرعد
                إبراهيم
                الحجر
                النحل
                بَنِىٓ إِسْرَٰٓءِيلَ
                الكهف
                مريم
                طه
                الأنبياء
                الحج
                المؤمنون
                النور
                الفرقان
                الشعراء
                النمل
                القصص
                العنكبوت
                الروم
                لقمان
                السجدة
                الأحزاب
                سبأ
                فاطر
                يس
                الصافات
                ص
                الزمر
                غافر
                فصلت
                الشورى
                الزخرف
                الدخان
                الجاثية
                الأحقاف
                محمد
                الفتح
                الحجرات
                ق
                الذاريات
                الطور
                النجم
                القمر
                الرحمن
                الواقعة
                الحديد
                المجادلة
                الحشر
                الممتحنة
                الصف
                الجمعة
                المنافقون
                التغابن
                الطلاق
                التحريم
                الملك
                القلم
                الحاقة
                المعارج
                نوح
                الجن
                المزمل
                المدثر
                القيامة
                الإنسان
                المرسلات
                النبأ
                النازعات
                عبس
                التكوير
                الإنفطار
                المطففين
                الإنشقاق
                البروج
                الطارق
                الأعلى
                الغاشية
                الفجر
                البلد
                الشمس
                الليل
                الضحى
                الشرح
                التين
                العلق
                القدر
                البينة
                الزلزلة
                العاديات
                القارعة
                التكاثر
                العصر
                الهمزة
                الفيل
                قريش
                الماعون
                الكوثر
                الكافرون
                النصر
                المسد
                الإخلاص
                الفلق
                الناس
                """);

    static IReadOnlyList<string> Parse(string lines)
    {
        return lines.Split("\n").Select(x => x.Trim()).ToList();
    }
}