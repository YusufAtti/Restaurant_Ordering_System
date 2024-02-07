using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace sondeneme1
{
    public partial class Problem2 : Form
    {
        private int saniye;
        List<Musteri1> musteriListesi = new List<Musteri1>();
        Dictionary<int, int> musteriDictionary = new Dictionary<int, int>();
        static readonly object lockObject = new object();
        SemaphoreSlim garsonSem;
        SemaphoreSlim masaSem;
        SemaphoreSlim asciSem;
        SemaphoreSlim kasaSem = new SemaphoreSlim(1,1);

        int totalMusteri = 0;
        int eklenenmusteri = 0;
        int silinenmusteri = 0;
        int silinemeyenmusteri = 0;

        public void masaOtur(Musteri1 ms)
        {

            while (ms.Durum == "Bekliyor")
            {
                if (masaSem.Wait(0))
                {
                    totalMusteri++;
                    try
                    {
                        lock (musteriListesi)
                            musteriListesi.Remove(ms);
                        //Console.WriteLine("Musteri " + ms.MusteriNo + " Masaya Oturdu. Garson bekliyor.");
                        garsonSem.Wait();
                        //Console.WriteLine("Musteri " + ms.MusteriNo + " Sipariş Veriyor.");
                        Thread.Sleep(2);
                        //Console.WriteLine("Musteri " + ms.MusteriNo + " Siparişi verdi. Bekliyor...");
                        asciSem.Wait();
                        //Console.WriteLine("Musterinin yemeği hazırlanıyor.");
                        Thread.Sleep(3);
                        //Console.WriteLine("Musterinin yemeği geldi.");
                        Thread.Sleep(3);
                        //Console.WriteLine("Musterinin yemeği yedi.");
                        kasaSem.Wait();
                        Thread.Sleep(1);
                        //Console.WriteLine("Musterini hesabı ödedi restorandan ayrıldı.");
                        ms.Durum = "Ayrıldı";
                        //Thread.Sleep(9);
                        ms.Durum = "Ayrıldı";
                    }
                    finally
                    {

                        masaSem.Release();
                        kasaSem.Release();
                        asciSem.Release();
                        garsonSem.Release();

                    }
                }
            }

        }

        public void masaOtur1(Musteri1 ms)
        {

            while (ms.Durum == "Bekliyor")
            {
                if (masaSem.Wait(0))
                {
                    totalMusteri++;
                    try
                    {
                        lock (musteriListesi)
                            musteriListesi.Remove(ms);
                        Thread.Sleep(9);
                        ms.Durum = "Ayrıldı";
                    }
                    finally
                    {

                        masaSem.Release();

                    }
                }
            }

        }


        public void yontem1()
        {
            int maxMusteri = Saniye / 5 * 4;

            for (int a = 1; a <= maxMusteri; a++)
            {
                masaSem = new SemaphoreSlim(a, a);

                for (int b = 1; b <= maxMusteri; b++)
                {
                    garsonSem = new SemaphoreSlim(b, b);

                    for (int c = 1; c <= maxMusteri; c++)
                    {
                        asciSem = new SemaphoreSlim(c, c);

                        for (int j = 1; j <= Saniye; j++)
                        {
                            if (j % 5 == 0)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    eklenenmusteri++;
                                    Musteri1 yeniMusteri = new Musteri1(i + 1, "Bekliyor"); // Musteri sınıfınıza göre burada nesne oluşturun.
                                    new Thread(() => masaOtur(yeniMusteri)).Start();
                                    lock (musteriListesi)
                                        musteriListesi.Add(yeniMusteri);
                                    ThreadPool.QueueUserWorkItem(SilmeIslemi, yeniMusteri);
                                }

                            }

                        }
                        musteriDictionary.Add(a * b * c, silinenmusteri);
                        Thread.Sleep(200);
                        asciSem = null;

                    }

                    Thread.Sleep(200);
                    garsonSem = null;

                }

                Thread.Sleep(200);

                masaSem = null;

            }

            int kazanc = musteriDictionary[1];
            Console.WriteLine("Kazanç : " + kazanc);


        }

        public void yontem2()
        {
            int maxMusteri = Saniye / 5 * 4;

            for (int a = 1; a <= maxMusteri; a++)
            {
                masaSem = new SemaphoreSlim(a, a);
               
                        for (int j = 1; j <= Saniye; j++)
                        {
                            if (j % 5 == 0)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    eklenenmusteri++;
                                    Musteri1 yeniMusteri = new Musteri1(i + 1, "Bekliyor"); 
                                    new Thread(() => masaOtur1(yeniMusteri)).Start();
                                    lock (musteriListesi)
                                        musteriListesi.Add(yeniMusteri);
                                    ThreadPool.QueueUserWorkItem(SilmeIslemi, yeniMusteri);
                                }

                            }

                        }


                musteriDictionary.Add(a, silinenmusteri - a);
                silinemeyenmusteri = 0;
                eklenenmusteri = 0;
                silinenmusteri = 0;
                totalMusteri = 0;
                lock (musteriListesi)
                    musteriListesi.Clear();
                Thread.Sleep(200);
                masaSem = null;

            }

            int maxkazanc = musteriDictionary[1];
            for (int i = 0; i < musteriDictionary.Count; i++)
            {
                if(musteriDictionary[i + 1] > maxkazanc)
                {
                    maxkazanc = musteriDictionary[i + 1];
                }

            }

            Console.WriteLine("Kazanç : " + maxkazanc);

        }


        public Problem2(int saniye)
        {

            InitializeComponent();
            this.Saniye = saniye;

        }

        public void SilmeIslemi(object musteriObj)
        {

            Musteri1 silinecekMusteri = (Musteri1)musteriObj;

            Thread.Sleep(20);

            lock (musteriListesi)
            {
                if (musteriListesi.Contains(silinecekMusteri))
                {

                    musteriListesi.Remove(silinecekMusteri);
                    silinenmusteri++;

                }
                else
                {

                    silinemeyenmusteri++;

                }
            }
        }


        public int Saniye { get => saniye; set => saniye = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            yontem2();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            yontem1();

        }
    }
}
