using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing
{
    internal class Horse
    {
        public bool available=true;            // false면 안달린다.
        public string name;
        public int distance;
        

        public void Run(int moveDistance)
        {

            distance += moveDistance;

        }


    }
}
