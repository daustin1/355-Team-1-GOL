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
            // Define game grid size
            const int rows = 12;
            const int columns = 15;
            bool[,] demo = new bool[rows, columns];

            // Instantiate GameofLife object
            GameOfLife gold = new GameOfLife(demo, rows, columns);

            // Place some patterns
            gold.placePattern(GameOfLife.patterns.beacon, 7, 7);
            gold.placePattern(GameOfLife.patterns.blinker, 8, 2);
            gold.placePattern(GameOfLife.patterns.block, 1, 5);
            gold.placePattern(GameOfLife.patterns.toad, 2, 10);

            draw_OverGrid(gold.Grid, gold.ROWS, gold.COLUMNS);        // Display output
            gold.tick();            // Show one step
            draw_OverGrid(gold.Grid, gold.ROWS, gold.COLUMNS);        // Display output
            gold.tick();            // Show second step and view application of rules
            draw_OverGrid(gold.Grid, gold.ROWS, gold.COLUMNS);        // Display output

            while (true) ;          // Used to hold terminal window open for output
        }

        // Draws the grid incrementally - good for viewing steps to validate application of rules
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

        // Draws the grid over itself
        static void draw_OverGrid(bool[,] grid, int rows, int columns)
        {
            int xcurpos = 0;
            int ycurpos = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i, j] == true) Console.ForegroundColor = ConsoleColor.Green;

                    if (grid[i, j])
                    {
                        Console.SetCursorPosition(xcurpos, ycurpos);
                        Console.Write(" 1 ");
                    }
                    else
                    {
                        Console.SetCursorPosition(xcurpos, ycurpos);
                        Console.Write(" 0 ");
                    }
                    xcurpos += 2;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ycurpos += 2;
                xcurpos = 0;
            }

            // THIS IS JUST A TEST - CANNOT STAY LIKE THIS
            // burn time to show transitions
            // needs to be replaced with a timer and pull it out of draw
            for (int i = 0; i < int.MaxValue / 10; i++) i++;
            // TEST

        } // End draw_OverGrid

    } // End program
} // End namespace
