using Minefield_Game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Minefield_Game
{
    public class Map
    {
        public int n;
        public Button_[,] buttons;
        public int bombCount=0;
        public Map(int n,int bombCount)
        {
            this.n = n;
            this.bombCount = bombCount;
            buttons = new Button_[n, n];


        }

        public void SetProperties()
        {
            int top = 0;
            int left = 0;

            for (int i = 0; i < n; i++)
            {
                left = 0;
                for (int j = 0; j < n; j++)
                {


                    buttons[i, j] = new Button_();
                    buttons[i, j].button = new Button();
                    buttons[i, j].button.Top = top;
                    buttons[i, j].button.Left = left;
                    buttons[i, j].button.Size = new Size(40,40);
                    buttons[i, j].button.BackColor = Color.LightBlue;

                    buttons[i, j].button.Font = new Font("Arial", 15, FontStyle.Bold);


                    left += 40;
                }
                top += 40;
            }
        }


        public void Click_Button(int i, int j)
        {   
            if (buttons[i, j].isBomb)
            {
                GameOver(buttons[i, j].button);
            }
            else
            {
 
                buttons[i, j].button.BackColor = Color.White;
                buttons[i, j].button.Enabled = false;

                buttons[i, j].button.Text = buttons[i, j].bombCount.ToString();

                if (buttons[i, j].bombCount == 0)
                {
                    for (int x = Math.Max(0, i - 1); x <= Math.Min(n - 1, i + 1); x++)
                    {
                        for (int y = Math.Max(0, j - 1); y <= Math.Min(n - 1, j + 1); y++)
                        {
                            if (x != i || y != j)
                            {
                                if (buttons[x, y].button.BackColor != Color.White)
                                {
                                    Click_Button(x, y);
                                }

                            }
                        }
                    }
                }
                if (Playing.winControl(Program.map))
                {
                    for (int a = 0; a < n; a++)
                    {
                        for (int b = 0; b < n; b++)
                        {
                            if (buttons[a, b].isBomb)
                            {
                                buttons[a, b].button.Image = null;
                                buttons[a, b].button.Image = Resources.bomb;
                                
                                buttons[a, b].button.ImageAlign = ContentAlignment.MiddleCenter;

                                buttons[a, b].button.Enabled = false;
                            }
                            else
                            {

                            

                            }
                        }
                    }

                    MessageBox.Show("You Win");


                }
            }
        }
        public void RightClick_Button(int i, int j)
        {
            if (buttons[i, j].isFlag)
            {
                buttons[i, j].isFlag = false;
                buttons[i, j].button.Image = null;
                buttons[i, j].button.Click += (sender, e) => Click_Button(i, j);

            }
            else
            {
                buttons[i, j].isFlag = true;
                buttons[i, j].button.Image = Resources.flag1;
                buttons[i, j].button.ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        


        public void SetBombs(int bomb_)
        {
            Random random = new Random();
            int bombs = bomb_; 
            for (int i = 0; i < bombs; i++)
            {
                int x = random.Next(0, n);
                int y = random.Next(0, n);
                if (buttons[x, y].isBomb)
                {
                    i--;
                }
                buttons[x, y].isBomb = true;
            }
        }


        public void SetBombCount(int x, int y)
        {  
            if (buttons[x, y].isBomb)
                return;
     
            int count = 0;
            if (x > 0 && y > 0 && buttons[x - 1, y - 1].isBomb)
                count++;
            if (x > 0 && buttons[x - 1, y].isBomb)
                count++;
            if (x > 0 && y < n - 1 && buttons[x - 1, y + 1].isBomb)
                count++;
            if (y > 0 && buttons[x, y - 1].isBomb)
                count++;
            if (y < n - 1 && buttons[x, y + 1].isBomb)
                count++;
            if (x < n - 1 && y > 0 && buttons[x + 1, y - 1].isBomb)
                count++;
            if (x < n - 1 && buttons[x + 1, y].isBomb)
                count++;
            if (x < n - 1 && y < n - 1 && buttons[x + 1, y + 1].isBomb)
                count++;
            buttons[x, y].bombCount = count;
        }

        public void GameOver(Button button)
        {
            button.BackColor = Color.Red;
            


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    buttons[i, j].button.Enabled = false;

                    if (buttons[i, j].isBomb)
                    {
                        buttons[i, j].button.BackColor = Color.Red;
                    }
                }
            }
            MessageBox.Show("Game Over");
        }

    }
}
