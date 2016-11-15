// ------------------------------------------------------------ >>
// Project: GoL
// TODO: Array bounding checks and positioning
// Good: Both 'Blinker' and 'Block' appear to be working
// ------------------------------------------------------------ >>
using System;

namespace gol
{
    class Program
    {
        static void Main(string[] args)
        {
            const int rows = 11;
            const int columns = 7;
            bool[,] demo = new bool[rows, columns];

            // Gap neighbor test with 3rd being focal point
            //demo[2, 0] = true;
            //demo[3, 1] = true;
            //demo[2, 2] = true;

            // Vertical Line aka blinker phase2
            //demo[7, 5] = true;
            //demo[8, 5] = true;
            //demo[9, 5] = true;

            // Block Test
            demo[1, 5] = true;
            demo[2, 5] = true;
            demo[1, 4] = true;
            demo[2, 4] = true;

            // Blinker Test aka blinker phase1
            demo[8, 1] = true;
            demo[8, 2] = true;
            demo[8, 3] = true;

            // Instantiate GameofLife object
            GameOfLife gold = new GameOfLife(demo, rows, columns);
            gold.drawGrid();
            gold.tick();
            gold.tick();

            while (true) ;
        }
    }

    class GameOfLife
    {
        private int Rows, Columns;
        private bool[,] Grid1;
        private bool[,] Grid2;

        public GameOfLife(bool[,] startingGrid, int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;

            Grid1 = new bool[rows, columns];
            Grid2 = new bool[rows, columns];

            this.Grid1 = startingGrid;
        } // end default constructor

        public void tick()
        {
            Grid2.Initialize();
            gridScan();
            applyGridChanges();
            drawGrid();
        } // end tick method

        private void gridScan()
        {
            // Need to perform bound checking and change starting points
            // evaluating neighbors with this method requires looking at every node
            // bound checking to make sure neighborly checks dont jump off the array edges
        
            for (int i = 1; i < (Rows - 1); i++)
            {
                for(int j = 1; j < (Columns - 1); j++)
                {
                    checkNeighbors(i, j);
                }
            }
        } // end gridScan method

        public void drawGrid()
        {
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (Grid1[i, j] == true) Console.ForegroundColor = ConsoleColor.Green;

                    if(Grid1[i, j]) Console.Write(" 1 ");
                    else Console.Write(" 0 ");

                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        } // end drawGrid method

        private void checkNeighbors(int row_pos, int col_pos)
        {
            int live_count = 0;

            for (int i = -1; i < 2; i++)
            {
                if (Grid1[row_pos + 1, col_pos + i]) live_count++;
                if(i != 0 && Grid1[row_pos, col_pos + i]) live_count++;
                if (Grid1[row_pos - 1, col_pos + i]) live_count++;
            }

            switch(live_count)
            {
                case 0:
                case 1:
                    // Kill the cell - under population - Rule1
                    Grid2[row_pos, col_pos] = false;
                    break;
                case 2:
                    // Living can continue - Rule3
                    if(Grid1[row_pos,col_pos]) Grid2[row_pos, col_pos] = true;
                    break;
                case 3:
                    // If cell dead resurrect - Rule4
                    // Living can continue - Rule3
                    Grid2[row_pos, col_pos] = true;
                    break;
                default:
                    // Kill the cell - overpopulation - Rule2
                    Grid2[row_pos, col_pos] = false;
                    break;
            }
        } // End checkNeighbors method

        private void applyGridChanges()
        {
            // Checks complete copy modified Grid2 to Grid1
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Grid1[i, j] = Grid2[i, j];
                }
            }
        } // end applyGridChanges method

        private void applyRule4(int row_pos, int col_pos)
        {
            // Top 
            if (Grid2[row_pos - 1, col_pos - 1] && Grid2[row_pos - 1, col_pos] && Grid2[row_pos - 1, col_pos + 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid2[row_pos - 1, col_pos - 1] && Grid2[row_pos, col_pos] && Grid2[row_pos - 1, col_pos + 1]) Grid1[row_pos - 1, col_pos] |= true;

            // Left
            if (Grid2[row_pos - 1, col_pos - 1] && Grid2[row_pos, col_pos - 1] && Grid2[row_pos + 1, col_pos - 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid2[row_pos - 1, col_pos - 1] && Grid2[row_pos, col_pos] && Grid2[row_pos + 1, col_pos - 1]) Grid1[row_pos, col_pos - 1] |= true;

            // Middle
            if (Grid2[row_pos, col_pos - 1] && Grid2[row_pos, col_pos] && Grid2[row_pos, col_pos + 1])
            {
                Grid1[row_pos + 1, col_pos] |= true;
                Grid1[row_pos - 1, col_pos] |= true;
            }

            // Center
            if (Grid2[row_pos - 1, col_pos] && Grid2[row_pos, col_pos] && Grid2[row_pos + 1, col_pos])
            {
                Grid1[row_pos, col_pos + 1] |= true;
                Grid1[row_pos, col_pos - 1] |= true;
            }

            // Right
            if (Grid2[row_pos - 1, col_pos + 1] && Grid2[row_pos, col_pos + 1] && Grid2[row_pos + 1, col_pos + 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid2[row_pos - 1, col_pos + 1] && Grid2[row_pos, col_pos] && Grid2[row_pos + 1, col_pos + 1]) Grid1[row_pos, col_pos + 1] |= true;

            // Bottom
            if (Grid2[row_pos + 1, col_pos - 1] && Grid2[row_pos + 1, col_pos] && Grid2[row_pos + 1, col_pos + 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid2[row_pos + 1, col_pos - 1] && Grid2[row_pos, col_pos] && Grid2[row_pos + 1, col_pos + 1]) Grid1[row_pos + 1, col_pos] |= true;
        }

    }
}
