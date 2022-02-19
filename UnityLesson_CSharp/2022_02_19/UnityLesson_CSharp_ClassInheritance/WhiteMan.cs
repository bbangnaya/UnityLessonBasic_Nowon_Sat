using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class WhiteMan : Human
    {
        /*public WhiteMan(float hsf, float wsf)
        {
            hs = hsf;
            ws = wsf;

        }*/
        public override void Breath()
        {
            age++;
            height += 0.00008f;
            weight += 0.00004f;
        }
    }
}
