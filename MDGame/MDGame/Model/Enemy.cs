using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDGame
{
    public class Enemy
    {
        private int _hp;
        private int _damange;
        private int _speed;
        private int _id = 0;
        private int _selectEnemy;
        private string _imagePath;
        private int _atX;
        private int _atY;

        public void InitEnemy()
        {
            Hp = 0;
            Damage = 0;
            Speed = 0;
            _imagePath = "";
        }
        public void SetupEnemy(int hp , int damage , int speed , string imagePath)
        {
            Hp = hp;
            Damage = damage;
            Speed = speed;
            _imagePath = imagePath;
        }

        public int Hp
        {
            get
            {
                return this._hp;
            }
            set
            {
                if (this._hp != value)
                    this._hp = value;
            }
        }
        public int Damage
        {
            get
            {
                return this._damange;
            }
            set
            {
                if (this._damange != value)
                    this._damange = value;
            }
        }
        public int Speed
        {
            get
            {
                return this._speed;
            }
            set
            {
                if (this._speed != value)
                    this._speed = value;
            }
        }
        public int AtX
        {
            get
            {
                return this. _atX;
            }
            set
            {
                if (this._atX != value)
                    this._atX = value;
            }
        }
        public int AtY
        {
            get
            {
                return this._atY;
            }
            set
            {
                if (this._atY != value)
                    this._atY = value;
            }
        }
        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if (this._id != value)
                    this._id = value;
            }
        }
        public int SelectEnemy
        {
            get
            {
                return this._selectEnemy;
            }
            set
            {
                if (this._selectEnemy != value)
                    this._selectEnemy = value;
            }
        }
        
        //public void setID(Enemy enemy, int id)
        //{
        //    enemy._id = id;
        //}
    }
}
