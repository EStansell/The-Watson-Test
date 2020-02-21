using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Boring_Tic_Tac_Toe
{
    class Program
    {
        public static TicTacToe ttt = new TicTacToe(3);
        static void Main(string[] args)
        {
            PlayGame();
        }
        static void PlayGame()
        {
            int player = 1;
            while (true)
            {
                ttt = new TicTacToe(RequestSize());
                int playState = 0;

                Console.WriteLine("Lets Play");
                Task.Delay(5000);
                while(playState == 0)
                {
                    int[] coords = RequestCoords(player);
                    if (coords != null)
                    {
                        playState = ttt.PlacePiece(coords[0]-1, coords[1]-1, player);
                        player = player == 1 ? 2 : 1;
                    }

                    if (playState > 0)
                    {
                        Console.WriteLine($"Looks like Player {playState} won. Congradulations \n Please wait as I reset the board");
                        Thread.Sleep(5000);
                    } else if (playState < 0)
                    {
                        Console.WriteLine($"Looks like no Player won. A Tough match\n Please wait as I reset the board");
                        Thread.Sleep(5000);
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                
            }
        }
        static int RequestSize()
        {
            Console.WriteLine("What size game board would you like (Default 3)?");
            try
            {
                Console.Write("you: ");
                int size = int.Parse(Console.ReadLine());
                if (size < 1)
                    throw new Exception();
                return size;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\nDefault 3 Selected");
            }
            Thread.Sleep(3000);
            Console.Clear();
            return 3;
        }
        static int[] RequestCoords(int player)
        {
            DisplayBoard();
            Console.WriteLine($"In x,y coordnant form, Please place your piece.");
            Console.Write($"Player {player}: ");
            try
            {
                string resp = Console.ReadLine();
                string[] cut = resp.Replace("(", "").Replace(")", "").Split(",");
                int x = int.Parse(cut[0].Trim());
                int y = int.Parse(cut[1].Trim());

                return new int[] { x, y };
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} \n Make sure you input coords correctly\nYou lost your turn");
            }
            return null;
        }
        static void DisplayBoard()
        {
            int boardCount = ttt.board.Count;
            for (int i = 0; i < (boardCount * 2) - 1; i++)
            {
                if (i % 2 == 1)
                    for (int j = 0; j < (boardCount * 2) - 1; j++)
                    {
                        if (j % 2 == 0)
                            Console.Write("-");
                        else
                            Console.Write("+");
                    }
                else
                    for (int j = 0; j < (boardCount * 2) - 1; j++)
                    {
                        if (j % 2 == 0)
                            Console.Write(ttt.board[i/2][j/2]);
                        else
                            Console.Write("|");
                    }
                Console.WriteLine();
            }
        }
    }
}
