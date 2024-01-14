using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        AnaEkran();

        string dil = DilSecimi();
        BilgisayarKapatmaMenu(dil);

        Console.Write("Bir rakam yaz: ");
        string secim = Console.ReadLine();

        switch (secim)
        {
            case "1":
                BilgisayarKapat(60, dil);
                break;
            case "2":
                BilgisayarKapat(45, dil);
                break;
            case "3":
                BilgisayarKapat(30, dil);
                break;
            case "4":
                if (dil == "Turkce")
                    Console.WriteLine("Aktif Zamanlayiciyi Kapat seçeneği seçildi.");
                else if (dil == "English")
                    Console.WriteLine("Disable Active Timer option selected.");

                break;
            case "5":
                ZamanSecimi(dil);
                Console.Write("Bir rakam yaz: ");
                string zamanFormati = Console.ReadLine();

                if (zamanFormati == "1")
                {
                    Console.Write("Kac saat sonra bilgisayarin kapansin: ");
                    int saat = Convert.ToInt32(Console.ReadLine());
                    BilgisayarKapat(saat * 60, dil);
                }
                else if (zamanFormati == "2")
                {
                    Console.Write("Kac dakika sonra bilgisayarin kapansin: ");
                    int dakika = Convert.ToInt32(Console.ReadLine());
                    BilgisayarKapat(dakika, dil);
                }
                else
                {
                    Console.WriteLine("Geçersiz bir seçim.");
                }
                break;
            default:
                Console.WriteLine("Geçersiz bir seçim.");
                break;
        }

        Console.ReadLine();
    }

    static void AnaEkran()
    {
        Console.Clear();
        Console.WriteLine(@"
   _____ _           _      _                     
  / ____| |         | |    | |                    
 | (___ | |__  _   _| |_ __| | _____      ___ __  
  \___ \| '_ \| | | | __/ _` |/ _ \ \ /\ / / '_ \ 
  ____) | | | | |_| | || (_| | (_) \ V  V /| | | |
 |_____/|_| |_|\__,_|\__\__,_|\___/ \_/\_/ |_| |_|
                                                                                 
                 by Emre Kocaayak



[?] Dilini sec / Select your language.

[1] Turkce
[2] English
");
    }

    static string DilSecimi()
    {
        while (true)
        {
            Console.Write("Bir numara yazin / Type a number: ");
            string dilSecim = Console.ReadLine();
            if (dilSecim == "1")
                return "Turkce";
            else if (dilSecim == "2")
                return "English";
            else
                Console.WriteLine("Geçersiz bir seçim, lütfen '1' veya '2' yazin.");
        }
    }

    static void BilgisayarKapatmaMenu(string dil)
    {
        Console.Clear();
        Console.WriteLine($"\n[?] Bilgisayarinin ne zaman kapanacagini sec / Select when your computer will shut down.\n");

        if (dil == "Turkce")
        {
            Console.WriteLine("[1] 1 Saat sonra");
            Console.WriteLine("[2] 45 Dakika sonra");
            Console.WriteLine("[3] 30 Dakika sonra");
            Console.WriteLine("[4] Aktif Zamanlayiciyi Kapat");
            Console.WriteLine("[5] Ozel Ayarla");
        }
        else if (dil == "English")
        {
            Console.WriteLine("[1] 1 Hour later");
            Console.WriteLine("[2] 45 Minutes later");
            Console.WriteLine("[3] 30 Minutes later");
            Console.WriteLine("[4] Disable Active Timer");
            Console.WriteLine("[5] Set Custom Timer");
        }
    }

    static void ZamanSecimi(string dil)
    {
        Console.Clear();
        Console.WriteLine($"\n[?] Zaman formatini sec / Select time format.\n");

        if (dil == "Turkce")
        {
            Console.WriteLine("[1] Saat");
            Console.WriteLine("[2] Dakika");
        }
        else if (dil == "English")
        {
            Console.WriteLine("[1] Hour");
            Console.WriteLine("[2] Minute");
        }
    }

    static void BilgisayarKapat(int zaman, string dil)
    {
        try
        {
            Console.Clear();
            if (dil == "Turkce")
                Console.WriteLine($"\nBilgisayarınız {zaman} dakika sonra kapatılmak üzere ayarlanmıştır.");
            else if (dil == "English")
                Console.WriteLine($"\nYour computer is scheduled to shut down in {zaman} minutes.");

            Thread.Sleep(zaman * 60 * 1000);
            Process.Start("shutdown", "/s /t 1");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata oluştu: {ex.Message}");
        }
    }
}

