using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver
{
    public partial class Form1 : Form
    {
        public const int n=81;
        //Controls
        public TextBox[] tb = new TextBox[n];


        public Form1()
        {
            InitializeComponent();
        }

        private void ScanValue_Click(object sender, EventArgs e)
        {
            int[,] entry = new int[9, 9];



            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (tb[(i * 9) + (j)].Text == "")   entry[i, j] = 0;
                    else                                entry[i, j] = Int32.Parse(tb[(i * 9) + (j)].Text);
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int w = 50;
            const int h = 50;
            //offsets
            int OffSetTop = 0;
            int OffSetLeft = 0;

            for (int i = 0; i < n; i++)
            {
                tb[i] = new TextBox
                {
                    //set textbox properties
                    Text = "",
                    MaxLength = 1,
                    //multiline must be true to set textbox height
                    Multiline = true,
                    Width = w,
                    Height = h,
                    Enabled = true,
                    Visible = true,
                    //uses offsets to realign every 9 rows
                    Top = (80 + OffSetTop),
                    Left = 80 + (i * w) - OffSetLeft,
                    Margin = new System.Windows.Forms.Padding(0),
                    Font = new Font("Arial", 20),
                    TextAlign = HorizontalAlignment.Center,
                };
                //add control after setting parameters
                this.Controls.Add(tb[i]);
                //resets left offset to original position after 9 instances
                if ((i+1)%9 == 0) { OffSetLeft += w*9;OffSetTop += h; }

            }
        }
    }
}
