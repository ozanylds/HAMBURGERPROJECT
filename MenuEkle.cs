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
    public partial class MenuEkle : Form
    {
        public MenuEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            FormSiparis.menuler.Add( new Menu { MenuAdi=txtAd.Text, Fiyati=nmrFiyat.Value });
            Temizle.TemizlikYap(this.Controls);
            MessageBox.Show("Yeni menu başarı ile eklendi");
        }
    }
}
