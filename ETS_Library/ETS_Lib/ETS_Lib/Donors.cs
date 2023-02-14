using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS_Lib
{
    class Donors : CollectionBase
    {
        public void add(Donor donor)
        {
            List.Add(donor);
        }

        public Donor this[int index]
        {
            get { return (Donor)List[index]; }
            set { List[index] = value; }
        }
    }
}
