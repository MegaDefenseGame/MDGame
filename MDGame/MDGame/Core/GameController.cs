using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDGame.Core
{
    class GameController
    {
        private GameBoard _board = new GameBoard();
        private Random rand = new Random();
        private int _enemyNum;
        private int _wave;
        public bool _chkStart;
        public bool _heroClick = false;
        //public GameBoard Board
        //{
        //    get
        //    {
        //        return _board;
        //    }
        //    set
        //    {
        //        if (this._board != value)
        //            this._board = value;
        //    }
        //}

        private IView _view;
        public int _selectHero;
        public int _selectEnemy;
        public int _selectLocationEnemy;

        public int EnemyNum
        {
            get
            {
                return _enemyNum;
            }
            set
            {
                if (this._enemyNum != value)
                    this._enemyNum = value;
            }
        }
        public int Wave
        {
            get
            {
                return _wave;
            }
            set
            {
                if (this._wave != value)
                    this._wave = value;
            }
        }

        public void InitGameStart()
        {
            Wave = 1;
            EnemyNum = 8;
            _chkStart = true;
        }
        public void GameStart()
        {
            InitGameStart();
            SuffleEnemyLocationSpawn();
            SuffleEnemy();
        }
        public void SelectHeroPosition(int x, int y)
        {
            int heroIndex = y / 100; // +2 in board
            switch (heroIndex)
            {
                case 0:
                    _selectHero = GameBoard.HERO1;
                    break;
                case 1:
                    _selectHero = GameBoard.HERO2;
                    break;
                case 2:
                    _selectHero = GameBoard.HERO3;
                    break;
                case 3:
                    _selectHero = GameBoard.HERO4;
                    break;
                case 4:
                    _selectHero = GameBoard.HERO5;
                    break;
                case 5:
                    _selectHero = GameBoard.HERO6;
                    break;
            }
        }

        public void SetView(IView view)
        {
            this._view = view;
        }

        public void MapPosition(int x, int y)
        {
            int xMapIndex = x / 100;
            int yMapIndex = y / 100;
            if (_heroClick)
            {
                _board.Map[yMapIndex, xMapIndex] = _selectHero;
                NotifyMap();
                _heroClick = false;
            }
            
        }

        public void NotifyMap()
        {
            if (_view != null)
                _view.UpdateMap(_board);
        }
        public void NotifyEnemySpawn()
        {
            if (_view != null)
                _view.UpdateEnemy(_board);
        }

        public int[,] GetMaps(int state)
        {
            return this._board.Map;
        }

        public void EnemySpawn()
        {
            NotifyEnemySpawn();
            SuffleEnemyLocationSpawn();
            SuffleEnemy();
        }
        public int SuffleEnemyTimeSpawn()
        {
            int time = 0;
            int TimeSpawn;
            TimeSpawn = rand.Next(1, 3);
            switch (TimeSpawn)
            {
                case 1:
                    time = 6000;
                    break;
                case 2:
                    time = 8000;
                    break;
                case 3:
                    time = 10000;
                    break;
            }
            return time;
        }
        public void SuffleEnemyLocationSpawn()
        {
            _selectLocationEnemy = rand.Next(1, 5);
        }
        public void SuffleEnemy() // TODO : Number of Enemy not finished yet !!!! don't forget to do it
        {
            switch (Wave)
            {
                case 1:
                    if (_enemyNum == 8 || _enemyNum == 7)
                    {
                        _selectEnemy = 11;
                    }
                    else
                        _selectEnemy = rand.Next(11, 16);
                    EnemyNum--;
                    break;
                case 2:
                    _selectEnemy = rand.Next(11, 16);
                    EnemyNum--;
                    break;
                case 3:
                    _selectEnemy = rand.Next(11,16);
                    EnemyNum--;
                    break;
                case 4:
                    _selectEnemy = rand.Next(11, 16);
                    EnemyNum--;
                    break;
            }
            _board.Map[_selectLocationEnemy, 6] = _selectEnemy;
        }

        public void AddHero()
        {

        
        }
        public void AddEnemy()
        {

        }
        //public void TrikEnemy()
        //{
        //    Notify(); // TODO: switch case write enemy picture !!!
        //}
        
    }
}
