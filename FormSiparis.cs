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
    public partial class FormSiparis : Form
    {
        public FormSiparis()
        {
            InitializeComponent();
        }



        public static List<Menu> menuler = new List<Menu>()
        {
         new Menu { MenuAdi="SteakHouse", Fiyati=45.5m },
         new Menu { MenuAdi="Whooper", Fiyati=34.3m},
         new Menu { MenuAdi="King Chicken", Fiyati=23.45m },
         new Menu { MenuAdi="BigKing" , Fiyati=30.78m},
         new Menu { MenuAdi="Chicken Royale", Fiyati=47m}

        };


        public static List<Extra> extralar = new List<Extra>()
        {
            new Extra { ExtraAdi="Ketçap", Fiyati=1m },
            new Extra { ExtraAdi="Mayonez", Fiyati=1.25m},
            new Extra { ExtraAdi="Hardal", Fiyati=2m},
            new Extra { ExtraAdi="Köri", Fiyati=3m},
            new Extra { ExtraAdi="BBQ", Fiyati=1.4M},
            new Extra { ExtraAdi="Soğan", Fiyati =6m}
        };

        public static List<Siparis> siparisler = new List<Siparis>();
        public static List<Siparis> mevcutSiparisler = new List<Siparis>();



        private void FormSiparis_Load(object sender, EventArgs e)
        {
            foreach (Menu item in menuler)
            {
                cmbMenuler.Items.Add(item);
            }
            foreach (Extra item in extralar)
            {
                flpExtraMalzemeler.Controls.Add(new CheckBox() { Text = item.ExtraAdi, Tag = item });
            }


            foreach (Siparis item in mevcutSiparisler)
            {
                lsbSiparisler.Items.Add(item);
            }

            cmbMenuler.SelectedIndex = -1; // comboboxta hiçbirşey seçili gelmesin istersek 

        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Siparis siparis = new Siparis();
            siparis.SeciliMenusu =(Menu) cmbMenuler.SelectedItem;


            if (rdbBuyuk.Checked) siparis.Boyutu = Boyut.Buyuk;
            else if (rdbOrta.Checked) siparis.Boyutu = Boyut.Orta;
            else siparis.Boyutu = Boyut.Kucuk;  // tutar hesaplarken küçük düşünülmüştü

            siparis.ExtraMalzemesi = new List<Extra>();
            foreach (CheckBox item in flpExtraMalzemeler.Controls)
            {
                if (item.Checked)
                {
                    siparis.ExtraMalzemesi.Add((Extra)item.Tag);  // contrlun etiketinde nesnenin kendisi vardı.ama object tipinde döndüğü için cast işlemi yaptık.
                }
            }


            siparis.Adet = Convert.ToInt32( nmrAdet.Value);
            siparis.Hesapla();
            mevcutSiparisler.Add(siparis);
            siparisler.Add(siparis);
            lsbSiparisler.Items.Add(siparis);

            ToplamTutarHesapla();

            Temizle.TemizlikYap(this.Controls);

        }

        public decimal ToplamTutarHesapla()
        {
            decimal toplamTutar = 0;
            for (int i = 0; i < lsbSiparisler.Items.Count; i++)
            {
                Siparis gelen =(Siparis) lsbSiparisler.Items[i];
                toplamTutar += gelen.ToplamTutar;
            }
            lblTutar.Text = toplamTutar.ToString();
            return toplamTutar;
        }

        private void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Toplam sipariş ücreti:" + ToplamTutarHesapla().ToString() + "Satın almayı tamamlamak istiyor muusnuz ?","Sipariş Bilgisi",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dr==DialogResult.Yes) // onayladıysa
            {
                lsbSiparisler.Items.Clear();
                mevcutSiparisler.Clear();
                MessageBox.Show("Sipariş Tamamlandı");
            }
            else
            {
                MessageBox.Show("Sipariş iptal edildi");
            }
        }
    }
}
