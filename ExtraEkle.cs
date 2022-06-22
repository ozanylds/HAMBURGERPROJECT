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
    public partial class ExtraEkle : Form
    {
        public ExtraEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            FormSiparis.extralar.Add(new Extra { ExtraAdi=txtAd.Text, Fiyati=nmrFiyat.Value });
            Temizle.TemizlikYap(this.Controls);
            MessageBox.Show("Yeni extra malzeme ekleme başarılı..");
        }
    }
}
