﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeMinisters
{
    class PrimeMinister
    {
        public string Name { get; private set; }

        public int YearElected { get; private set; }

        public PrimeMinister(string name, int yearElected)
        {
            this.Name = name;
            this.YearElected = yearElected;
        }

        public override string ToString()
        {
            return string.Format("{0}, elected: {1}", Name, YearElected);
        }
    }
}
