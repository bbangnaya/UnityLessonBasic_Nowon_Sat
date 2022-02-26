using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_DiceGame
{
    // 게임 시작시 맵을 생성하고(칸들 생성)
    // 맵에 대한 정보를 가지고 있을 클래스
    internal class TileMap
    {

        public Dictionary<int, TileInfo> mapInfo = new Dictionary<int, TileInfo>();

        public void MapSetup(int maxTileNum)
        {
            for (int i = 1; i <= maxTileNum; i++)
            {
                // 5배수이면 샛별칸 생성
                if (i%5 == 0)         // 수정 전 (i+1) % 5 == 0 && (i !=0)
                {
                    
                    TileInfo_Star tileInfo_Star = new TileInfo_Star();
                    tileInfo_Star.index = i;
                    tileInfo_Star.name = "star";
                    tileInfo_Star.discription = "This is star tile.";
                    mapInfo.Add(i, tileInfo_Star);

                }
                // 일반칸 생성
                else
                {
                    TileInfo tileInfo_Dummy = new TileInfo();
                    tileInfo_Dummy.index = i;
                    tileInfo_Dummy.name = "Dummy";
                    tileInfo_Dummy.discription = "This is dummmy file";
                    mapInfo.Add(i, tileInfo_Dummy);
                }
            }
            Console.WriteLine($"Maps setup complete. Max tile num {maxTileNum}");
            foreach (var item in mapInfo)
            {
                Console.WriteLine($"{item.Key} , {item.Value}");
            }
        }
    }
}