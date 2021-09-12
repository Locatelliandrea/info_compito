using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrWebCam.Demo
{
    public class ticket
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string settore { get; set; }
        public string artista { get; set; }
        public int posto { get; set; }
        public int prezzo { get; set; }
        public string toCSV()
        {
            return Nome + ";" + Cognome + ";" + artista + ";" + settore + ";" + posto.ToString() + ";" + prezzo.ToString()+ ";";
        } 

        public ticket()
        {
            Nome = "";
            Cognome = "";
            settore = "";
            artista = "";
            posto = 0;
            prezzo = 0;
        }
        public ticket(string N,string C,string P, string S, int po,int pr)
        {
            Nome = N;
            Cognome = C;
            artista = P;
            settore = S;           
            posto = po;
            prezzo = pr;
        }
    }
}
