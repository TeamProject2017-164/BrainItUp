using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainItUp
{
   public class Counter
    {
        private int _value=0;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

    }
}
