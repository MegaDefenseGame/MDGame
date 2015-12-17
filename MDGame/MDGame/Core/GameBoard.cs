using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDGame.Core
{
    public class GameBoard
    {
        public const int WALL = 1;
        public const int FLOOR = 0;
        public const int HERO1 = 2;
        public const int HERO2 = 3;
        public const int HERO3 = 4;
        public const int HERO4 = 5;
        public const int HERO5 = 6;
        public const int HERO6 = 7;
        public const int ENEMY1 = 11;
        public const int ENEMY2 = 12;
        public const int ENEMY3 = 13;
        public const int ENEMY4 = 14;
        public const int ENEMY5 = 15;
        public const int ENEMY6 = 16;
        public const int ENEMY7 = 17;

        private int[,] _map;
        private int[] _hero;
        
        public GameBoard()
        {
            _map = new int[,] { { 1 , 1 , 1 , 1 , 1 , 1 , 1 },
                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                                 { 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                               };
            _hero = new int[] { 0, 1, 2, 3, 4, 5 };

        }

        int[][] maps;
        public int[,] Map
        {
            get
            {
                return _map;
            }
            set
            {
                if (this._map != value)
                    this._map = value;
            }
        }
        public int[] Hero
        {
            get
            {
                return _hero;
            }
            set
            {
                if (this._hero != value)
                    this._hero = value;
            }
        }
    }
}
