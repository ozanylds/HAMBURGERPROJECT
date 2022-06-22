using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamburger_Oop_5432
{
    public static class Temizle
    {
        public static void  TemizlikYap(Control.ControlCollection koleksiyon)
        {
            foreach (Control item in koleksiyon)
            {
                if(item is TextBox)
                {
                    TextBox textBox = (TextBox)item;
                    textBox.Clear();
                }
                else if (item is RadioButton)
                {
                    RadioButton rdn = (RadioButton)item;
                    rdn.Checked = false;
                }

                else if (item is CheckBox)
                {
                    CheckBox chk = (CheckBox)item;
                    chk.Checked = false;
                }
                else if(item is NumericUpDown)
                {
                    NumericUpDown nup = (NumericUpDown)item;
                    nup.Value = 0;
                }
                else if( item is GroupBox)
                {
                    GroupBox grp = (GroupBox)item;
                    TemizlikYap(grp.Controls);
                }
                else if(item is FlowLayoutPanel)
                {
                    FlowLayoutPanel flp = (FlowLayoutPanel)item;
                    TemizlikYap(flp.Controls);
                }
                else if(item is ComboBox)
                {
                    ComboBox cmb = (ComboBox)item;
                    cmb.SelectedIndex = -1;

                }

            }
        }

    }
}
