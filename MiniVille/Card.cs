﻿using System;

namespace MiniVille
{

    class Card
    {
        private int _price;
        public int price {get {return _price;}}

        private int _earning_money;
        public int earning_money {get {return _earning_money;}}

        private string _name;
        public string name {get {return _name;}}

        private int _activation_value;
        public int activation_value {get {return _activation_value;}}

        public Card(CardsInfo cardInfo)
        {
            this._name = cardInfo.Name;
            this._price = cardInfo.Cost;
            this._earning_money = cardInfo.Gain;
            this._activation_value = cardInfo.Dice;
        }

        public override string ToString()
        {
            return String.Format("name:{0}|price:{1}|earning_money:{2}|activation_value:{3}\n", this.name, this.price, this.earning_money, this.activation_value);

        }
    }
}
