using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield_Game
{
    public partial class Main : Form
    {
   
        public Main()
        {
            
            InitializeComponent();
            AddButtons(Program.map.buttons);
            this.Size = new Size(Program.map.n * 40+16, Program.map.n * 40+39);
        }

       
        public void AddButtons(Button_[,] buttons)
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    this.Controls.Add(buttons[i, j].button);
                }
            }
        }

    }
}
