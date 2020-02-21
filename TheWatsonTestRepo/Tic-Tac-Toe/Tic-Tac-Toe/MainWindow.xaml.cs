using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private int turn = 0;

		public MainWindow()
		{
			InitializeComponent();
			StartGame((int)BoardDensity.Value);
		}

		private void StartGame(int size)
		{
			for (int i = 0; i < size; i++)
			{
				Board.RowDefinitions.Add(new RowDefinition());
				Board.ColumnDefinitions.Add(new ColumnDefinition());
			}
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Button button = new Button();
					button.Click += PlacePiece;
					Grid.SetRow(button, j);
					Grid.SetColumn(button, i);
					Board.Children.Add(button);
				}
			}
		}

		private void NukeGame()
		{
			this.Board.Children.Clear();
			Board.RowDefinitions.Clear();
			Board.ColumnDefinitions.Clear();
		}

		private void BoardDensity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			NukeGame();
			StartGame((int)BoardDensity.Value);
		}

		private void PlacePiece(object sender, RoutedEventArgs e)
		{
			switch (turn)
			{
				case 0:
					break;
				case 1:
					break;
			}

		}

		//public boolean isSolved()
		//{
		//	this.checkSolved();
		//	return this.winner != null;
		//}

		//private void checkSolved()
		//{
		//	for (int i = 0; i < ticTacToe.length; i++)
		//	{
		//		Character win = checkRow(i);
		//		if (win != null || (win = checkColumn(i)) != null)
		//		{
		//			this.winner = win;
		//			return;
		//		}
		//	}
		//	//Check diagonal top left to bottom right
		//	if (this.ticTacToe[0][0] != ' ')
		//	{
		//		if (this.ticTacToe[0][0] == this.ticTacToe[1][1] &&
		//		   this.ticTacToe[1][1] == this.ticTacToe[2][2])
		//		{
		//			this.winner = this.ticTacToe[0][0];
		//		}
		//	}
		//	//Check diagonal top right to bottom left
		//	else if (this.ticTacToe[0][2] != ' ')
		//	{
		//		if (this.ticTacToe[0][2] == this.ticTacToe[1][1] &&
		//		   this.ticTacToe[1][1] == this.ticTacToe[2][0])
		//		{
		//			this.winner = this.ticTacToe[0][2];
		//		}
		//	}
		//}

		//private Character checkRow(int row)
		//{
		//	if (this.ticTacToe[row][0] == ' ')
		//	{
		//		return null;
		//	}
		//	if (this.ticTacToe[row][0] == this.ticTacToe[row][1] &&
		//	   this.ticTacToe[row][1] == this.ticTacToe[row][2])
		//	{
		//		return this.ticTacToe[row][0];
		//	}
		//	return null;
		//}

		//private Character checkColumn(int column)
		//{
		//	if (this.ticTacToe[0][column] == ' ')
		//	{
		//		return null;
		//	}
		//	if (this.ticTacToe[0][column] == this.ticTacToe[1][column] &&
		//	   this.ticTacToe[1][column] == this.ticTacToe[2][column])
		//	{
		//		return this.ticTacToe[column][0];
		//	}
		//	return null;
		//}
	}
}
