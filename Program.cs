using System;
using tpmodul8_103022300011;

class Program
{
    public static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu1 = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam1 = int.Parse(Console.ReadLine());

        bool suhuNormal1 = false;

        if (config.satuan_suhu == "celcius")
        {
            suhuNormal1 = suhu1 >= 36.5 && suhu1 <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuNormal1 = suhu1 >= 97.7 && suhu1 <= 99.5;
        }

        if (suhuNormal1 && hariDemam1 < config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Panggil method ubah satuan
        config.UbahSatuan();
        Console.WriteLine($"Suhu diubah menjadi {config.satuan_suhu}...");
        
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu2 = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam2 = int.Parse(Console.ReadLine());

        bool suhuNormal2 = false;

        if (config.satuan_suhu == "celcius")
        {
            suhuNormal2 = suhu2 >= 36.5 && suhu2 <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuNormal2 = suhu2 >= 97.7 && suhu2 <= 99.5;
        }

        if (suhuNormal2 && hariDemam2 < config.batas_hari_deman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
