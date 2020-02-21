using System;
using System.Collections.Generic;
using System.Text;

namespace Boring_Tic_Tac_Toe
{
	public class TicTacToe
	{
		public List<List<string>> board { get; }
		/// <summary>
		/// Created a Tic Tac Tow game board
		/// </summary>
		/// <param name="n">nxn dimension for the game board</param>
		public TicTacToe(int n)
		{
			for (int i = 0; i < n; i++)
			{
				board.Add(new List<string>());
				for (int j = 0; j < n; j++)
				{
					board[i].Add(" ");
				}
			}
		}

		/// <summary>
		/// Place a piece on the game board
		/// </summary>
		/// <param name="row">row to place a piece</param>
		/// <param name="col">column to place a piece</param>
		/// <param name="player">the player (1 or 2) the piece is for</param>
		/// <returns>0 = no winner, 1 = player 1 won, 2 = player 2 won</returns>
		public int PlacePiece(int row, int col, int player)
		{
			int result = 0;

			if (board[row][col] == " ")
				switch (player)
				{
					case 1:
						board[row][col] = "X";
						break;
					case 2:
						board[row][col] = "O";
						break;
					default:
						Console.WriteLine("Invalid Player passed in");
						break;
				}
			else
				Console.WriteLine("Spot has already been taken");

			//Going across the top
			for (int i = 0; i <= board.Count-1; i++)
			{
				//check Diagonal
				if(i == 0)
					result = CheckDiagonal();
				if (result != 0)
					break;

				//check Row
				result = CheckRow(i);
				if (result != 0)
					break;
				else
					//if not in row Check Column
					result = CheckCol(i); 
				if (result != 0)
					break;
			}

			return result;
		}
		private int CheckRow(int row)
		{
			string startPiece = board[row][0];
			string prevPiece;
			foreach (string piece in board[row])
			{
				prevPiece = piece;
				if (startPiece == " " || prevPiece != startPiece)
					return 0;
			}
			return startPiece == "X" ? 1 : 2;
		}
		private int CheckCol(int col)
		{
			string startPiece = board[0][col];
			string prevPiece;
			for (int i = 0; i < board.Count; i++)
			{
				prevPiece = board[i][col];
				if (startPiece == " " || prevPiece != startPiece)
					return 0;
			}
			return startPiece == "X" ? 1 : 2;
		}
		private int CheckDiagonal()
		{
			int result = -1 ;

			string LRStartPiece = board[0][0];
			string LRPrevPiece;

			//check Diagonals
			for (int i = 0; i < board.Count; i++)
			{
				LRPrevPiece = board[i][i];
				if (LRStartPiece == " " || LRPrevPiece != LRStartPiece)
				{
					result = 0;
					break;
				}
			}

			if (result == -1)
				return LRStartPiece == "X" ? 1 : 2;

			string RLStartPiece = board[0][0];
			string RLPrevPiece;

			for (int i = 0; i < board.Count; i++)
			{
				RLPrevPiece = board[i][board.Count-i];
				if (RLStartPiece == " " || RLPrevPiece != RLStartPiece)
				{
					result = 0;
					break;
				}
			}

			if (result == -1)
				return RLStartPiece == "X" ? 1 : 2;

			return 0;
		}
	}
}
