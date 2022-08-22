using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
   public abstract class Character:Tile
    {
        protected int hp;
        public int HP
        {
            get { return hp; } 
            set { hp = value; }

        }
        protected int maxhp;
        public int Maxhp
        {
            get { return maxhp; }
            set { maxhp = value; }

        }

        protected int damage;
        public int Damage
        {
            get { return damage; }
            set { damage = value; }

        }

        protected List<Tile> vision;
        public List<Tile> Vision
        {
            get { return vision; }
            set
            {
                vision = value;
            }
        }

        protected int movement;
        public int Movement
        {
            get { return movement; }
            set
            {
                movement = value;
            }   

        }

        protected Character (int _X, int _Y, TileType _TYPEOFTILE, string _SYMBOL, int _HP, int _MAXHP, int _DAMAGE) : base(_X, _Y, _SYMBOL, _TYPEOFTILE)
        {
            SYMBOL = _SYMBOL;
            HP = _HP;
            Maxhp = _MAXHP;
            Damage = _DAMAGE;
            Vision = new List<Tile>();
        }

        public virtual void Attack(Character Target)
        {
            Target.HP -= Damage;
        }

        public bool IsDead()
        {
            if (HP <= 0)
            {
                return true;

            }
            else return false;
        }

        public virtual bool CheckRange(Character Target)
        {
            int ReachableDistance = 1;
            if (DistanceTo(Target) <= ReachableDistance)
            {
                return true;

            }
            else return false;
        }

        private int DistanceTo(Character Target)
        {
            return Math.Abs(X - Target.X) + Math.Abs(Y - Target.Y);
        }

        public void Move(MovementDirection CharacterMove)
        {
            switch(CharacterMove)
            {
                case MovementDirection.Up:
                    Y--;
                    if (Y == 0)
                    {
                        Y = 1;
                    }
                    break;

                case MovementDirection.Down:
                    Y++;

                    break;

                case MovementDirection.Left:
                    X--;
                    if(X == 0)
                    {
                        X = 1;
                    }
                    break;

                case MovementDirection.Right:
                    X++;
                    break;
            }
        }

        public abstract MovementDirection ReturnMove(MovementDirection CharacterMove = 0);
        public abstract override string ToString();
    }
}
