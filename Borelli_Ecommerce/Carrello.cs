﻿using System;
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
        private Prodotto[] _prod;
        private int[] _qta;

        public Carrello(string id)
        {
            this.Id = id;
            _prod = new Prodotto[MAX];
            _qta = new int[MAX];
            Svuota();//inizializzo il vettore vuoto
        }

        public void Svuota()
        {
            for (int i = 0; i < _prod.Length; i++)
            {
                _prod[i] = null;
                _qta[i] = 0;
            }
        }

        public int VisualizzaQtaProdotti(int ind)
        {
            if (_qta[ind] != 0)
                return _qta[ind];
            else
                throw new Exception("Non è presente nessun valore a questo indice");
        }

        public Prodotto Rimuovi(Prodotto p)
        {
            int ind1 = Esiste(p);
            if (ind1 != -1)
            {
                for (int i = ind1; i < _prod.Length - 1; i++)
                {
                    _prod[i] = _prod[i + 1];
                    _qta[i] = _qta[i + 1];
                }

                _prod[_prod.Length - 1] = null;
                _qta[_qta.Length - 1] = 0;

                return p;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }

        public void Aggiungi(Prodotto p)
        {
            if (p != null)
            {
                int ind1 = Esiste(p);
                if (ind1 != -1 && (p.Nome == _prod[ind1].Nome && p.Produttore == _prod[ind1].Produttore && p.Descrizione == _prod[ind1].Descrizione && p.Prezzo == _prod[ind1].Prezzo))
                    _qta[ind1]++;
                else if (ind1 != -1 && (p.Nome != _prod[ind1].Nome || p.Produttore != _prod[ind1].Produttore || p.Descrizione != _prod[ind1].Descrizione || p.Prezzo != _prod[ind1].Prezzo))
                    throw new Exception("Non si possono metere due id uguali ma prodotti con caratteristiche diverse");
                else
                {
                    int ind = getNumProdotti();
                    _prod[ind] = p;
                    _qta[ind] = 1;
                }

            }
            else
                throw new Exception("Inserire un prodotto valido");
        }

        public int[] Qta
        {
            get
            {
                return _qta;
            }
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
                if (_prod[i] != null && _prod[i].Id == q.Id)
                    return i;
            }
            return -1;
        }

    }
}
