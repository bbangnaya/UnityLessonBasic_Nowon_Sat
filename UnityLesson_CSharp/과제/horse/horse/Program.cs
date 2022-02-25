﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace horse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            horse[] arr_horse = new horse[5];
            rank[] horserank = new rank[5];


            for (int i = 0; i < arr_horse.Length; i++)
            { 
                arr_horse[i] = new horse();
                arr_horse[i].name = $"말{i+1}";                // 말 이름 지정
                arr_horse[i].distance = 0;                     // 말 달린 거리 초기값(=0) 설정
                
                Console.WriteLine("초기값");
                Console.WriteLine($"말이름 : {arr_horse[i].name}");
                Console.WriteLine($"달린거리 : {arr_horse[i].distance}");
            }
            Console.WriteLine("시작버튼 : Enter");
            Console.ReadLine(); // 시작버튼

            int count = 0;
            while ((arr_horse[0].distance | arr_horse[1].distance | arr_horse[2].distance | arr_horse[3].distance | arr_horse[4].distance) < 100)
            {
                
                Console.WriteLine($"{count}초");
                count++;

                for (int i = 0; i < arr_horse.Length; i++){
                    Random random = new Random();
                    arr_horse[i].dis_per_sec = random.Next(10, 21);
                    Console.Write($"말 {i} :");    
                    arr_horse[i].run();     // 누적에 출력까지 함
                    
                    

                    if (arr_horse[i].distance >= 200) //만약 200에 도달했다면 말이름 순위 저장
                    {
                            horserank[i] = arr_horse[i].name;        // rank에 말이름 순서대로 저장.
                    }
                }
                Thread.Sleep(1000);
            }

            Console.WriteLine($"1등 말 : {horserank[0]}");
            Console.WriteLine("종료, 아무버튼눌러주세요.");
            Console.ReadLine();
            

            int length = rank.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{i + 1}등 말 : {rank[i]}");
            }

            /*foreach (string item in rank)
            {
                Console.WriteLine($"{item+1}등 말 : {rank.(item)}");
            }*/

            // 매초 while문을 통해 run함수 가동
            // run에서는 distance =  distance + dis_per_sec 를 한다.
            // dis_per_sec는 10~20 사이 랜덤함수
            // int randomInt = dis_per_sec.Next(10, 21);
            // 달린 거리 : distance, 속도 dis_per_sec
            // 그러면서 distance>=200 이 되는 말의 이름을 stack으로 저장
            // 마지막 말이 도달해서 모든 horse.street >=20이면 while문 종료
            // stack에 저장된 말의 이름 출력



        }
    }

}
