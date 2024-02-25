using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield_Game
{
    public class Button_
    {
        public Button button;
        public bool isBomb;
        public int bombCount;
        public bool isFlag=false;

        public Button_()
        {
            button = new Button();
        }

    }
}
