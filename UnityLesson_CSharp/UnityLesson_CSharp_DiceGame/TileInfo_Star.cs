using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_DiceGame
{
    internal class TileInfo_Star : TileInfo
    {
        public int starValue = 3;
        //5배수 칸에 도착할 때에는 샛별 획득 개수가 영구적으로 1 증가합니다.
        public override void TileEvent()
        {
            base.TileEvent();
            starValue++;
        }


    }
}
