using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger_Oop_5432
{
    public class Siparis
    {
        public Menu SeciliMenusu { get; set; }

        public Boyut Boyutu { get; set; }

        public List<Extra>  ExtraMalzemesi { get; set; }

        public int Adet { get; set; }

        public  decimal ToplamTutar { get; set; }

      public  void Hesapla()
        {
            ToplamTutar = 0;
            ToplamTutar += SeciliMenusu.Fiyati;

            switch (Boyutu)
            {
               
                case Boyut.Orta:
                    ToplamTutar += ToplamTutar * 0.1m;
                    break;
                case Boyut.Buyuk:
                    ToplamTutar += ToplamTutar * 0.2m;
                    break;
            }

            foreach (Extra item in ExtraMalzemesi)
            {
                ToplamTutar += item.Fiyati;
            }

            ToplamTutar = ToplamTutar * Adet;

        }

        public override string ToString()
        {
            if (ExtraMalzemesi.Count<1)  // ekstra malzeme secilmediyse
            {
                return string.Format("{0} Menu, x {1} Adet,{2} Boy, Toplam : {3}", SeciliMenusu.MenuAdi, Adet.ToString(), Boyutu.ToString(), ToplamTutar.ToString());
            }
            else 
            {
                string ExMalzemeler = null;
                foreach (Extra ex in ExtraMalzemesi)
                {
                    ExMalzemeler += ex.ExtraAdi + ",";
                }

                return string.Format("{0} Menu, x {1} Adet, {2} Boy,({3}) , Toplam : {4}",SeciliMenusu.MenuAdi,Adet.ToString(),Boyutu.ToString(),ExMalzemeler,ToplamTutar.ToString());
            
            }
        }




    }
}
