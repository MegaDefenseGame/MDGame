using MDGame.Model;
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
        
        public bool _chkStart;
        public bool _heroClick = false;

        private Thread Timer = null;
        //private Thread enemyWalk = null;
        private bool _gameRunning = true;
        private int _cntTimeEnemyWalk = 0;
        private int _cntTimeEnemySpawn = 0;
        private int _cntTimeHeroShoot = 0;

        private int _enemyID = 600;
        private int _heroID = 100;

        private int _life = 3;
        private int _coin = 200;

        public Enemy[] _enemyList = new Enemy[1000];
        public Hero[] _heroList = new Hero[1000];

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
        public int Life
        {
            get
            {
                return this._life;
            }
            set
            {
                if (this._life != value)
                    this._life = value;
            }
        }
        public int Coin
        {
            get
            {
                return this._coin;
            }
            set
            {
                if (this._coin != value)
                    this._coin = value;
            }
        }

        public void InitGameStart()
        {
            _life = 3;
            EnemyNum = 100;
            _chkStart = true;

        }

        public void GameStart()
        {
            InitGameStart();
            //EnemySpawn();
            //Thread oThreadEnemySpawn = new Thread(new ThreadStart(this.TimeTrickerEnemySpawn));
            //oThreadEnemySpawn.Start();

            if (Timer == null)
                Timer = new Thread(new ThreadStart(this.CoreTimer));

            if (!Timer.IsAlive)
                Timer.Start();

            //if (enemyWalk == null)
            //    enemyWalk = new Thread(new ThreadStart(this.TimeTrickerForWalk));

            //if (!enemyWalk.IsAlive)
            //    enemyWalk.Start();
        }

        public void setGameRunning(bool flag)
        {
            _gameRunning = flag;
        }

        private static object _locker = new object();
        //public void TimeTrickerForWalk()
        //{
        //    lock (_locker)
        //    {
        //        while (_gameRunning)
        //        {
        //            foreach (var x in _enemyList)
        //            {
        //                if (x != null && _cntTime % x.Speed == 0 && _cntTime > 6)
        //                {
        //                    x.AtX--;
        //                    _board.Map[x.AtY, x.AtX] = x.ID;
        //                    _board.Map[x.AtY, x.AtX++] = 0;
        //                    NotifyMap();
        //                }

        //            }

        //            _cntTime++;
        //            Thread.Sleep(1000);
        //        }
        //    }

        //}
        private bool _enemyIsSpawn = false;
        private bool _heroIsSpawn = false;
        private bool _chkChange = false;
        public void CoreTimer() // TODO : WAVE complete system!!
        {
            while (true)
            {
                Thread.Sleep(1000);
                _cntTimeEnemySpawn++;
                CheckToDo();
                if (_chkChange)
                {
                    NotifyMap();
                    _chkChange = false;
                }
            }

            //if (_enemyIsSpawn && !_chkChange)
            //{
            //    TimeTrickerEnemyWalk();  
            //}
            //if (_heroIsSpawn && !_chkChange)
            //{
            //    TimeTrickerHeroShoot();
            //    _chkChange = true;
            //}

            //if (_chkChange)
            //{
            //    NotifyMap();
            //    _chkChange = false;
            //}            
        }


        public void CheckToDo()
        {
            lock (_locker)
            {
                if (!_chkTimeSpawn)
                    SuffleTimeSpawnEnemy();
                if (_cntTimeEnemySpawn % 6 == 0 || _cntTimeEnemySpawn % 8 == 0 || _cntTimeEnemySpawn % 10 == 0)
                    TimeTrickerEnemySpawn();
                if (_enemyIsSpawn /*&& !_chkChange*/)
                {
                    TimeTrickerEnemyWalk();
                }
                if (_heroIsSpawn /*&& !_chkChange*/ )
                {
                    TimeTrickerHeroShoot();
                    _chkChange = true;
                }
            }

        }

       
        public void TimeTrickerEnemySpawn()
        {
            if (_chkTimeSpawn)
            {
                switch (_timeSpawn)
                {
                    case 1:
                        if (_cntTimeEnemySpawn % 8 == 0)
                        {
                            EnemySpawn();
                            _chkChange = true;
                            _chkTimeSpawn = false;
                        }
                        break;
                    case 2:
                        if (_cntTimeEnemySpawn % 10 == 0)
                        {
                            EnemySpawn();
                            _chkChange = true;
                            _chkTimeSpawn = false;
                        }
                        break;
                    case 3:
                        if (_cntTimeEnemySpawn % 14 == 0)
                        {
                            EnemySpawn();
                            _chkChange = true;
                            _chkTimeSpawn = false;
                        }
                        break;
                }



            }
        
        }

        public void TimeTrickerEnemyWalk()
        {

            //while (/*_gameRunning*/ !_chkChange)
            //{
            _cntTimeEnemyWalk++;
            foreach (var x in _enemyList)
            {
                if (x != null && _cntTimeEnemyWalk % x.Speed == 0)
                {
                    if (x.AtX == 0)
                    {
                        Life--;
                        _board.Map[x.AtY, 0] = 0;
                        x.ID = 0;
                        x.AtX = 100; // Bug 
                        CheckingGameLose();
                    }
                    else
                    {
                        x.AtX--;
                        _board.Map[x.AtY, x.AtX] = x.ID;
                        _board.Map[x.AtY, x.AtX + 1] = 0;
                        //NotifyMap();
                    }
                }

            }
            _chkChange = true;
            //}

        }
        public void TimeTrickerHeroShoot()
        {

            //while (!_chkChange)
            //{
            _cntTimeHeroShoot++;
            foreach (var x in _heroList)
            {
                if (x != null && _cntTimeHeroShoot % x.Speed == 0)
                {
                    for (int i = x.AtX; i < 7; i++)
                    {
                        if (_board.Map[x.AtY, i] == 0) // TODO : Shooting
                        {
                            
                        }
                        if (_board.Map[x.AtY, i] != 0 && _board.Map[x.AtY, i] >= 600)
                        {

                            _enemyList[_board.Map[x.AtY, i]].Hp -= x.Damage;
                            CheckEnemyAlive(_board.Map[x.AtY, i], x.AtY, i);

                            break;
                        }

                    }
                }
                //}

            }
        }

        private bool _chkTimeSpawn = false;
        private int _timeSpawn;
        public void SuffleTimeSpawnEnemy()
        {
            if (!_chkTimeSpawn)
            {
                _timeSpawn = rand.Next(1, 4);
                _chkTimeSpawn = true;
            }
        }

        public void CheckingGameLose()
        {

        }
        public void SelectHeroPosition(int x, int y)
        {
            int heroIndex = y / 100; // +2 in board
            switch (heroIndex)
            {
                case 0:
                    _selectHero = GameBoard.HERO1;
                    if (Coin < 100) _heroClick = false; 
                    break;
                case 1:
                    _selectHero = GameBoard.HERO2;
                    if (Coin < 250) _heroClick = false;
                    break;
                case 2:
                    _selectHero = GameBoard.HERO3;
                    if (Coin < 400) _heroClick = false;
                    break;
                case 3:
                    _selectHero = GameBoard.HERO4;
                    if (Coin < 800) _heroClick = false;
                    break;
                case 4:
                    _selectHero = GameBoard.HERO5;
                    if (Coin < 1500) _heroClick = false;
                    break;
                case 5:
                    _selectHero = GameBoard.HERO6;
                    if (Coin < 3000) _heroClick = false;
                    break;
            }
        }

        public void SetView(IView view)
        {
            this._view = view;
        }

        int xMapIndex;
        int yMapIndex;
        public void MapPosition(int x, int y)
        {
            xMapIndex = x / 100;
            yMapIndex = y / 100;
            if (_heroClick)
            {
                switch(_selectHero)
                {
                    case GameBoard.HERO1:
                        Coin -= 100;
                        break;
                    case GameBoard.HERO2:
                        Coin -= 250;
                        break;
                    case GameBoard.HERO3:
                        Coin -= 400;
                        break;
                    case GameBoard.HERO4:
                        Coin -= 800;
                        break;
                    case GameBoard.HERO5:
                        Coin -= 1500;
                        break;
                    case GameBoard.HERO6:
                        Coin -= 3000;
                        break;
                }
                _board.Map[yMapIndex, xMapIndex] = _heroID; 
                AddHero();
                NotifyMap();
                _heroClick = false;
            }

        }

        public void NotifyMap()
        {
            lock (_locker)
            {
                if (_view != null)
                {
                    //int a[] = _board.Map.;
                    int[,] map = new int[6, 7];
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            map[i, j] = _board.Map[i, j];
                        }
                    }
                    _view.UpdateMap(map);
                }
            }
            
                
        }
        //public void NotifyShooting(int i, int j)
        //{

        //}
        //public void NotifyEnemy()
        //{
        //    if (_view != null)
        //        _view.UpdateEnemy(_board);
        //}

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
        //    int TimeSpawn;;
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
            if (_enemyNum <= 100 && _enemyNum >= 96)
            {
                _selectEnemy = GameBoard.ENEMY1;
            }
            else if (_enemyNum <= 96 && _enemyNum >= 80)
            {

            }
            switch (_enemyNum) //  TODO : AddEneny() not sure 
            {
                case 1:
                    if (_enemyNum == 8 || _enemyNum == 7)
                    {
                        _selectEnemy = GameBoard.ENEMY1;

                    }
                    else
                    {
                        _selectEnemy = rand.Next(GameBoard.ENEMY1, GameBoard.ENEMY7 + 1);

                    }
                    break;
                case 2:
                    _selectEnemy = rand.Next(GameBoard.ENEMY1, GameBoard.ENEMY7 + 1);
                    //EnemyNum--;
                    break;
                case 3:
                    _selectEnemy = rand.Next(GameBoard.ENEMY1, GameBoard.ENEMY7 + 1);
                    //EnemyNum--;
                    break;
                case 4:
                    _selectEnemy = rand.Next(GameBoard.ENEMY1, GameBoard.ENEMY7 + 1);
                    //EnemyNum--;
                    break;
            }
            _board.Map[_selectLocationEnemy, 6] = _enemyID; // TODO: Bug EnemySpawn Force Fixed!!  // LOOK : Update Location and Enemy here // TODO : Change _selectEnemy to _enemyID
            AddEnemy();
            EnemyNum--;
        }

        public int GetSelectEnemy(/*int i,*/int id)
        {
            //if (i == _selectLocationEnemy)
            return _enemyList[id].SelectEnemy;
            //else
            //    return 0;
        }
        public int GetSelectHero(int id)
        {
            return _heroList[id].SelectHero;
        }

        public void AddHero() // TODO : put value of speed hp and damage of Hero!!!
        {
            if (!_heroIsSpawn)
                _heroIsSpawn = true;
            //Hero oHero = new Hero();
            //oHero.ID = _heroID;
            //oHero.SelectHero = _selectHero;
            //_heroList[_heroID] = new Hero();
            //_heroList[_heroID] = oHero;
            //_heroID++;
            switch (_selectHero)
            {
                case GameBoard.HERO1:
                    _heroList[_heroID] = new Hero();
                    _heroList[_heroID].ID = _heroID;
                    _heroList[_heroID].SelectHero = _selectHero;
                    _heroList[_heroID].AtY = yMapIndex;
                    _heroList[_heroID].AtX = xMapIndex;
                    _heroList[_heroID].Cost = 100;
                    _heroList[_heroID].Speed = 2;
                    _heroList[_heroID].Damage = 1;
                    _heroID++;
                    break;
                case GameBoard.HERO2:
                    _heroList[_heroID] = new Hero();
                    _heroList[_heroID].ID = _heroID;
                    _heroList[_heroID].SelectHero = _selectHero;
                    _heroList[_heroID].AtY = yMapIndex;
                    _heroList[_heroID].AtX = xMapIndex;
                    _heroList[_heroID].Cost = 250;
                    _heroList[_heroID].Speed = 3;
                    _heroList[_heroID].Damage = 1;
                    _heroID++;
                    break;
                case GameBoard.HERO3:
                    _heroList[_heroID] = new Hero();
                    _heroList[_heroID].ID = _heroID;
                    _heroList[_heroID].SelectHero = _selectHero;
                    _heroList[_heroID].AtY = yMapIndex;
                    _heroList[_heroID].AtX = xMapIndex;
                    _heroList[_heroID].Cost = 400;
                    _heroList[_heroID].Speed = 3;
                    _heroList[_heroID].Damage = 2;
                    _heroID++;
                    break;
                case GameBoard.HERO4:
                    _heroList[_heroID] = new Hero();
                    _heroList[_heroID].ID = _heroID;
                    _heroList[_heroID].SelectHero = _selectHero;
                    _heroList[_heroID].AtY = yMapIndex;
                    _heroList[_heroID].AtX = xMapIndex;
                    _heroList[_heroID].Cost = 800;
                    _heroList[_heroID].Speed = 3;
                    _heroList[_heroID].Damage = 5;
                    _heroID++;
                    break;
                case GameBoard.HERO5:
                    _heroList[_heroID] = new Hero();
                    _heroList[_heroID].ID = _heroID;
                    _heroList[_heroID].SelectHero = _selectHero;
                    _heroList[_heroID].AtY = yMapIndex;
                    _heroList[_heroID].AtX = xMapIndex;
                    _heroList[_heroID].Cost = 1500;
                    _heroList[_heroID].Speed = 2;
                    _heroList[_heroID].Damage = 20;
                    _heroID++;
                    break;
                case GameBoard.HERO6:
                    _heroList[_heroID] = new Hero();
                    _heroList[_heroID].ID = _heroID;
                    _heroList[_heroID].SelectHero = _selectHero;
                    _heroList[_heroID].AtY = yMapIndex;
                    _heroList[_heroID].AtX = xMapIndex;
                    _heroList[_heroID].Cost = 5000;
                    _heroList[_heroID].Speed = 2;
                    _heroList[_heroID].Damage = 1000;
                    _heroID++;
                    break;
            }
        }
        public void AddEnemy()  // TODO : put value of speed hp and damage of Enemy!!!
        {
            if (!_enemyIsSpawn)
                _enemyIsSpawn = true;
            switch (_selectEnemy)
            {
                case GameBoard.ENEMY1:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 8;
                    _enemyList[_enemyID].Hp = 5;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++;
                    break;
                case GameBoard.ENEMY2:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 8;
                    _enemyList[_enemyID].Hp = 5;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++;
                    break;
                case GameBoard.ENEMY3:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 7;
                    _enemyList[_enemyID].Hp = 5;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++;
                    break;
                case GameBoard.ENEMY4:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 5;
                    _enemyList[_enemyID].Hp = 5;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++;
                    break;
                case GameBoard.ENEMY5:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 5;
                    _enemyList[_enemyID].Hp = 5;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++;
                    break;
                case GameBoard.ENEMY6:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 3;
                    _enemyList[_enemyID].Hp = 5;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++;
                    break;
                case GameBoard.ENEMY7:
                    _enemyList[_enemyID] = new Enemy();
                    _enemyList[_enemyID].ID = _enemyID;
                    _enemyList[_enemyID].SelectEnemy = _selectEnemy;
                    _enemyList[_enemyID].AtY = _selectLocationEnemy;
                    _enemyList[_enemyID].AtX = 6;
                    _enemyList[_enemyID].Speed = 1;
                    _enemyList[_enemyID].Hp = 30000;
                    _enemyList[_enemyID].CoinDrop = 50;
                    _enemyID++; ;
                    break;
            }
        }
        public void CheckEnemyAlive(int id , int i , int j)
        {
            if (_enemyList[id].Hp <= 0)
            {
                _board.Map[i, j] = 0;
                Coin += _enemyList[id].CoinDrop;
                _enemyList[id] = null;
                
            }
        }
        //public void TrikEnemy()
        //{
        //    Notify(); // TODO: switch case write enemy picture !!!
        //}

    }
}
