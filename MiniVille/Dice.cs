using System;

namespace MiniVille
{

    class Dice
    {
        public int NbFaces;
        public Random random = new Random();
        public int face;

        public Dice(): this(6)
        {
            //NbFaces = 6;
        }

        public Dice(int NbFaces)
        {
            this.NbFaces = NbFaces;
        }

        public virtual void Lancer()
        {
            int rdm = random.Next(1, NbFaces + 1);
            face = rdm;
        }
    }
}
