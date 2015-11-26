﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDGame.Model
{
    public class Hero
    {
        private int _hp;
        private int _damage;
        private int _speed;
        private int _cost;
        private Image _image;

        public void InitHero()
        {
            Hp = 0;
            Damage = 0;
            Speed = 0;
            Cost = 0;
        }
        public void SetupHero(int hp, int damage, int speed, int cost , Image image)
        {
            Hp = hp;
            Damage = damage;
            Speed = speed;
            Cost = cost;
            _image = image;
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
                return this._damage;
            }
            set
            {
                if (this._damage != value)
                    this._damage = value;
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
        public int Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (this._cost != value)
                    this._cost = value;
            }
        }
    }
}