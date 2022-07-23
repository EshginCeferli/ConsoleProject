using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Helpers
{
	//Basaramadik abi
    public class Animations
    {
		int counter;

		public Animations()
		{
			counter = 0;
		}

		public void Turn(string loadingText)
		{
			Console.SetCursorPosition(loadingText.Length, 0);

			switch (counter % 4)
			{
				case 0: Console.WriteLine("/"); break;
				case 1: Console.WriteLine("-"); break;
				case 2: Console.WriteLine("\\"); break;
				case 3: Console.WriteLine("|"); break;
			}
		}
		public void SequencedMatrix(int row, int column, int width, int height)
		{
			Console.SetCursorPosition(column, row);

			int spot = counter % width;
			int[,] array = new int[width, height];

			for (int x = 0; x < array.GetLength(0); x++)
			{
				for (int y = 0; y < array.GetLength(0); y++)
				{
					if (y == spot)
					{
						Console.Write("[X]");
						continue;
					}

					Console.Write("[ ]");
				}
				Console.WriteLine("");
			}
		}
	}
}
