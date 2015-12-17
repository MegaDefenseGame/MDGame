using MDGame.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDGame
{
    public partial class Form1 : Form, IView
    {
        private GameController _controller = new GameController();
        private const int LENGHT = 6;
        private const int WIDTH = 7;
        private PictureBox[,] _pbMap;
        private PictureBox[] _pbHS;
        private Image _floor;
        private Image _wall;
        private Image[] _heroImage;
        private Image[] _heroFightImage;
        private Image[] _enemyImage;
       
        

        public Form1()
        {
            InitializeComponent();
            this._pbMap = new PictureBox[6, 7];
            this._pbHS = new PictureBox[6];
            this._heroImage = new Image[6];
            this._heroFightImage = new Image[6];
            this._enemyImage = new Image[7];
            this._controller.SetView(this);
            InitMapLocation();
            InitImage();
            InitMap();
            InitHeroSelectorLocation();
            InitHeros();

        }

        public void InitMapLocation()
        {
            this.Map.Controls.Clear();

            for (int i = 0; i < LENGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    _pbMap[i, j] = new PictureBox();
                    _pbMap[i, j].Width = 100;
                    _pbMap[i, j].Height = 100;
                    _pbMap[i, j].Top = i * 100;
                    _pbMap[i, j].Left = j * 100;
                    _pbMap[i, j].Visible = true;

                    this.Map.Controls.Add(_pbMap[i, j]);

                    if (i != 0)
                        _pbMap[i, j].MouseClick += Map_MouseClick;
                }
            }
        }
        public void InitHeroSelectorLocation()
        {
            this.HeroSelector.Controls.Clear();
            for (int i = 0; i < LENGHT; i++)
            {
                _pbHS[i] = new PictureBox();
                _pbHS[i].Height = 100;
                _pbHS[i].Top = i * 100;
                _pbHS[i].Visible = true;

                this.HeroSelector.Controls.Add(_pbHS[i]);
            }
        }
        public void InitImage()
        {
            _floor = Properties.Resources.grass_resize;
            _wall = Properties.Resources.wall_resize;
            _heroImage[0] = Properties.Resources.CSHero1;
            _heroImage[1] = Properties.Resources.CSHero2;
            _heroImage[2] = Properties.Resources.CSHero4;
            _heroImage[3] = Properties.Resources.CSNaruto;
            _heroImage[4] = Properties.Resources.CSKing;
            _heroImage[5] = Properties.Resources.CSSpecialHero;
            _heroFightImage[0] = Properties.Resources.hero1;
            _heroFightImage[1] = Properties.Resources.hero2;
            _heroFightImage[2] = Properties.Resources.hero3;
            _heroFightImage[3] = Properties.Resources.hero5;
            _heroFightImage[4] = Properties.Resources.hero4;
            _heroFightImage[5] = Properties.Resources.SpecialHero;
            _enemyImage[0] = Properties.Resources.enemy1;
            _enemyImage[1] = Properties.Resources.enemy2;
            _enemyImage[2] = Properties.Resources.enemy3;
            _enemyImage[3] = Properties.Resources.enemy4;
            _enemyImage[4] = Properties.Resources.enemy5;
            _enemyImage[5] = Properties.Resources.enemy6;
            _enemyImage[6] = Properties.Resources.enemy_boss;
        }
        public void InitMap()
        {

            for (int i = 0; i < LENGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    int[,] map = _controller.GetMaps(1);
                    switch (map[i, j])
                    {
                        case GameBoard.FLOOR:
                            _pbMap[i, j].BackgroundImage = _floor;
                            break;
                        case GameBoard.WALL:
                            _pbMap[i, j].BackgroundImage = _wall;
                            break;
                    }

                }
            }
            this.Map.Refresh();
        }

        public void InitHeros()
        {
            for (int i = 0; i < LENGHT; i++)
            {
                _pbHS[i].Image = _heroImage[i];
                _pbHS[i].MouseClick += HeroSelector_MouseClick;

            }

        }

        private void HeroSelector_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox x = sender as PictureBox;
            //MessageBox.Show(x.Location.X + "  " +x.Location.Y);
            _controller._heroClick = true;
            _controller.SelectHeroPosition(0, x.Location.Y);
            //x.BackColor = 
            //if ()
            
        }
        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox x = sender as PictureBox;
            string eiei = Convert.ToString(_controller.Coin);
            //CoinsValue.Text = eiei; TODO : Faster
            //MessageBox.Show(x.Location.X + "  " + x.Location.Y);
            _controller.MapPosition(x.Location.X, x.Location.Y);

        }
        
        private static object _locker = new object();
        public void UpdateMap(int[,] mapx)
        {
            lock (_locker)
            { 
                try
                {
                    for (int i = 1; i < LENGHT; i++)
                    {
                        for (int j = 0; j < WIDTH; j++)
                        {
                            int[,] map = mapx;//baord.Map;//_controller.GetMaps(1);
                            _pbMap[i, j].Image = null;

                            int chkType = map[i, j];
                            if (chkType > 99 && chkType < 600)
                            {
                                switch (_controller.GetSelectHero(map[i, j]))
                                {
                                    //case GameBoard.FLOOR:
                                    //    _pbMap[i, j].Image = _floor;
                                    //    break;
                                    //case GameBoard.WALL:
                                    //    _pbMap[i, j].Image = _wall;
                                    //    break;
                                    case GameBoard.HERO1:
                                        _pbMap[i, j].Image = _heroFightImage[0];
                                        break;
                                    case GameBoard.HERO2:
                                        _pbMap[i, j].Image = _heroFightImage[1];
                                        break;
                                    case GameBoard.HERO3:
                                        _pbMap[i, j].Image = _heroFightImage[2];
                                        break;
                                    case GameBoard.HERO4:
                                        _pbMap[i, j].Image = _heroFightImage[3];
                                        break;
                                    case GameBoard.HERO5:
                                        _pbMap[i, j].Image = _heroFightImage[4];
                                        break;
                                    case GameBoard.HERO6:
                                        _pbMap[i, j].Image = _heroFightImage[5];
                                        break;


                                }
                            }
                            else if (chkType >= 600)
                            {
                                switch (_controller.GetSelectEnemy(map[i, j]))
                                {
                                    case GameBoard.ENEMY1:
                                        _pbMap[i, j].Image = _enemyImage[0];
                                        break;
                                    case GameBoard.ENEMY2:
                                        _pbMap[i, j].Image = _enemyImage[1];
                                        break;
                                    case GameBoard.ENEMY3:
                                        _pbMap[i, j].Image = _enemyImage[2];
                                        break;
                                    case GameBoard.ENEMY4:
                                        _pbMap[i, j].Image = _enemyImage[3];
                                        break;
                                    case GameBoard.ENEMY5:
                                        _pbMap[i, j].Image = _enemyImage[4];
                                        break;
                                    case GameBoard.ENEMY6:
                                        _pbMap[i, j].Image = _enemyImage[5];
                                        break;
                                    case GameBoard.ENEMY7:
                                        _pbMap[i, j].Image = _enemyImage[6];
                                        break;
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
               
            }
            string eiei = Convert.ToString(_controller.EnemyNum);
            //EnemyNum.Text = "" + _controller.EnemyNum;            // TODO : Faster
            //this.Map.Refresh();
        }
        //public void UpdateEnemy(GameBoard board)
        //{
        //    for (int i = 1; i < LENGHT; i++)
        //    {
        //        for (int j = 0; j < WIDTH; j++)
        //        {

               
        //        int[,] map = _controller.GetMaps(1);
        //        _pbMap[i, j].Image = null;
        //        int chkEnemyID = map[i, j];
        //        if (chkEnemyID > 10)
        //        {
        //                //#if DEBUG
        //                //                    MessageBox.Show(string.Format("Monster spawn {0} \n" +
        //                //                                          "Select enemy {1} \n" +
        //                //                                          "ID : {2}", _controller._selectLocationEnemy, _controller._selectEnemy, map[i, 6]));
        //                //#endif
        //                switch (_controller.GetSelectEnemy(map[i, j]) /*_controller._enemyList[map[i, 6]]*/ ) // TODO : mao num
        //                {

        //                    case GameBoard.ENEMY1:
        //                        _pbMap[i, j].Image = _enemyImage[0];
        //                        break;
        //                    case GameBoard.ENEMY2:
        //                        _pbMap[i, j].Image = _enemyImage[1];
        //                        break;
        //                    case GameBoard.ENEMY3:
        //                        _pbMap[i, j].Image = _enemyImage[2];
        //                        break;
        //                    case GameBoard.ENEMY4:
        //                        _pbMap[i, j].Image = _enemyImage[3];
        //                        break;
        //                    case GameBoard.ENEMY5:
        //                        _pbMap[i, j].Image = _enemyImage[4];
        //                        break;
        //                    case GameBoard.ENEMY6:
        //                        _pbMap[i, j].Image = _enemyImage[5];
        //                        break;
        //                    case GameBoard.ENEMY7:
        //                        _pbMap[i, j].Image = _enemyImage[6];
        //                        break;
        //                }
        //            }
        //        }
        //    }

        //    //this.Map.Refresh();
        //}
        //public void UpdateEnemy(GameBoard board)
        //{

        //}

        private void StartButton_Click(object sender, EventArgs e)
        {
            _controller.GameStart();
            //_controller.EnemySpawn();
            // Testing Threading Timer
            //TimeEnemySpawn.Interval = _controller.SuffleEnemyTimeSpawn(); 

            //TimeEnemySpawn.Enabled = true;
            //TimeEnemySpawn.Start();
        }

        private void TimeEnemySpawn_Tick(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show(string.Format("Monster spawn {0} \n" +
                                          "Select enemy {1} \n" +
                                          "Time {2}", _controller._selectLocationEnemy, _controller._selectEnemy, TimeEnemySpawn.Interval));
#endif
            //TimeEnemySpawn.Dispose();
            _controller.EnemySpawn();

            //Testing Threading Timer
            //TimeEnemySpawn.Interval = _controller.SuffleEnemyTimeSpawn();

        }

        private void Shooting()
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
