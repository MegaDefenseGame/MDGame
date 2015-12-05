using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            //EnemySpawn();
            //Thread oThreadEnemySpawn = new Thread(new ThreadStart(this.TimeTrickerEnemySpawn));
            //oThreadEnemySpawn.Start();

            if (enemySpawnThread == null)
                enemySpawnThread = new Thread(new ThreadStart(this.TimeTrickerEnemySpawn));

            if (!enemySpawnThread.IsAlive)
                enemySpawnThread.Start();
        }

        Thread enemySpawnThread = null;

        bool _gameRunning = true;

        public void setGameRunning(bool flag)
        {
            _gameRunning = flag;
        }

        int _cntTime = 0;
        int _cntTimeEnemySpawn = 0;
        public void TimeTrickerForWalk()
        {
            while (_gameRunning)
            {
                //foreach (var x in EnenyList)
                //{
                //    if (_cntTime % x.walkSpeed == 0)
                //    {

                //    }
                   
                //}

                _cntTime++;
                Thread.Sleep(1000);
            }
        }

        public void TimeTrickerEnemySpawn()
        {
            int timeSpawn = rand.Next(1, 4);
            while (_gameRunning)
            {
                _cntTimeEnemySpawn++;
                Thread.Sleep(1000);
                
                
                switch (timeSpawn)
                {
                    case 1:
                        if (_cntTimeEnemySpawn % 6 == 0)
                        {
                            EnemySpawn();
                            NotifyEnemySpawn();
                            timeSpawn = rand.Next(1, 4);
                        }
                        break;
                    case 2:
                        if (_cntTimeEnemySpawn % 8 == 0)
                        {
                            EnemySpawn();
                            NotifyEnemySpawn();
                            timeSpawn = rand.Next(1, 4);
                        }
                        break;
                    case 3:
                        if (_cntTimeEnemySpawn % 10 == 0)
                        {
                            EnemySpawn();
                            NotifyEnemySpawn();
                            timeSpawn = rand.Next(1, 4);
                        }
                        break;
                }
            }
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
            //NotifyEnemySpawn();
            SuffleEnemyLocationSpawn();
            SuffleEnemy();
            //SuffleEnemyTimeSpawn();
        }
        //public void SuffleEnemyTimeSpawn() // LOOK : Test Threading Timer
        //{

        //    int time = 0;
        //    int TimeSpawn;
        //    TimeSpawn = rand.Next(1, 4);

        //    switch (TimeSpawn)
        //    {
        //        case 1:
        //            if (_cntTime % 6 == 0)
        //                NotifyEnemySpawn();
        //            break;
        //        case 2:
        //            if (_cntTime % 8 == 0)
        //                NotifyEnemySpawn();
        //            break;
        //        case 3:
        //            if (_cntTime % 10 == 0)
        //                NotifyEnemySpawn();
        //            break;
        //    }

        //    //int time = 0;
        //    //int TimeSpawn;
        //    //TimeSpawn = rand.Next(1, 3);
        //    //switch (TimeSpawn)
        //    //{
        //    //    case 1:
        //    //        time = 6000;
        //    //        break;
        //    //    case 2:
        //    //        time = 8000;
        //    //        break;
        //    //    case 3:
        //    //        time = 10000;
        //    //        break;
        //    //}
        //    //return time;
        //    NotifyEnemySpawn();
        //}
        public void SuffleEnemyLocationSpawn()
        {
            _selectLocationEnemy = rand.Next(1, 6);
        }
        public void SuffleEnemy() // TODO : Number of Enemy not finished yet !!!! don't forget to do it
        {
            switch (Wave) //  TODO : AddEneny() not sure 
            {
                case 1:
                    if (_enemyNum == 8 || _enemyNum == 7)
                    {
                        _selectEnemy = 11;
                        AddEnemy();
                    }
                    else
                    {
                        _selectEnemy = rand.Next(11, 16);
                        AddEnemy();
                    }
                    EnemyNum--;
                    break;
                case 2:
                    _selectEnemy = rand.Next(11, 16);
                    AddEnemy();
                    EnemyNum--;
                    break;
                case 3:
                    _selectEnemy = rand.Next(11,16);
                    AddEnemy();
                    EnemyNum--;
                    break;
                case 4:
                    _selectEnemy = rand.Next(11, 16);
                    AddEnemy();
                    EnemyNum--;
                    break;
            }
            _board.Map[_selectLocationEnemy, 6] = _selectEnemy;  // LOOK : Update Location and Enemy here
        }

        public void AddHero()
        {

        
        }
        public void AddEnemy()
        {
            switch (_selectEnemy)
            {
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;
            }
        }
        //public void TrikEnemy()
        //{
        //    Notify(); // TODO: switch case write enemy picture !!!
        //}
        
    }
}
