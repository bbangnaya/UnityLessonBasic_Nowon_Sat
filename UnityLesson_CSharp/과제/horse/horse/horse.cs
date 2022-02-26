using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace horse
{
    internal class horse
    {
        public string name;             // 이름
        public int dis_per_sec;         // 달린거리
        
        public int distance = 0;        // 최종거리
        
        public void run()
        {
            distance = distance + dis_per_sec;  // 입력받은 거리를 달린거리에 더해주어서 달린거리를 누적시키는 역할
            Console.WriteLine(distance);
        }
        
        public bool dontmove()                  // 200넘을 시 호출하여 rank에 저장되지 않게 한다. 
        {
            
            return true;
        }



    }
}
