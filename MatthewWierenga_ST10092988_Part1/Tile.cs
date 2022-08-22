using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
    public abstract class Tile
    {
        protected int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        protected int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
