﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBattleBot.Structures
{
    class EnemyStructure
    {
        private Random _random = new Random();
        public int hp;
        public int coins;
        public int points;
        public int classRandom;

        public void Reset()
        {
            coins = _random.Next(1, 5);
            points = _random.Next(1, 2);
            classRandom = _random.Next(0, 4);
            switch (classRandom)
            {
                case 0:
                    hp = _random.Next(40, 50);
                    break;
                case 1:
                    hp = _random.Next(10, 20);
                    break;
                case 2:
                    hp = _random.Next(20, 30);
                    break;
                case 3:
                    hp = _random.Next(30, 40);
                    break;
            }
        }
    }
}
