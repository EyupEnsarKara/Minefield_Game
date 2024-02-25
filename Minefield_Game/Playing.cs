using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield_Game
{
    public static  class Playing
    {

        public static void Play(Map map,int n,int bombCount)
        {   
            map.SetProperties();
            map.SetBombs(bombCount);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    map.SetBombCount(i, j);
                }
            }

            for (int i = 0; i < map.buttons.GetLength(0); i++)
            {
                for (int j = 0; j < map.buttons.GetLength(1); j++)
                {
                    int row = i;
                    int col = j;
                    map.buttons[i, j].button.Click += (sender, e) => map.Click_Button(row, col);
                    map.buttons[i, j].button.MouseDown += (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Right)
                        {   
                            map.RightClick_Button(row, col);

                        }
                    };
                }
            }
          
            Main main = new Main();
            main.ShowDialog();

        }
        public static bool winControl(Map map)
        {
            int count = 0;
            for (int i = 0; i < map.buttons.GetLength(0); i++)
            {
                for (int j = 0; j < map.buttons.GetLength(1); j++)
                {
                    if (map.buttons[i, j].button.Enabled == false)
                    {
                        count++;
                    }
                }
            }
            if (count == map.n * map.n - map.bombCount)
            {
                return true;
            }
            return false;
        }

    }
}
