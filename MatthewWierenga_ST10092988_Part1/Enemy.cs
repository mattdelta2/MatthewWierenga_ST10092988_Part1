using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
    public abstract class Enemy : Character
    {
        protected Random Random_Number_Generator = new Random();

        protected Enemy(int _X, int _Y, TileType _TYPEOFTILE, string _SYMBOL, int _DAMAGE, int _STARTINGHP, int _MAXHP) : base(_X, _Y, _TYPEOFTILE, _SYMBOL, _DAMAGE, _STARTINGHP, _MAXHP)
        {
            Damage = _DAMAGE;
            HP = _STARTINGHP;
            Maxhp = _MAXHP;
        }

        public override string ToString()
        {
            string Info = GetType().Name + "";
            Info += "at [ " + X.ToString() + "," + Y.ToString() + "] \n";
            Info += HP.ToString() + " HP \n";
            Info += "{" + Damage.ToString() + "}";
            return Info;
        }
    }
}
