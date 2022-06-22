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
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void siparişOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormSiparis());
        }

        private void siparişBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SiparisBilgileri());
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {

        }

        private void OpenChildForm(Form form)
        {
            this.Width = form.Width + 20;
            this.Height = form.Height + 30;
            bool durum = false;
            foreach (Form item in this.MdiChildren) // içerdeki child form adlarıyla gelen form adını karşılştır.
            {
                if (item.Text==form.Text) // ata formun bildigi bir form gelmiş demektir.
                {
                    durum = true;
                    item.Activate();
                }
                else
                {
                    item.Close();
                }
            }
            if (durum==false) // blmediğim bir formsa onun atası( parent ) mdıformumuzdur dye işaretleyip gelen formu açtık.
            {
                form.MdiParent = this;
                form.Show();
            }
        }

        private void extraMalzemeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ExtraEkle());
        }

        private void menuEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MenuEkle());
        }


    }
}
