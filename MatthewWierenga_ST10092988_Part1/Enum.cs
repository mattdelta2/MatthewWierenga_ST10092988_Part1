using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
    public enum TileType
    {
        Hero,
        Enemy,
        Gold,
        Weapon,
        Barrier,
        Empty
    }

    public enum MovementDirection
    {
        NoMovement,
        Up,
        Down,
        Left,
        Right,
    }
}
