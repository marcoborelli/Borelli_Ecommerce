using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_Ecommerce
{
    public class Carrello
    {
        private string _id;
        private const int MAX = 999;
        private Prodotto[] _prod = new Prodotto[MAX];

        public Carrello(string id)
        {
            this.Id = id;
            _prod = new Prodotto[MAX];
            Svuota();//inizializzo il vettore vuoto
        }

        public void Svuota()
        {
            for (int i = 0; i < _prod.Length; i++)
                _prod[i] = null;
        }

        public string VisualizzaProdotti(int ind)
        {
            if (_prod[ind] != null)
                return $"ID: {_prod[ind].Id}";
            else
                throw new Exception("Non è presente nessun valore a questo indice");
        }

        public Prodotto Rimuovi(Prodotto p)
        {
            if (Esiste(p) != -1)
            {
                for (int i = Esiste(p); i < _prod.Length - 1; i++)
                    _prod[i] = _prod[i + 1];

                _prod[_prod.Length - 1] = null;

                return p;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }

        public void Aggiungi(Prodotto p)
        {
            if (p != null)
            {
                _prod[getNumProdotti()] = p;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }

        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("Inserire un id correggiuto");
            }
        }

        public Prodotto[] Prod
        {
            get
            {
                return _prod;
            }
        }

        private int getNumProdotti()
        {
            int i = 0;
            while (i < _prod.Length && _prod[i] != null)
            {
                i++;
            }

            if (i != _prod.Length)
                return i;
            else
                throw new Exception("Il carrello è pieno");
        }

        private int Esiste(Prodotto q)
        {
            for (int i = 0; i < _prod.Length; i++)
            {
                if (_prod[i].Id == q.Id)
                    return i;
            }
            return -1;
        }

    }
}
