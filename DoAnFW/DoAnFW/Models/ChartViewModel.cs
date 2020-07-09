using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnFW.Models
{
    public class ChartViewModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public double Sum { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
