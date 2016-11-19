// ------------------------------------------------------------ >>
// Project: GoL
//
// TODO: 
//
// Good: 
//
// |==> Call placePattern before a tick() call to ensure changes are applied to grid
//      
// ------------------------------------------------------------ >>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gol
{
    public partial class Form1 : Form
    {
        // Hang Global References
        Button[,] MCB;
        GameOfLife gold;

        public Form1()
        {
            InitializeComponent();

            // Define game grid size
            const int rows = 24;
            const int columns = 56;
            bool[,] demo = new bool[rows, columns];

            // Instantiate GameofLife object
            gold = new GameOfLife(demo, rows, columns);

            // Place some patterns
            gold.placePattern(GameOfLife.patterns.beacon, 7, 7);
            gold.placePattern(GameOfLife.patterns.blinker, 8, 2);
            gold.placePattern(GameOfLife.patterns.block, 1, 5);
            gold.placePattern(GameOfLife.patterns.toad, 2, 10);

            Point p = new Point(0, 0);
            Size s = new Size(12, 12);
            MCB = new Button[rows, columns];
            int findy = 0;

            // Init Button Array - Visual Representation of Grid
            for (int i = 0; i < rows; i++)
            {
                p.X = 2;
                p.Y += 14;
                for (int j = 0; j < columns; j++)
                {
                    p.X += 14;

                    Button b = new Button();
                    b.Size = s;
                    b.Location = p;
                    b.BackColor = Color.Red;
                    MCB[i, j] = b;
                    this.Controls.Add(b);
                    b.Name = findy.ToString();
                    findy++;
                    b.Click += new EventHandler(findmy_Button_Click);
                }
            }
            this.Update();
        }

        private void step_Button_Click(object sender, EventArgs e)
        {
            gold.tick();
            drawGrid();
            this.Update();
        } // End step_Button_Click

        private void run_Button_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 60; j++)
            {
                gold.tick();
                drawGrid();
                this.Update();

                for (int i = 0; i < int.MaxValue / 20; i++)
                {
                    // Burn some time
                }
            }
        } // End run_Button_Click

        private void clear_Button_Click(object sender, EventArgs e)
        {
            int row = gold.ROWS, col = gold.COLUMNS;
            bool[,] boo = new bool[row, col];
            gold = new GameOfLife(boo, row, col);
            drawGrid();
        } // End clear_Button_Click

        private void stop_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        } // End stop_Button_Click

        private void findmy_Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.AliceBlue;
            int temp = 0;
            int.TryParse(b.Name, out temp);
            if (gold.COLUMNS - temp >= 0)
            {
                gold.flipAbit(0, temp);
            }
            else
            {
                int j = gold.COLUMNS + gold.COLUMNS;
                for (int i = 1; i < gold.ROWS; i++)
                {
                    if (j - temp >= 0)
                    {
                        gold.flipAbit(i, temp - gold.COLUMNS*i );
                        break;
                    }
                    else j += gold.COLUMNS;
                }
            }
            drawGrid();
        }

        private void drawGrid()
        {
            for (int i = 0; i < gold.ROWS; i++)
            {
                for (int j = 0; j < gold.COLUMNS; j++)
                {
                    if (gold.Grid[i, j] == true) MCB[i, j].BackColor = Color.Green;
                    else MCB[i, j].BackColor = Color.White;
                }
            }
        } // end drawGrid method

    } // End form1
}
