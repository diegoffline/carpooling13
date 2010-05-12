using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public class Range
    {
        decimal range;

        public decimal RangeDim {
            get { return range; }
            set { range = value; }
        }

        public Range(decimal range) {
            this.range = range;
        }
    }
}
