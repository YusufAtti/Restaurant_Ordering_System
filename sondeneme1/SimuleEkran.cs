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
using System.IO;


namespace sondeneme1
{
    public partial class SimuleEkran : Form
    {
        private int musteriSayisi;
        private int oncelikSayisi;
        private int masaSayisi;
        private int garsonSayisi;
        private int asciSayisi;
        Random rnd = new Random();
        Queue<Musteri> musteriler = new Queue<Musteri>();
        Queue<Musteri> bekleyenMusteriler = new Queue<Musteri>();
        List<Musteri> musterilerList = new List<Musteri>();
        Dictionary<Masa, SemaphoreSlim> masalarSem = new Dictionary<Masa, SemaphoreSlim>();
        List<Masa> masalar = new List<Masa>();
        List<Garson> garsonlar = new List<Garson>();
        SemaphoreSlim sefSem = new SemaphoreSlim(4, 4);
        SemaphoreSlim kasaSem = new SemaphoreSlim(1, 1);
        Queue<Musteri> kasaBekleyenMusteriler = new Queue<Musteri>();

        public SimuleEkran()
        {
            InitializeComponent();
        }

        public SimuleEkran(int musteriSayisi, int oncelikSayisi, int masaSayisi, int garsonSayisi, int asciSayisi)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.MusteriSayisi = musteriSayisi;
            this.OncelikSayisi = oncelikSayisi;
            this.MasaSayisi = masaSayisi;
            this.GarsonSayisi = garsonSayisi;
            this.AsciSayisi = asciSayisi;
            

            for (int i = 0; i < MasaSayisi; i++)
            {

                masalar.Add(new Masa(false, i + 1, new Button()));
                masalar[i].Btn.Text = $"Masa {masalar[i].MasaNo}";

                masalar[i].Btn.Width = 100;
                masalar[i].Btn.Height = 80;

                if (i < (MasaSayisi / 2))
                {
                    masalar[i].Btn.Top = 100;
                    masalar[i].Btn.Left = 130 + (i * 105);

                }
                else
                {
                    masalar[i].Btn.Top = 220;
                    masalar[i].Btn.Left = 130 + ((i - (MasaSayisi / 2)) * 105);
                }


                Controls.Add(masalar[i].Btn);

            }

            for (int i = 0; i < musteriSayisi; i++)
            {

                    musterilerList.Add(new Musteri(i + 1, new Button(), "Bekliyor", false));
                    
            }

            int randomOncelikli = OncelikSayisi;
            while (randomOncelikli > 0)
            {
                int randomIndex = rnd.Next(musterilerList.Count);
                Console.WriteLine("Random sayi : " + randomIndex);
                if (musterilerList[randomIndex].Oncelik != true)
                {
                    Console.WriteLine("Musteri No : " + musterilerList[randomIndex].MusteriNo);
                    musterilerList[randomIndex].Oncelik = true;
                    randomOncelikli--;
                }
            }

           
            var siraliMusteriListe = musterilerList.OrderByDescending(m => m.Oncelik);

            for (int i = 0; i < siraliMusteriListe.Count(); i++)
            {
                siraliMusteriListe.ElementAt(i).Btn.Text = $"Musteri {siraliMusteriListe.ElementAt(i).MusteriNo} ({siraliMusteriListe.ElementAt(i).Durum})";
                siraliMusteriListe.ElementAt(i).Btn.Text += siraliMusteriListe.ElementAt(i).Oncelik;
                siraliMusteriListe.ElementAt(i).Btn.Width = 80;
                siraliMusteriListe.ElementAt(i).Btn.Height = 50;
                siraliMusteriListe.ElementAt(i).Btn.Top = 100 + (i * 50);
                siraliMusteriListe.ElementAt(i).Btn.Left = 20;
                Controls.Add(siraliMusteriListe.ElementAt(i).Btn);
                musteriler.Enqueue(siraliMusteriListe.ElementAt(i));

            }

            for (int i = 0; i < GarsonSayisi; i++)
            {
                garsonlar.Add(new Garson((i + 1), false, new Button()));
                garsonlar[i].Btn.Text = $"Garson {garsonlar[i].GarsonNo}";
                garsonlar[i].Btn.Width = 80;
                garsonlar[i].Btn.Height = 50;
                garsonlar[i].Btn.Top = 400;
                garsonlar[i].Btn.Left = 130 + (i * 85);
                Controls.Add(garsonlar[i].Btn);

            }

            foreach (var masa in masalar)
            {
                masalarSem[masa] = new SemaphoreSlim(1, 1); 
            }
        }

        public void musteriOturttur(Musteri musteri)
        {
            int oturdu = 0;

            foreach (var masa in masalar)
            {
                lock (masa)
                {
                    if (!masa.DoluMu && musteri.Durum == "Bekliyor")
                    {
                        masa.DoluMu = true;
                        masa.Musteri = musteri;
                        musteri.Durum = "Garson Bekliyor";
                        Console.WriteLine("Musteri " + masa.Musteri.MusteriNo + " Masa " + masa.MasaNo + " oturdu. Garson Bekliyor.");
                        masa.Btn.Text += "\n" + masa.Musteri.MusteriNo + " Musteri " + masa.Musteri.Durum;
                        musteri.Btn.Visible = false;
                        oturdu = 1;
                        break;
                    }
                }
            }

            if (oturdu == 0)
            {
                Console.WriteLine("Musteri Bekleme Listesine alındı. :" + musteri.MusteriNo);
                bekleyenMusteriler.Enqueue(musteri);
            }

        }

        public object fileLock = new object();

        public void siparisAl(Garson garson)
        {
            while (true)
            {
                foreach (var masa in masalar)
                {
                    if (masa.Musteri != null && masa.Musteri.Durum == "Garson Bekliyor")
                    {
                        if (masalarSem[masa].Wait(0))
                        {
                            lock (masa)
                            {
                                if (masa.Musteri != null && masa.Musteri.Durum == "Garson Bekliyor")
                                {
                                    lock (masa.Btn)
                                    {
                                        lock (masa.Musteri)
                                        {
                                            Console.WriteLine("Garson " + garson.GarsonNo  + " Masa " + masa.MasaNo + "'den Sipariş Alıyor.");
                                            masa.Btn.Text += "\n" + garson.GarsonNo + " Garson " + masa.MasaNo + "'den Sipariş Alıyor.";
                                            Thread.Sleep(2000);
                                            masa.Musteri.Durum = "Musteri " + masa.Musteri.MusteriNo + "Siparis Bekliyor";
                                            int r = rnd.Next(256);
                                            int g = rnd.Next(256);
                                            int b = rnd.Next(256);
                                            masa.Btn.BackColor = Color.FromArgb(r, g, b);
                                            garson.Btn.BackColor = Color.FromArgb(r, g, b);
                                            sefSem.Wait();
                                            Console.WriteLine("Musteri " + masa.Musteri.MusteriNo + "'nin siparişini şef hazırlıyor");
                                            masa.Btn.Text += "\n" + "Şef Hazırlıyor.";
                                            Thread.Sleep(3000);
                                            Console.WriteLine("Musteri " + masa.Musteri.MusteriNo + " için Şef Hazırladı Müşteri Yedi Kasaya Ödemeye Geçti.");
                                            masa.Btn.Text = "\n" + "Şef Hazırladı Müşteri Yedi Kasaya Ödemeye Geçti.";
                                            Thread.Sleep(1000);
                                            sefSem.Release();
                                            // Sipariş alma işlemi bittikten sonra serbest bırak
                                            masalarSem[masa].Release();
                                            masa.DoluMu = false;
                                            kasaBekleyenMusteriler.Enqueue(masa.Musteri);

                                            lock (bekleyenMusteriler)
                                            {
                                                if (bekleyenMusteriler.Count > 0)
                                                {

                                                    new Thread(() => musteriOturttur(bekleyenMusteriler.Dequeue())).Start();

                                                }
                                            }

                                            masa.Btn.BackColor = Color.Green;
                                            masa.Btn.Text = "Masa " + masa.MasaNo.ToString();
                                            garson.Btn.BackColor = Color.Green;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(200);
            }
        }

        public void kasaKontrol()
        {
            int a = 1;

            while (true)
            {
                if (kasaBekleyenMusteriler.Count > 0)
                {
                    if (kasaSem.Wait(0))
                    {
                        Console.WriteLine("Kasada bekleyen kisi sayisi : " + kasaBekleyenMusteriler.Count);
                        Musteri ms = kasaBekleyenMusteriler.Dequeue();
                        if (ms == null)
                            break;
                        kasaBtn.BackColor = Color.Gray;
                        a++;
                        Console.WriteLine("Musteri " + ms.MusteriNo + " Ödemeye geçti.");
                        Thread.Sleep(1000);
                        Console.WriteLine("Musteri " + ms.MusteriNo + " Ödemeyi tamamladı restorandan ayrıldı.");
                        kasaSem.Release();
                        kasaBtn.BackColor = Color.Green;


                    }
                }
            }

        }
        public int MusteriSayisi { get => musteriSayisi; set => musteriSayisi = value; }
        public int OncelikSayisi { get => oncelikSayisi; set => oncelikSayisi = value; }
        public int MasaSayisi { get => masaSayisi; set => masaSayisi = value; }
        public int GarsonSayisi { get => garsonSayisi; set => garsonSayisi = value; }
        public int AsciSayisi { get => asciSayisi; set => asciSayisi = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Musteri Sayisi : " + musteriler.Count);
            while (musteriler.Count > 0) 
            {
                Musteri ms = musteriler.Dequeue();
                Thread t = new Thread(() => musteriOturttur(ms));
                t.Start();
                t.Join(); 
            }

            foreach (var item in garsonlar)
            {

                new Thread(() => siparisAl(item)).Start();

            }

            new Thread(() => kasaKontrol()).Start();


        }
    }
}
