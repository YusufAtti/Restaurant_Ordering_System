using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sondeneme1
{
    public class Garson
    {
        private int garsonNo;
        private bool mesgulMu;
        private Button btn;
        private Masa masa;

        public Garson(int garsonNo, bool mesgulMu, Button btn)
        {
            this.GarsonNo = garsonNo;
            this.MesgulMu = mesgulMu;
            this.Btn = btn;
        }

        public int GarsonNo { get => garsonNo; set => garsonNo = value; }
        public bool MesgulMu { get => mesgulMu; set => mesgulMu = value; }
        public Button Btn { get => btn; set => btn = value; }
        public Masa Masa { get => masa; set => masa = value; }
    }
}
