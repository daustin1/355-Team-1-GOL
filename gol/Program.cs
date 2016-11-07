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

            demo[0, 0] = true;
            demo[0, 2] = true;
            demo[1, 1] = true;

            demo[0, 6] = true;
            demo[1, 6] = true;
            demo[2, 6] = true;

            demo[3, 0] = true;
            demo[3, 1] = true;
            demo[3, 2] = true;

            GameOfLife gold = new GameOfLife(demo, rows, columns);
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
        }

        public void tick()
        {
            Grid2 = Grid1;
            drawGrid();
            gridScan();
            Console.WriteLine();
            drawGrid();
        }

        private void gridScan()
        {
            for (int i = 1; i < (Rows - 2); i+=2)
            {
                for(int j = 1; j < (Columns - 2); j+=2)
                {
                    checkNeighbors(i, j);
                }
            }
        }

        public void drawGrid()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(Grid1[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void checkNeighbors(int row_pos, int col_pos)
        {
            int live_count = 0;

            if (((Grid1[row_pos - 1, col_pos - 1] | Grid1[row_pos, col_pos - 1]  | Grid1[row_pos + 1, col_pos - 1] ) & true) == true) live_count++;

            if (((Grid1[row_pos - 1, col_pos] | Grid1[row_pos, col_pos] | Grid1[row_pos + 1, col_pos]) & true) == true) live_count++;

            if (((Grid1[row_pos - 1, col_pos + 1] | Grid1[row_pos, col_pos + 1] | Grid1[row_pos + 1, col_pos + 1]) & true) == true) live_count++;
            
            if(live_count > 2) applyRule4(row_pos, col_pos);
        }

        private void applyRule4(int row_pos, int col_pos)
        {
            // Top 
            if (Grid1[row_pos - 1, col_pos - 1] && Grid1[row_pos - 1, col_pos] && Grid1[row_pos - 1, col_pos + 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid1[row_pos - 1, col_pos - 1] && Grid1[row_pos, col_pos] && Grid1[row_pos - 1, col_pos + 1]) Grid1[row_pos - 1, col_pos] |= true;

            // Left
            if (Grid1[row_pos - 1, col_pos - 1] && Grid1[row_pos, col_pos - 1] && Grid1[row_pos + 1, col_pos - 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid1[row_pos - 1, col_pos - 1] && Grid1[row_pos, col_pos] && Grid1[row_pos + 1, col_pos - 1]) Grid1[row_pos, col_pos - 1] |= true;

            // Right
            if (Grid1[row_pos - 1, col_pos + 1] && Grid1[row_pos, col_pos + 1] && Grid1[row_pos + 1, col_pos + 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid1[row_pos - 1, col_pos + 1] && Grid1[row_pos, col_pos] && Grid1[row_pos + 1, col_pos + 1]) Grid1[row_pos, col_pos + 1] |= true;

            // Bottom
            if (Grid1[row_pos + 1, col_pos - 1] && Grid1[row_pos + 1, col_pos] && Grid1[row_pos + 1, col_pos + 1]) Grid1[row_pos, col_pos] |= true;
            else if (Grid1[row_pos + 1, col_pos - 1] && Grid1[row_pos, col_pos] && Grid1[row_pos + 1, col_pos + 1]) Grid1[row_pos + 1, col_pos] |= true;
        }

        private void applyRule2()
        {

        }

        private void applyRule3()
        {

        }

    }
}
