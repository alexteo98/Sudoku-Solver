﻿using Sudoku_Solver;
using System;

namespace ConsoleTester
{
	class Program
	{
		static void Main(string[] args)
		{

			// test puzzle
			// 4,3,5,2,6,9,7,8,1,6,8,2,5,7,1,4,9,3,1,9,7,8,3,4,5,6,2,8,2,6,1,9,5,3,4,7,3,7,4,6,8,2,9,1,5,9,5,1,7,4,3,6,2,8,5,1,9,3,2,6,8,7,4,2,4,8,9,5,7,1,3,6,7,6,3,4,1,8,2,5,9
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

			if (puzzle.validate() == true) Console.WriteLine("True");
			else Console.WriteLine("False");
			
			input = "";
		}
	}
}
