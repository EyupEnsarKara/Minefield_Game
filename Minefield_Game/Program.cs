using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;   

namespace Minefield_Game
{
    internal class Program
    {
        int n = 0;
        public static Map map;
        
        static void Main(string[] args)
        {   
            Application.Run(new GameProperties());
      
            Console.ReadLine();
         }
    }
}
