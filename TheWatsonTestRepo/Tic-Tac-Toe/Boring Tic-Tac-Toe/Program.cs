using System;

namespace Boring_Tic_Tac_Toe
{
	class Program
	{
		public TicTacToe ttt = new TicTacToe(3);
		static void Main(string[] args)
		{
			PlayGame();
		}
		static void PlayGame()
		{
			bool playing = true;
			while (playing)
			{

			}
		}
		static int RequestSize()
		{
			Console.WriteLine("What size game board would you like (Default 3)?");
			try
			{
				Console.Write("you: ");
				return int.Parse(Console.ReadLine());
			} catch (Exception e)
			{
				Console.WriteLine(e.Message + "\nDefault 3 Selected");
			}
			return 3;
		}
		static int[] RequestCoords()
		{
			Console.WriteLine("In coordnant format (x, x), Please place your piece.");
			Console.Write("you: ");
			try
			{
				string resp = Console.ReadLine();
				string[] cut = resp.Split(",");
			} catch (Exception e)
			{

			}
		}
	}
}
