using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sondeneme1
{
    public class Masa
    {
        private bool doluMu;
        private int masaNo;
        private Button btn;
        private Musteri musteri;

        public Masa(bool doluMu, int masaNo, Button btn)
        {
            this.DoluMu = doluMu;
            this.MasaNo = masaNo;
            this.Btn = btn;

        }
        public bool DoluMu { get => doluMu; set => doluMu = value; }
        public int MasaNo { get => masaNo; set => masaNo = value; }
        public Button Btn { get => btn; set => btn = value; }
        public Musteri Musteri { get => musteri; set => musteri = value; }
    }
}
