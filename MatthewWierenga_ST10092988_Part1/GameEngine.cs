using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
    public class GameEngine
    {
        private Map gamemap;
        public Map GAMEMAP
        {
            get { return gamemap; }
            set { gamemap = value; }
        }

        Random RANDOM_NUMBER_GENERATOR = new Random();

        public GameEngine()
        {
            GAMEMAP = new Map(10, 10, 10, 10, 5, 5);
        }


        public bool MovePlayer(MovementDirection Direction)
        {
            if (GAMEMAP.PLAYERCHARACTER.ReturnMove(Direction) == Direction)
            {
                GAMEMAP.Create(TileType.Empty, GAMEMAP.PLAYERCHARACTER.X, GAMEMAP.PLAYERCHARACTER.Y);

                GAMEMAP.PLAYERCHARACTER.Move(Direction);
                GAMEMAP.MAPCONTAINER[GAMEMAP.PLAYERCHARACTER.X, GAMEMAP.PLAYERCHARACTER.Y] = GAMEMAP.PLAYERCHARACTER;

                return true;
            }

            return false;
        }

        public string PlayerAttack(int EnemyIndex)
        {
            bool EnemyInRange = false;

            foreach (Tile T in GAMEMAP.PLAYERCHARACTER.Vision)
            {
                if (T.X == GAMEMAP.ENEMIES[EnemyIndex].X && (T.Y == GAMEMAP.ENEMIES[EnemyIndex].Y))
                {
                    EnemyInRange = true;
                    break;
                }
            }

            if (EnemyInRange)
            {
                GAMEMAP.PLAYERCHARACTER.Attack(GAMEMAP.ENEMIES[EnemyIndex]);
                return "You did " + GAMEMAP.PLAYERCHARACTER.Damage.ToString() + " damage to a " + GAMEMAP.ENEMIES[EnemyIndex].TYPEOFTILE.ToString() + " leaving them on " + GAMEMAP.ENEMIES[EnemyIndex].HP.ToString() + "HP";
            }
            else
            {
                return "Target was not in range...";
            }
        }

      

    }
}
