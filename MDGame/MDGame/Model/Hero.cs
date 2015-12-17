using System;
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
        private int _selectHero;
        private int _atX;
        private int _atY;
        private int _id;
        private int _timer = 0;
        private Image _image;
        private int _price;

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
        public int AtX
        {
            get
            {
                return this._atX;
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
        public int SelectHero
        {
            get
            {
                return this._selectHero;
            }
            set
            {
                if (this._selectHero != value)
                    this._selectHero = value;
            }
        }
        public int Timer
        {
            get
            {
                return this._timer;
            }
            set
            {
                if (this._timer != value)
                    this._timer = value;
            }
        }
        public int Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (this._price != value)
                    this._price = value;
            }
        }
    }
}
