using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _80_Lezione_10_06_FirstPerson
{
    abstract class Controller
    {
        protected int index;

        public Controller(int ctrlIndex)
        {
            index = ctrlIndex;
        }

        public abstract float GetHorizontal();
        public abstract float GetVertical();
    }
}
