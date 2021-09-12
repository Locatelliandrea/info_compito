using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrWebCam.Demo
{
    class Concerto
    {
        private Gestione g;

        public List<ticket> biglietti = new List<ticket>();
       

        public void setLista(ticket a)
        {
            biglietti.Add(a);

        }
        public Concerto()
        {
            g = new Gestione(@"C:\Users\locat\Desktop\Stadio\Memoria.txt");
        }
        public bool Controllo(ticket t)
        {
            bool temp = false;
            if (t.artista == "Tedua")
            {
                temp = ControlloPosto(t);
            }
            if (t.artista == "blanco")
            {
                temp = ControlloPosto(t);
            }
            if (t.artista == "il tre")
            {
                temp = ControlloPosto(t);
            }
            if (t.artista == "lazza")
            {
                temp = ControlloPosto(t);
            }

            return temp;
        }
        public bool ControlloPosto(ticket biglietto)
        {
            bool tmp = false;
            if (biglietti.Count == 0)
                return true;
            else
            {
                if (biglietto.settore == "Rosso" || biglietto.settore == "Blu")
                {
                    for (int i = 0; i < biglietti.Count; i++)
                        if (biglietto.posto != biglietti[i].posto && biglietto.posto < 40)
                        {
                            tmp = true;
                        }
                        else
                            tmp = false;
                }
                if (biglietto.settore == "Giallo" || biglietto.settore == "Verde")
                {
                    for (int i = 0; i < biglietti.Count; i++)
                        if (biglietto.posto != biglietti[i].posto && biglietto.posto < 50)
                        {
                            tmp = true;
                        }
                        else
                            tmp = false;
                }
                if (biglietto.settore == "Tribuna d'onore")
                {
                    for (int i = 0; i < biglietti.Count; i++)
                        if (biglietto.posto != biglietti[i].posto && biglietto.posto < 20)
                        {
                            tmp = true;
                        }

                        else
                            tmp = false;
                }
            }

            return tmp;
        }

        public void carica()
        {
            if (!g.isEmpty())
                biglietti = g.leggi();
        }
        public bool trovaBiglietto(ticket t)
        {

            for (int i = 0; i < biglietti.Count; i++)
            {
                if (t.Nome == biglietti[i].Nome && t.Cognome == biglietti[i].Cognome)
                    if (t.artista == biglietti[i].artista)
                        if (t.settore == biglietti[i].settore)
                            if (t.posto == biglietti[i].posto)
                            { 
                                return true;
                               
                            }
                                


            }
            return false;
        }
        public int calcolaIncasso()
        {
            int tot = 0;
            for (int i = 0; i < biglietti.Count; i++)
            {
                tot = tot + biglietti[i].prezzo;
            }
            return tot;
        }
    }
}
