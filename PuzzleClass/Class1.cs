using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver
{
	public class Puzzle
	{
		private int size = 0;
		public bool solved = false;
		public int[,] problem = new int[9, 9];
		public bool[,,] possible_values = new bool[9, 9, 9];

		//constructors
		public Puzzle(int[] input)
		{
			int arraysize = input.GetLength(0);
			int dimension = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(arraysize)));
			size = dimension;
			//convert 1d array to 2d array
			for (int i = 0; i < arraysize; i++)
			{
				problem[i / 9, i % 9] = input[i];
			}
		}
		public Puzzle()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					problem[i, j] = 0;
				}
			}
		}//no data given,set all to 0
		public Puzzle(int[,] input)
		{
			problem = input;
		}


		//public tools
		public bool validate()
		{
			int[,] sln = problem;
			int row = 9;
			int[] checksample = new int[row];

			//check rows
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < row; j++)
				{
					checksample[j] = sln[i, j];
				}

				if (ValidateRows(checksample) == false) return false;

			}

			//check columns
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < row; j++)
				{
					checksample[j] = sln[j, i];
				}

				if (ValidateRows(checksample) == false) return false;

			}

			//check blocks

			int offsetX = 0;
			int offsetY = 0;
			for (int j = 0; j < row; j++)
			{
				int blockX = 0;
				int blockY = 0;
				for (int i = 0; i < 9; i++)
				{
					checksample[i] = sln[(blockX * 3 + i) / 3 + offsetX, (blockY * 3 + i) % 3 + offsetY];
				}
				if (ValidateRows(checksample) == false) return false;
				offsetY += 3;
				if ((j + 1) % 3 == 0)
				{
					offsetY = 0;
					offsetX += 3;
				}

			}

			return true;
		}

		public void displayPuzzzle()
		{
			Console.WriteLine(" -------------------------------------");
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					Console.Write(" | ");
					Console.Write(problem[i, j]);
				}
				Console.Write(" |\n");
				Console.WriteLine(" -------------------------------------");
			}
		}


		//private functions
		public void assign()
		{
			//initialise all as true, all values possible
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					for (int count = 0; count < 9; count++)
					{
						possible_values[i, j, count] = true;
					}
				}
			}

			/*//flip entered values as true
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					ans = problem[i, j];
					possible_values[i, j, ans - 1] = true;

				}
			}
			*/

			//remove impossible values
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (problem[i, j] != 0)
					{
						for (int c = 0; c < 9; c++)//flag as impossible for rows
						{
							possible_values[i, c, problem[i, j]-1] = false;
						}
						for (int c = 0; c < 9; c++)//flag as impossible for columns
						{
							possible_values[c, j, problem[i, j] - 1] = false;
						}
						for (int c = 0; c < 9; c++)//flag as impossible for box
						{
							possible_values[c, j, problem[i, j] - 1] = false;
						}
					}
				}
			}
			Console.WriteLine();
		}

		public int[,] solve()
		{
			int[,] sln = problem;
			

			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (sln[i, j] == problem[i, j] && problem[i, j] != 0) ;// filled already
					else //not filled yet
					{
						bool valid = false;
						while (valid == false)
						{
							for (int v = 1; v < 10; v++)
							{
								sln[i, j] = v;
								valid = new Puzzle(sln).validate();
								if (valid == true) break;
								if (v == 9)
								{

								}
							}
						}
					}

				}
			}
			return sln;
		}

		private bool ValidateRows(int[] row) //function to check a line of values has any repeats
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = i + 1; j < 9; j++)
				{
					if (row[i] == 0) break;
					if (row[i] == row[j]) { return false; }
				}
			}
			return true;
		}

		

	}
}
