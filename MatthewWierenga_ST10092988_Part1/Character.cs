using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
     class Character
    {
        public int CharacterMaxHP;
        public int CharacterDamage;
        public int CharacterHP;

        public int GoblinMaxHP;
        public int GoblinDamage;
        public int GoblinHP;





        public enum Movement
        {
            NoMovement,
            Up,
            Down,
            Right,
            Left,

        }
        public bool isDead;

        public bool CheckRange;
    }
}
