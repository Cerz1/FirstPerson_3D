using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _80_Lezione_10_06_FirstPerson
{
    interface IDrawable
    {
        DrawLayer Layer { get; }
        void Draw();
    }
}
