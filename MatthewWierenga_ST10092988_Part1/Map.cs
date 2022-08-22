using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatthewWierenga_ST10092988_Part1
{
    public class Map
    {
        private Tile[,] mapcontainer;
        public Tile[,] MAPCONTAINER
        {
            get { return mapcontainer; }
            set { mapcontainer = value; }
        }

        private Hero playercharacter;
        public Hero PLAYERCHARACTER
        {
            get { return playercharacter; }
            set { playercharacter = value; }
        }

        private List<Enemy> enemies;
        public List<Enemy> ENEMIES
        {
            get { return enemies; }
            set { enemies = value; }
        }

        private int mapwidth;
        public int MAPWIDTH
        {
            get { return mapwidth; }
            set { mapwidth = value; }
        }

        private int mapheight;
        public int MAPHEIGHT
        {
            get { return mapheight; }
            set { mapheight = value; }
        }

        int hX;
        int hY;

        protected Random RANDOM_NUMBER_GENERATOR = new Random();


        public Map(int _MINWIDTH, int _MAXWIDTH, int _MINHEIGHT, int _MAXHEIGHT, int _NUMBEROFENEMIES, int _NUMBEROFITEMS)
        {
            MAPWIDTH = RANDOM_NUMBER_GENERATOR.Next(_MINWIDTH, _MAXWIDTH);
            MAPHEIGHT = RANDOM_NUMBER_GENERATOR.Next(_MINHEIGHT, _MAXHEIGHT);

            MAPCONTAINER = new Tile[MAPWIDTH, MAPHEIGHT];

            ENEMIES = new List<Enemy>();

            GenerateInitialMap(_NUMBEROFENEMIES);

            UpdateVision();

           
        }

        public void UpdateVision()
        {
            foreach (Enemy E in ENEMIES)
            {
                E.Vision.Clear();

                if (E.X > 0)
                {
                    E.Vision.Add(MAPCONTAINER[E.X - 1, E.Y]);
                }

                if (E.X < MAPWIDTH - 1)
                {
                    E.Vision.Add(MAPCONTAINER[E.X + 1, E.Y]);
                }

                if (E.Y > 0)
                {
                    E.Vision.Add(MAPCONTAINER[E.X, E.Y - 1]);
                }

                if (E.Y < MAPHEIGHT - 1)
                {
                    E.Vision.Add(MAPCONTAINER[E.X, E.Y + 1]);
                }
            }

            PLAYERCHARACTER.Vision.Clear();

            if (PLAYERCHARACTER.X > 0)
            {
                PLAYERCHARACTER.Vision.Add(MAPCONTAINER[PLAYERCHARACTER.X - 1, PLAYERCHARACTER.Y]);
            }

            if (PLAYERCHARACTER.X < MAPWIDTH - 1)
            {
                PLAYERCHARACTER.Vision.Add(MAPCONTAINER[PLAYERCHARACTER.X + 1, PLAYERCHARACTER.Y]);
            }

            if (PLAYERCHARACTER.Y > 0)
            {
                PLAYERCHARACTER.Vision.Add(MAPCONTAINER[PLAYERCHARACTER.X, PLAYERCHARACTER.Y - 1]);
            }

            if (PLAYERCHARACTER.Y < MAPHEIGHT - 1)
            {
                PLAYERCHARACTER.Vision.Add(MAPCONTAINER[PLAYERCHARACTER.X, PLAYERCHARACTER.Y + 1]);
            }

            int t = 0;
        }

        void GenerateInitialMap(int _NUMBEROFENEMIES)
        {
            for (int y = 0; y < MAPWIDTH; y++)
            {
                for (int x = 0; x < MAPHEIGHT; x++)
                {
                    if (x == 0 || x == MAPWIDTH - 1 || y == 0 || y == MAPHEIGHT - 1)
                    {
                        Create(TileType.Barrier, x, y);
                    }
                    else
                    {
                        Create(TileType.Empty, x, y);
                    }
                }
            }

            Create(TileType.Hero);

            for (int e = 0; e < _NUMBEROFENEMIES; e++)
            {
                Create(TileType.Enemy);
            }

          
        }

        public void Create(TileType TypeOfTile, int X = 0, int Y = 0)
        {
            switch (TypeOfTile)
            {
                case TileType.Barrier:
                    Obstacle NewBarrier = new Obstacle(X, Y, "#", TypeOfTile);
                    MAPCONTAINER[X, Y] = NewBarrier;
                    break;
                case TileType.Empty:
                    EmptyTile NewEmptyTile = new EmptyTile(X, Y, " ", TypeOfTile);
                    MAPCONTAINER[X, Y] = NewEmptyTile;
                    break;
                case TileType.Hero:
                    int HeroX = RANDOM_NUMBER_GENERATOR.Next(0, MAPWIDTH);
                    int HeroY = RANDOM_NUMBER_GENERATOR.Next(0, MAPHEIGHT);

                    while (MAPCONTAINER[HeroX, HeroY].TYPEOFTILE != TileType.Empty)
                    {
                        HeroX = RANDOM_NUMBER_GENERATOR.Next(0, MAPWIDTH);
                        HeroY = RANDOM_NUMBER_GENERATOR.Next(0, MAPHEIGHT);
                    }

                    Hero NewHero = new Hero(HeroX, HeroY, TypeOfTile, "H", 100, 100, 10);
                    PLAYERCHARACTER = NewHero;
                    MAPCONTAINER[HeroX, HeroY] = NewHero;
                    hX = HeroX;
                    hY = HeroY;
                    break;
                case TileType.Enemy:
                    int EnemyX = RANDOM_NUMBER_GENERATOR.Next(0, MAPWIDTH);
                    int EnemyY = RANDOM_NUMBER_GENERATOR.Next(0, MAPHEIGHT);

                    while (MAPCONTAINER[EnemyX, EnemyY].TYPEOFTILE != TileType.Empty)
                    {
                        EnemyX = RANDOM_NUMBER_GENERATOR.Next(0, MAPWIDTH);
                        EnemyY = RANDOM_NUMBER_GENERATOR.Next(0, MAPHEIGHT);
                    }

                    if (RANDOM_NUMBER_GENERATOR.Next(1, 3) == 1)
                    {
                        SwampCreature NewEnemy = new SwampCreature(EnemyX, EnemyY, TypeOfTile, "G", 100, 100, 10);
                        ENEMIES.Add(NewEnemy);
                        MAPCONTAINER[EnemyX, EnemyY] = NewEnemy;
                    }

                    break;
            }
        }

        public override string ToString()
        {
            string MapString = "";

            for (int y = 0; y < MAPWIDTH; y++)
            {
                for (int x = 0; x < MAPHEIGHT; x++)
                {
                    MapString += MAPCONTAINER[x, y].SYMBOL;
                }
                MapString += "\n";
            }
            return MapString;
        }
    }
}
