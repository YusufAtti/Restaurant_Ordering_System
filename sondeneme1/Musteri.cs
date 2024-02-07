using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sondeneme1
{
    public class Musteri
    {
        private int musteriNo;
        private string durum;
        private Button btn;
        private bool oncelik;
        public Musteri(int musteriNo, Button btn, string durum, bool oncelik)
        {
            this.MusteriNo = musteriNo;
            this.Btn = btn;
            this.Durum = durum;
            this.Oncelik = oncelik;
        }

        public int MusteriNo { get => musteriNo; set => musteriNo = value; }
        public string Durum { get => durum; set => durum = value; }
        public Button Btn { get => btn; set => btn = value; }
        public bool Oncelik { get => oncelik; set => oncelik = value; }
    }
}
