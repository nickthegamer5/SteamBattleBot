﻿using System;
using SteamKit2;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace SteamBattleBot.Structures
{
    class PlayerStructure
    {
        private Random _random = new Random();

        public ulong id;

        public int healthPoints;

        private int hitChance, damageDone;

        private EnemyStructure enemy = new EnemyStructure();

        public void setupGame()
        {
            enemy.hp = 100;
            healthPoints = 100;
        }

        public void attack(SteamFriends.FriendMsgCallback callback, SteamFriends steamFriends)
        {
            hitChance = _random.Next(1, 3);
            if (hitChance == 1) // Missed
            {
                steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, "You missed the monster!");
            } else
            {
                damageDone = _random.Next(1, 10); // How much damage did the player do
                enemy.hp -= damageDone;
                steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, String.Format("You hit the monster for {0} damage!", damageDone));
            }

            hitChance = _random.Next(1, 3);
            if (hitChance == 1) // Missed
            {
                steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, "The monster missed you!");
            }
            else
            {
                damageDone = _random.Next(1, 10); // How much damage did the monster do
                healthPoints -= damageDone;
                steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, String.Format("The monster hit you for {0} damage!", damageDone));
            }
            state(callback, steamFriends);
        }

        public void state(SteamFriends.FriendMsgCallback callback, SteamFriends steamFriends)
        {
            steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, String.Format("You have {0} hp", healthPoints));
            steamFriends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, String.Format("The monster has {0} hp", enemy.hp));
        }
    }
}