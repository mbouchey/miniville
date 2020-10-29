using System;

namespace MiniVille
{

    class Card
    {
        private string _name;
        public string name {get {return _name;}}

        private string _color;
        public string color {get {return _color;}}

        private int _price;
        public int price {get {return _price;}}

        private int _earning_money;
        public int earning_money {get {return _earning_money;}}

        private int _activation_value;
        public int activation_value {get {return _activation_value;}}

        public Card(string name, string color, int price, int earning_money, int activation_value)
        {
            this._name = name;
            this._color = color;
            this._price = price;
            this._earning_money = earning_money;
            this._activation_value = activation_value;
        }

        public override string ToString()
        {
            return String.Format("name:{0}|color:{1}|price:{2}|earning_money:{3}|activation_value:{4}\n", this.name, this.color, this.price, this.earning_money, this.activation_value);

        }
    }
}
