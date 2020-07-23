using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sudoku_Solver
{
	public class Sudoku
	{
		// variable declarations-----------------------------------------------------------------
		public int[] board = new int[81];
		public int[,] _2dBoard = new int[9, 9];


		// constructors-------------------------------------------------------------------
		public Sudoku() //empty board
		{
			for (int i = 0; i < board.Length; i++) //set 1D array values to 0; empty board
			{
				board[i] = 0;
			}

			for (int i = 0; i < _2dBoard.GetLength(0); i++) //set 2D array values to 0; empty board
			{
				for (int j = 0; j < _2dBoard.GetLength(1); j++)
				{
					_2dBoard[i, j] = 0;
				}
					
			}
		}
		public Sudoku(int[] input)
		{
			//assign to 1d board
			board = input;

			_2dBoard = convertDimensions(input);
		}
		public Sudoku(int[,] input)
		{
			//assign to 2d board
			_2dBoard = input;

			board = convertDimensions(input);
		}


		//methods-------------------------------------------------------------------
		public int[,] convertDimensions(int[] input)
		{
			int[,] output = new int[9, 9];
			//convert 1d array to 2d array

			for (int i = 0; i < input.Length; i++)
			{
				output[i / 9, i % 9] = input[i];
			}
			return output;
		}
		public int[] convertDimensions(int[,] input)
		{
			int[] output = new int[81];

			// convert 2d array to 1d array
			for (int i=0;i<input.GetLength(0);i++)
			{
				for (int j = 0; j < input.GetLength(1); j++)
				{
					output[i * 9 + j] = input[i, j];
				}
			}
			
			return output;
		}


		//functions-------------------------------------------------------------------
		public void displayBoard(int[,] source)//only allows 2d board input, use convertDimension method to convert first if needed
		{
			Console.WriteLine(" -------------------------------------");
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					Console.Write(" | ");
					Console.Write(source[i, j]);
				}
				Console.Write(" |\n");
				Console.WriteLine(" -------------------------------------");
			}
		}

		public bool validateSelection(int[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < (input.Length - i); j++)
				{
					if (input[i] == input[j]) return false;
				}
			}

			return true;
		}


	}
}

