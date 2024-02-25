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
    public partial class GameProperties : Form
    {
        public GameProperties()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //combobox is null or empty control
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please select the game properties");
            }
            else
            {
                //combobox is null or empty control
                int result = 0;
                int bombCount = Convert.ToInt32(comboBox2.Text);
                string[] parts = comboBox1.Text.Split('x');
                int.TryParse(parts[0], out result);
                if ((result * result) < bombCount)
                {
                    MessageBox.Show("The number of bombs must be less than the number of buttons");
                }
                else
                {
                    Program.map = new Map(result, bombCount);
                    Playing.Play(Program.map, result, bombCount);

                }
            }

           
        }
    }
}
