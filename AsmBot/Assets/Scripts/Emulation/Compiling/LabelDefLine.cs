﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Compiling
{
    public class LabelDefLine :IProgramLine
    {
        public string Label {  get; set; }

        public override string ToString()
        {
            return Label + ":";
        }
    }
}
