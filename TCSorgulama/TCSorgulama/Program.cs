using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcKimlikService;

namespace TCSorgulama
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcKimlikService.KPSPublicSoapClient();

            string ad, soyad, tc;
            //console ekranından girilmesini istediğimiz ifadeler 
            Console.Write("Ad: ");
            ad = Console.ReadLine();
            Console.Write("Soyad : ");
            soyad = Console.ReadLine();
            Console.Write("Dogum Tarihi: ");
            DateTime dogumTarihi = DateTime.Parse(Console.ReadLine());
            Console.Write("TC: ");
            tc = Console.ReadLine();
            
            if (Convert.ToInt64(tc) / 10000000000 != 0)  // tc 11 haneli olarak doğru girilmiş mi kontrol etmek için
            {
                Console.WriteLine("ust soy : {0}", sorgula(tc));  // sorgula fonk. ile geri dönen değeri yaz
            }
            else  // tc 11 haneli olarak girilmemiş ise
            {
                Console.WriteLine("Lutfen gecerli bir tc giriniz. !!");  //tekrar bir tc iste
                Console.Write("TC: ");
                tc = Console.ReadLine();
                Console.WriteLine("ust soy : {0}", sorgula(tc));
            }

            Console.ReadKey();
        }

       public static string sorgula (string tc )
        {
            // degiskenleri tanımlama
            string bolumBir, bolumIki, bolumDort, value2;
            long bolum1, kisim1, bolum2, kisim2, bolum3, bolum4, kisim4, deger2;
            long toplam1 = 0, toplam2 = 0, sonuc = 0;

            //birinci bolum icin gerekli olan kısım bulunur 
            bolumBir = tc.Substring(0, 5);
            string value1 = bolumBir.Substring(2, 1);
            int deger1 = Convert.ToInt16(value1);
            bolum1 = Convert.ToInt64(bolumBir);

            //ikinci bolum icin gerekli olan kısım bulunur 
            bolumIki = tc.Substring(5, 4);
            string value3 = bolumIki.Substring(1, 1);
            int deger3 = Convert.ToInt16(value3);
            bolum2 = Convert.ToInt64(bolumIki);

            //dorduncu bolum icin gerekli olan kısım bulunur 
            bolumDort = tc.Substring(10);
            bolum4 = Convert.ToInt64(bolumDort);

            //birinci bolumu 3 ile toplama
            bolum1 = bolum1 + 3;
            string value22 = bolum1.ToString();
            value2 = value22.Substring(2, 1);
            deger2 = Convert.ToInt16(value2);

            //ikinci bolumden 1 çıkar
            bolum2 = bolum2 - 1;
            string value44 = bolum2.ToString();
            string value4 = value44.Substring(1, 1);
            int deger4 = Convert.ToInt16(value4);

            if (deger1 != deger2)  //birinci bolumde 2.indis değismis mi kontrol et
            {
                if (deger2 < 6)
                {
                    bolum4 += 10;
                    bolum4 -= 6;
                }
                else
                {
                    bolum4 -= 6;
                }
            }
            else if (deger3 != deger4) // ikinci bolumde 1.indis degismis mi kontrol et
            {
                if (deger4 < 2)
                {
                    bolum4 += 10;
                    bolum4 -= 2;
                }
                else
                {
                    bolum4 -= 2;
                }
            }
            else  // indislerde degisim yoksa
            {
                if (bolum4 < 4)
                {
                    bolum4 += 10;
                    bolum4 -= 4;

                }
                else
                {
                    bolum4 -= 4;
                }
            }
            // basamak degerlerini toplamadan once bolum icindeki degerleri baska bir degiskene atama 
            kisim1 = bolum1;
            kisim2 = bolum2;
            kisim4 = bolum4;
            //basamak degerlerini toplama
            while (bolum1 > 0)
            {
                toplam1 += bolum1 % 10;
                bolum1 = bolum1 / 10;
            }
            while (bolum2 > 0)
            {
                toplam2 += bolum2 % 10;
                bolum2 = bolum2 / 10;
            }
            sonuc = toplam1 + toplam2;

            long sonRakam = sonuc % 10;
            if (sonRakam > bolum4)
            {
                bolum4 += 10;
                bolum3 = bolum4 - sonRakam;

            }
            else
            {
                bolum3 = bolum4 - sonRakam;
            }
            //int degerlerini string turune cevirerek birlestirme
            string kisim11 = Convert.ToString(kisim1);
            string kisim22 = Convert.ToString(kisim2);
            string kisim33 = Convert.ToString(bolum3);
            string kisim44 = Convert.ToString(kisim4);
            string TC = kisim11 + kisim22 + kisim33 + kisim44;
            return TC;


        }

    }
}
    