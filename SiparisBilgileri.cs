using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamburger_Oop_5432
{
    public partial class SiparisBilgileri : Form
    {
        public SiparisBilgileri()
        {
            InitializeComponent();
        }

        private void SiparisBilgileri_Load(object sender, EventArgs e)
        {

            // form yüklendiğinde bu veriler gün sonu raposu gibi gelmiş olacak.

            decimal ciro=0;
            decimal extraMalzemeGeliri = 0;
            int satisAdedi = 0;
            foreach (Siparis item in FormSiparis.siparisler)
            {
                ciro += item.ToplamTutar;
                foreach (Extra ex in item.ExtraMalzemesi)
                {
                    extraMalzemeGeliri += ex.Fiyati;
                }
                satisAdedi += item.Adet;
                lstSiparisler.Items.Add(item);
            }
            lblCiro.Text = ciro.ToString();
            lblToplamSiparis.Text = lstSiparisler.Items.Count.ToString();
            lblExtraMalzeme.Text = extraMalzemeGeliri.ToString();
            lblSatilanUrunAdet.Text = satisAdedi.ToString();


        }
    }
}
