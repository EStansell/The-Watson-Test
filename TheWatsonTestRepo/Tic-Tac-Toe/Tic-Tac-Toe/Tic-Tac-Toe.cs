using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tic_Tac_Toe
{
	public class TicTacToe : Grid
	{

		/// <summary>
		/// Created a Tic Tac Tow game board
		/// </summary>
		/// <param name="n">nxn dimension for the game board</param>
		public TicTacToe(int n)
		{
			for (int i = 0; i < n; i++)
			{
				this.RowDefinitions.Add(new RowDefinition());
				this.ColumnDefinitions.Add(new ColumnDefinition());
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
			return 0;
		}
	}

}
