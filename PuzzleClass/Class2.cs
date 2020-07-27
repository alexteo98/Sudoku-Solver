using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Sudoku_Solver
{
	public class Sudoku
	{
		// variable declarations-----------------------------------------------------------------
		public int[] board = new int[81];
		public int[] workingBoard = new int[81];
		public int[,] _2dBoard = new int[9, 9];
		private int globalcurrentCellIndex = 0;
		public int repititions = 0;


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

		public void displayBoard(int[,] source)//only allows 2d board input, use convertDimension method to convert first if needed;display any board input
		{
			Console.WriteLine(" -------------------------------------");
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					Console.Write(" | ");
					if (source[i, j] == 0) Console.Write(" ");
					else					Console.Write(source[i, j]);
				}
				Console.Write(" |\n");
				Console.WriteLine(" -------------------------------------");
			}
		}
		public void displayBoard()//displays the board stored
		{
			displayBoard(_2dBoard);
		}

		public bool validateBoard()
		{
			for (int i = 0; i < 9; i++)
			{
				if (validateSelection(extractRows(i)) == false) { return false; }
				if (validateSelection(extractColumns(i)) == false) { return false; }
				if (validateSelection(extractBoxes(i)) == false) { return false; }
			}

			return true;
		}
		public bool validateBoard(int[,] inputBoard)
		{
			for (int i = 0; i < 9; i++)
			{
				if (validateSelection(extractRows(i, inputBoard)) == false) { return false; }
				if (validateSelection(extractColumns(i, inputBoard)) == false) { return false; }
				if (validateSelection(extractBoxes(i, inputBoard)) == false) { return false; }
			}

			return true;
		}
		public bool validateBoard(int[] inputBoard)
		{
			int[,] board1 = convertDimensions(inputBoard);
			for (int i = 0; i < 9; i++)
			{
				if (validateSelection(extractRows(i, board1)) == false) { return false; }
				if (validateSelection(extractColumns(i, board1)) == false) { return false; }
				if (validateSelection(extractBoxes(i, board1)) == false) { return false; }
			}

			return true;
		}


		//functions-------------------------------------------------------------------
		public bool validateSelection(int[] input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == 0) continue;
				for (int j = i+1; j < input.Length; j++)
				{
					if (input[j] == 0) continue;
					if (input[i] == input[j]) return false;
				}
			}

			return true;
		}

		public int[] extractRows(int i,int[,] boardInput)//i=row number; extract row from row index
		{
			int[] output=new int[9];

			for (int j = 0; j < output.Length; j++)
			{
				output[j] = boardInput[i, j];
			}
			return output;
		}
		public int[] extractRows(int i)
		{
			return extractRows(i, _2dBoard);
		}//default; returns row number of stored board
		public int[] extractColumns(int i, int[,] boardInput)//i=column number; extract column from column index
		{
			int[] output = new int[9];

			for (int j = 0; j < output.Length; j++)
			{
				output[j] = boardInput[j, i];
			}
			return output;
		}
		public int[] extractColumns(int i)
		{
			return extractColumns(i, _2dBoard);
		}//default; returns column number of stored board
		public int[] extractBoxes(int boxnumber, int[,] boardInput)//i=box number; extract box from box index
		{
			int[] output = new int[9];
			int startI, startJ;
			startI = (boxnumber / 3) * 3;
			startJ = (boxnumber % 3) * 3;

			for (int i = 0; i < output.Length; i++)
			{
				output[i] = boardInput[startI + (i / 3), startJ + (i % 3)];
			}

			return output;
		}
		public int[] extractBoxes(int boxnumber)
		{
			return extractBoxes(boxnumber, _2dBoard);
		}//default; returns box number of stored board

		private int cellSelector(int currentCellIndex,int positionToMove)
		{
			int cellIndex = 0;

			if (positionToMove > 0)
			{
				for (int i = currentCellIndex; i < board.Length; i++)
				{
					if (board[i + 1] == 0)
					{
						cellIndex = i + 1;
						positionToMove--;
					}
					if (positionToMove == 0) break;
				}
			}
			else if (positionToMove < 0)
			{
				repititions++;
				for (int i = currentCellIndex; i > 0; i--)
				{
					if (board[i - 1] == 0)
					{
						cellIndex = i - 1;
						positionToMove++;
					}
					if (positionToMove == 0) break;
				}
			}
			globalcurrentCellIndex = cellIndex;
			return cellIndex;
		}//finds the next/prev empty cell to fill
		private void tryValue(int currentCellIndex)
		{
			int currentCellValue=0;
			currentCellValue = workingBoard[currentCellIndex];

			backtrack:
			if (workingBoard[currentCellIndex] == 9)// && validateBoard(workingBoard) == false)//reset and backtrack
			{
				workingBoard[currentCellIndex] = 0;
				tryValue(cellSelector(currentCellIndex,-1));//backtrack
			}//reset and backtrack
			else //try new values
			{
				workingBoard[currentCellIndex] = currentCellValue + 1;
				while (validateBoard(workingBoard) == false)
				{
					if (workingBoard[currentCellIndex] == 9) goto backtrack;
					workingBoard[currentCellIndex] = workingBoard[currentCellIndex] + 1;
				}
				globalcurrentCellIndex = currentCellIndex;
				return;
			}
		}

		public void solve()
		{
			board.CopyTo(workingBoard,0);
			globalcurrentCellIndex = findFirstEmptyCell();
			tryValue(globalcurrentCellIndex);
			while (isSolved()==false)
			{
				globalcurrentCellIndex = cellSelector(globalcurrentCellIndex, 1);
				tryValue(globalcurrentCellIndex);
			}

			if (isSolved())
			{
				displayBoard(convertDimensions(workingBoard));
			}

		}

		private bool isSolved()
		{
			if (validateBoard(workingBoard) && isComplete()) return true;
			else return false;
		}

		private bool isComplete()
		{
			foreach (int i in workingBoard)
			{
				if (i == 0) return false;
			}
			return true;
		}

		private int findFirstEmptyCell()
		{
			for (int i = 0; i < workingBoard.Length; i++)
			{
				if (workingBoard[i] == 0) return i;
			}
			return 0;
		}



	}
}

