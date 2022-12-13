using ConsoleRichGame.M;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRichGame
{
    internal class PlayerUi
    {
        private static string EmptyLine =
            "                                                                         ";
        internal static void UpdateShowLandInfo(Land[] lands, List<AbstractPlayer> players,
            bool isClearScreen)
        {
            PlayerUi.SaveCurrentLocation();

            if (isClearScreen)
                Console.SetCursorPosition(0, 0);

            Console.WriteLine(String.Format("{0, -10}", "player info:"));
            Console.WriteLine("|{0, -6}|{1, -6}|", "Name", "Money");
            Console.WriteLine("|{0, -6}|{1, -6}|", new string('-', 6), new string('-', 6));
            foreach (var player in players)
            {
                Console.WriteLine("|{0, -6}|{1, -6}|",
                    player.Name, player.Money);
            }
            Console.WriteLine();

            Console.Write(String.Format("{0, -20}", "land:"));
            for (int i = 0; i < lands.Length; i++)
            {
                Console.Write("{0, -4}", i);
            }
            Console.WriteLine();
            Console.Write("{0, -20}", $"belong To:");
            for (int i = 0; i < lands.Length; i++)
            {
                var land = lands[i];
                var owner = land.Owner;
                Console.Write("{0, -4}", owner);
            }
            Console.WriteLine();
            Console.Write("{0, -20}", $"player name:");
            //列印第1層玩家位置，如果有
            for (int i = 0; i < lands.Length; i++)
            {
                int level = 0;
                string output = string.Empty;
                foreach (var player in players)
                {
                    var index = player.LocationIndex;
                    if (i == index && level++ == 0)
                    {
                        output = player.Name;
                    }
                }
                Console.Write("{0,-4}", output);
            }
            Console.WriteLine();
            //列印第2-n層玩家位置，如果有(n為玩家數量)
            for (int maxLevel = 1; maxLevel < players.Count; maxLevel++)
            {
                Console.Write(String.Format("{0, -20}", $""));
                for (int i = 0; i < lands.Length; i++)
                {
                    int level = 0;
                    string output = string.Empty;
                    foreach (var player in players)
                    {
                        var index = player.LocationIndex;
                        if (i == index && level++ == maxLevel)
                        {
                            output = player.Name;
                        }
                    }
                    Console.Write("{0, -4}", output);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            PlayerUi.SaveMsgStartLocation();
            PlayerUi.LoadCurrentLocation();
        }

        internal static void ClearMsg(int rows)
        {
            LoadMsgStartLocation();

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(EmptyLine);
            }
            LoadMsgStartLocation();
        }
        private static int MsgStartX;
        private static int MsgStartY;
        private static void SaveMsgStartLocation()
        {
            MsgStartX = Console.CursorLeft;
            MsgStartY = Console.CursorTop;
        }
        internal static void LoadMsgStartLocation()
        {
            Console.SetCursorPosition(MsgStartX, MsgStartY);
        }
        private static int CurrX;
        private static int CurrY;
        private static void SaveCurrentLocation()
        {
            CurrX = Console.CursorLeft;
            CurrY = Console.CursorTop;
        }

        private static void LoadCurrentLocation()
        {
            Console.SetCursorPosition(CurrX, CurrY);
        }
    }
}
