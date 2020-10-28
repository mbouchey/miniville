﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiniVille
{
    public struct CardsInfo
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public int Dice { get; set; }
        public int Gain { get; set; }
    }
}
