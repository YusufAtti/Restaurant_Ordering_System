using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sondeneme1
{
    public class Musteri1
    {
        private int musteriNo;
        private string durum;
        public Musteri1(int musteriNo, string durum)
        {
            this.MusteriNo = musteriNo;
            this.Durum = durum;
        }

        public int MusteriNo { get => musteriNo; set => musteriNo = value; }
        public string Durum { get => durum; set => durum = value; }
     

    }
}
