﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamburger_Oop_5432
{
   public class Menu
    {
        public string MenuAdi { get; set; }

        public decimal Fiyati { get; set; }

        public override string ToString()
        {
            return MenuAdi + " Menu ";
        }
    }
}
