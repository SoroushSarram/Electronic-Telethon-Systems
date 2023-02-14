using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Prizes : CollectionBase
    {
        public void add(Prize prize)
        {
            List.Add(prize);
        }

        public Prize this[int index]
        {
            get { return (Prize)this[index]; }
            set { this[index] = value; }
        }
    }
}
