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

        private TileType typeoftile;
        public TileType TYPEOFTILE
        {
            get { return typeoftile; }
            set { typeoftile = value; }
        }

        private string symbol;
        public string SYMBOL
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public Tile(int _X, int _Y, string _SYMBOL, TileType _TYPEOFTILE)
        {
            X = _X;
            Y = _Y;
            SYMBOL = _SYMBOL;
            TYPEOFTILE = _TYPEOFTILE;
        }
    }
}
