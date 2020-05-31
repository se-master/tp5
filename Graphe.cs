using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp5
{
    public class Graphe : IDeepCopyable<Graphe>
    {
        private List<Noeud> Noeuds { get; set; }
        public Graphe()
        {
            Noeuds = new List<Noeud>();
        }
        private Graphe(Graphe graphe)
        {
            List<Noeud> liste = graphe.Noeuds;
            int n = liste.Count;
            Noeuds = new List<Noeud>(n);
            for (int i = 0; i < n; i++)
                Noeuds.Add(liste[i]);
        }

        public Graphe DeepCopy()
        {
            return new Graphe(this);
        }
        public void AjouterNoeud(Noeud noeudÀAjouter)
        {

            foreach (Noeud noeud in Noeuds)
            {
                if (noeudÀAjouter == noeud)
                {
                    return;
                }
                Noeuds.Add(noeudÀAjouter);
            }

        }

        public int CalculerNbChemins()
        {
            //int n = 0;
            //int chemins=0;
            //chemins = Noeuds[n].NbAdjacents
            return Noeuds.Count;
        }
        public Noeud[] CopierNoeuds()
        {
            int capacité = Noeuds.Count;
            Noeud[] Tableau = new Noeud[capacité];
            for (int n = 0; n < capacité; ++n)
            {
                Tableau[n] = Noeuds[n].HybridCopy();
            }
            return Tableau;
        }
    }
}
