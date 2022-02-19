using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_ClassInheritance
{
    internal class Dog : Creature, ITwoLeggedWalker
    {
        public float tailLength;

        public void TwoLeggedWalk()
        {
            Console.WriteLine("네발로 걷는다.");
        }
    }
}
