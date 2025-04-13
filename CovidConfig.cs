using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300011
{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; } //menyimpan satuan suhu (celcius/fahrenheit)
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; } //pesan jika tidak lolos dalam pengecekan(melewati batas hari dan range suhu)
        public string pesan_diterima { get; set; }//pesan jika lolos dalam pengecekan

        public static string configFile = "covid_config.json";

        //constructor default: menetapkan nilai awal jika file belum ada
        public CovidConfig()
        {
            satuan_suhu = "celcius";
            batas_hari_deman = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        //factory method untuk load config dari file
        public static CovidConfig LoadConfig()
        {
            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);
                return JsonSerializer.Deserialize<CovidConfig>(json);
            }
            else
            {
                // Kalau file tidak ada, buat config default dan simpan
                var config = new CovidConfig();
                config.Save();
                return config;
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(configFile, json);
        }

        public void UbahSatuan()
        {
            satuan_suhu = (satuan_suhu == "celcius") ? "fahrenheit" : "celcius";
            Save();
        }
    }
}