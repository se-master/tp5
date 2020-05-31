using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace tp5
{
    public class Noeud : IHybridCopyable<Noeud>
    {
        public string Étiquette { get; private set; }
        public Vector2f Position { get; private set; }
        public int NbAdjacents { get; private set; }
        private List<Noeud> Adjacents { get; set; }

        // Constructeur paramètrique
        public Noeud(string étiquette, Vector2f position, int nbAdjacents)
        {
            Étiquette = étiquette;
            Position = position;
            NbAdjacents = nbAdjacents;
            Adjacents = new List<Noeud>(nbAdjacents);
        }
        public Noeud HybridCopy()
        {
            return new Noeud(this);
        }
        private Noeud(Noeud noeud)
        {
            Étiquette = noeud.Étiquette;
            Position = noeud.Position;
            NbAdjacents = noeud.NbAdjacents;
            Adjacents = noeud.Adjacents;
        }

        public void AjouterAdjacent(Noeud adjacent)
        {
            this.NbAdjacents += 1;
            adjacent.NbAdjacents += 1;
            this.Adjacents.Add(adjacent);
            adjacent.Adjacents.Add(this);
        }
        public float CalculerDistanceAdjacents(int pos)
        {
            if (pos < 0){throw new ArgumentOutOfRangeException();}
            float x1 = this.Position.X;
            float x2 = Adjacents[pos].Position.X;
            float y1 = this.Position.Y;
            float y2 = Adjacents[pos].Position.Y;
            float x = (x2 - x1);
            float y = (y2 - y1);
            return (float) Math.Sqrt(x*x + y*y);
        }
        public Noeud[] CopierAdjacents()
        {
            int capacité = this.Adjacents.Count;
            Noeud[] tableau = new Noeud[capacité];
            for (int n = 0; n < capacité; ++n)
                tableau[n] = this.Adjacents[n].HybridCopy();
            return tableau;
        }
        public string GénérerTexte()
        {
            int capacité = this.Adjacents.Count;
            StringBuilder sb = new StringBuilder(this.Adjacents.Count);
            string m;
            for (int n = 0; n < capacité; ++n)
            {
                m +=this.Adjacents[n].Étiquette;
            }

            sb.ToString();

            return $"{Étiquette} @ ({Position.X}, {Position.Y})\n--Adjacents--\n sb.ToString() \n";
        }


    }
}
