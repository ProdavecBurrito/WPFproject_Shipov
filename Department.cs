﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject_Shipov
{
    public class Department
    {
        public string DepName { get; set; }
        public override string ToString()
        {
            return $"{DepName}";
        }
    }
}
