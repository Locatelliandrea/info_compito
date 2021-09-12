using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrWebCam.Demo
{
    class Gestione
    {
        private string nomeFile;
        public Gestione(string nomeFile) => this.nomeFile = nomeFile;
        public void scriviTutto(string stringa) => File.WriteAllText(nomeFile, stringa);
        public string leggiTutto() { return File.ReadAllText(nomeFile); }
        public bool aggiungi(ticket t)
        {
            
            bool esito = false;
            string temp = "";
            temp = t.toCSV();
            File.AppendAllText(nomeFile, temp);
            esito = true;
            return esito;
        }
        public List<ticket> leggi()
        {
            List<ticket> lista = new List<ticket>();
            using (StreamReader sr = File.OpenText(nomeFile))
            {
                string s = "";
                string[] s1 = new string[5];
                while ((s = sr.ReadLine()) != null)
                {
                    s1 = s.Split(';');
                    ticket b = new ticket(s1[0], s1[1], s1[2],s1[3], Convert.ToInt32(s1[4]), Convert.ToInt32(s1[5]));
                    lista.Add(b);

                }
            }
            return lista;
        }
        public bool isEmpty()
        {
            using (StreamReader sr = File.OpenText(nomeFile))
            {
                string s = "";
                if ((s = sr.ReadLine()) == null)
                    return true;
                else
                    return false;
            }
        }
    }
}
