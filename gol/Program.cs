// ------------------------------------------------------------ >>
// Project: GoL
// TODO: 
//
// Good: 
//
// |==> Call placePattern before a tick() call to ensure changes are applied to grid
//      
// ------------------------------------------------------------ >>
using System;

namespace gol
{
    class Program
    {
        static void Main(string[] args)
        {
            const int rows = 12;
            const int columns = 15;
            bool[,] demo = new bool[rows, columns];

            // Instantiate GameofLife object
            GameOfLife gold = new GameOfLife(demo, rows, columns);

            gold.placePattern("beacon", 7, 7);
            gold.placePattern("blinker", 8, 2);
            gold.placePattern("block", 1, 5);
            gold.placePattern("toad", 2, 10);

            drawGrid(gold.Grid, gold.ROWS, gold.COLUMNS);        // Display output
            gold.tick();            // Show one step
            drawGrid(gold.Grid, gold.ROWS, gold.COLUMNS);        // Display output
            gold.tick();            // Show second step and view application of rules
            drawGrid(gold.Grid, gold.ROWS, gold.COLUMNS);        // Display output

            while (true) ;          // Used to hold terminal window open for output
        }

        static void drawGrid(bool[,] grid, int rows, int columns)
        {
            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i, j] == true) Console.ForegroundColor = ConsoleColor.Green;

                    if (grid[i, j]) Console.Write(" 1 ");
                    else Console.Write(" 0 ");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        } // End drawGrid
    } // End program
} // End namespace
