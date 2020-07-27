using Sudoku_Solver;
using System;

namespace ConsoleTester
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			/*puzzle class test

			// test puzzle
			// 4,3,5,2,6,9,7,8,1,6,8,2,5,7,1,4,9,3,1,9,7,8,3,4,5,6,2,8,2,6,1,9,5,3,4,7,3,7,4,6,8,2,9,1,5,9,5,1,7,4,3,6,2,8,5,1,9,3,2,6,8,7,4,2,4,8,9,5,7,1,3,6,7,6,3,4,1,8,2,5,9
			// 0,0,0,2,6,0,7,0,1,6,8,0,0,7,0,0,9,0,1,9,0,0,0,4,5,0,0,8,2,0,1,0,0,0,4,0,0,0,4,6,0,2,9,0,0,0,5,0,0,0,3,0,2,8,0,0,9,3,0,0,0,7,4,0,4,0,0,5,0,0,3,6,7,0,3,0,1,8,0,0,0
			int[] _parsed = new int[81];
			string[] _parsing = new string[81];
			string input;
			bool entry=false;
			Puzzle puzzle=new Puzzle();

			while (entry == false)
			{
				Console.WriteLine("Enter Sudoku Puzzle from left to right and top to bottom seperated by commas:");
				input = Console.ReadLine();
				_parsing = input.Split(",");

				int i = 0;
				foreach (string s in _parsing)
				{
					_parsed[i] = Convert.ToInt32(s);
					i++;
				}

				puzzle = new Puzzle(_parsed);

				Console.WriteLine();
				puzzle.displayPuzzzle();
				Console.WriteLine("Does this look correct?(Y/N)");
				string confirm = Console.ReadLine();

				while (confirm != "Y" && confirm != "y" && confirm != "N" && confirm != "n")
				{
					Console.WriteLine("Invalid Entry!");
					Console.WriteLine("Does this look correct?(Y/N)");
					confirm = Console.ReadLine();
				}

					if (confirm == "Y" || confirm == "y")
					entry = true;
			}

			//Puzzle results = new Puzzle(puzzle.solve());
			//results.displayPuzzzle();

			puzzle.assign();

			if (puzzle.validate() == true)		Console.WriteLine("This is a valid puzzle");
			else								Console.WriteLine("This is a invalid puzzle");

			//input = "";

			*/

			// test puzzle
			// 4,3,5,2,6,9,7,8,1,6,8,2,5,7,1,4,9,3,1,9,7,8,3,4,5,6,2,8,2,6,1,9,5,3,4,7,3,7,4,6,8,2,9,1,5,9,5,1,7,4,3,6,2,8,5,1,9,3,2,6,8,7,4,2,4,8,9,5,7,1,3,6,7,6,3,4,1,8,2,5,9
			// 0,0,0,2,6,0,7,0,1,6,8,0,0,7,0,0,9,0,1,9,0,0,0,4,5,0,0,8,2,0,1,0,0,0,4,0,0,0,4,6,0,2,9,0,0,0,5,0,0,0,3,0,2,8,0,0,9,3,0,0,0,7,4,0,4,0,0,5,0,0,3,6,7,0,3,0,1,8,0,0,0

			string[] _parsing = new string[81];
			string input;
			int[] _parsed = new int[81];
			bool entry = false;
			Sudoku sudoku1 = new Sudoku();

			while (entry == false)
			{
				Console.WriteLine("Enter Sudoku Puzzle from left to right and top to bottom seperated by commas:");
				input = Console.ReadLine();
				_parsing = input.Split(",");

				int i = 0;
				foreach (string s in _parsing)
				{
					_parsed[i] = Convert.ToInt32(s);
					i++;
				}

				sudoku1 = new Sudoku(_parsed);

				Console.WriteLine();
				sudoku1.displayBoard();
				Console.WriteLine("Does this look correct?(Y/N)");
				string confirm = Console.ReadLine();

				while (confirm != "Y" && confirm != "y" && confirm != "N" && confirm != "n")
				{
					Console.WriteLine("Invalid Entry!");
					Console.WriteLine("Does this look correct?(Y/N)");
					confirm = Console.ReadLine();
				}

				if (confirm == "Y" || confirm == "y")
					entry = true;
			}

			Console.WriteLine(sudoku1.validateBoard());
			sudoku1.solve();
			Console.WriteLine(sudoku1.repititions);

			//Puzzle results = new Puzzle(puzzle.solve());
			//results.displayPuzzzle();

			//if (puzzle.validate() == true) Console.WriteLine("This is a valid puzzle");
			//else Console.WriteLine("This is a invalid puzzle");
		}
	}
}