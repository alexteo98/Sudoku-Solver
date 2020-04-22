using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
	public class Puzzle
	{
		private int size = 0;
		public bool solved = false;
		public int[,] problem = new int[9, 9];
		public bool[,,] PencilMark = new bool[9, 9, 9];

		public Puzzle(int[] input)
		{
			int arraysize = input.GetLength(0);
			int dimension = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(arraysize)));
			size = dimension;
			//convert 1d array to 2d array
			for (int i = 0; i < arraysize;i++) {
				problem[i / 9, i % 9] = input[i]; }
		}
		private void assign(int[,] problem)
		{
			int ans = 0;

			//initialise all as false
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					ans = problem[i, j];
					for (int count = 0; count < ans; count++)
					{
						PencilMark[i, j, count] =false;
					}
				}
			}

			//flip entered values as true
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					ans = problem[i, j];
					PencilMark[i, j, ans - 1] = true;

				}
			}
		}

		public bool validate(int[,] sln)
		{
			int row = 9;
			int[] checksample = new int[row];

			//check rows
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < row; j++)
				{
					checksample[j] = sln[i,j];
				}

				if (ValidateRows(checksample)==false)	return false;
				
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
					checksample[i] = sln[(blockX*3 + i) / 3 + offsetX, (blockY*3 + i) % 3+offsetY];
				}
				if (ValidateRows(checksample) == false) return false;
				offsetY += 3;
				if ((j+1) % 3 == 0)
				{
					offsetY = 0;
					offsetX += 3;
				}

			}

			return true;
		}

		private int[,] solve(bool[,,] problem)
		{
			int[,] sln = new int[9, 9];



			return sln;
		}

		private bool ValidateRows(int[] row) //function to check a line of values has any repeats
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = i+1; j < 9; j++)
				{
					if (row[i] == row[j]) { return false; }
				}
			}
			return true;
		}
	}
}
