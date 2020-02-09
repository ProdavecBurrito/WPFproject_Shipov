using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject_Shipov
{
    public class Employee : Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return $"{ID} {Name} {Salary} {DepName}";
        }

    }
}
