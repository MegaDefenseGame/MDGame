﻿using System;
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
        private string _imagePath;

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
    }
}
