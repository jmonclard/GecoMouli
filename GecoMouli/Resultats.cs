using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GecoMouli
{
    class Resultats
    {
        int puce;
        string nom;
        string prenom;
        string nom_categorie_court;
        string nom_categorie_long;
        string num_club;
        string nom_club;
        string status;
        double temps_total=0;
        int nb_temps = 0;
        List<double> temps = new List<double>();
        List<string> puce_indice = new List<string>();
        bool qualifie = false;
        int classement=-1;
        string nouvelle_categorie="";
        string nouveau_circuit = "";
        int nouvelle_poule = 0;
        int start = 0;

        #region Properties

        public int Puce
        {
            get { return puce; }
        }

        public double TempsTotal
        {
            get { return temps_total; }
        }

        public string Indice
        {
            get { return puce_indice[puce_indice.Count - 1]; }
        }

        public string Categorie
        {
            get { return nom_categorie_court; }
        }

        public int NbCircuits
        {
            get { return nb_temps; }
        }

        public string Nom
        {
            get { return prenom + " " + nom; }
        }

        public bool Qualifie
        {
            get { return qualifie; }
            set { qualifie = value; }
        }

        public int Classement
        {
            get { return classement; }
            set { classement = value; }
        }

        public string NouvelleCategorie
        {
            get { return nouvelle_categorie; }
            set { nouvelle_categorie = value; }
        }

        public string NouveauCircuit
        {
            get { return nouveau_circuit; }
            set { nouveau_circuit = value; }
        }

        public int NouvellePoule
        {
            get { return nouvelle_poule; }
            set { nouvelle_poule = value; }
        }

        public int StartList
        {
            get { return start; }
            set { start = value; }
        }

        #endregion

        public void AddTemps(double t, string indice)
        {
            nb_temps++;
            temps.Add(t);
            temps_total += t;
            puce_indice.Add(indice);
        }

        public bool Parse(string ligne, double penalitePM)
        {
            bool ok = false;
            string[] colonnes = ligne.Split(new char[] { ';' });
            if (colonnes.GetLength(0) > 12)
            {
                string indice = "";
                string mot = colonnes[1];
                int i = mot.Length;
                while ((i > 0) && (!(char.IsNumber(mot, i - 1)))) i--;
                if ((i > 0) && (i != mot.Length))
                {
                    indice = mot.Substring(i, mot.Length - i);
                    mot = mot.Remove(i);
                }
                puce = int.Parse(mot);

                prenom = colonnes[4];
                nom = colonnes[3];
                nom_categorie_court = colonnes[5];
                nom_categorie_long = colonnes[6];
                num_club = colonnes[7];
                nom_club = colonnes[8];
                status = colonnes[11];

                string stemps = colonnes[12];
                double duree = System.TimeSpan.Parse(stemps).TotalSeconds;
                if (status != "OK") duree += penalitePM; //PM, abandons, etc...
                AddTemps(duree,indice);
   
                ok = true;
            }

            return ok;
        }

        private string ToHMS(double duree)
        {
            TimeSpan ts = new TimeSpan(0,0,(int)duree);
            return ts.ToString();
        }

        private string Formatte(string s, int taille)
        {
            string result;
            if (taille < s.Length)
            {
                result = s.Substring(0, taille);
            }
            else
            {
                result = s;
                while (result.Length < taille) result += " ";
            }
            return result;
        }

        
        public string ToStartListCSV()
        {
            string s = ";" + puce.ToString() + ";;" + nom + ";"+prenom+";;;;false;--:--;;Geco-course;"+
                        nouveau_circuit + ";;" + num_club + ";" +
                        nom_club+";;;"+NouvelleCategorie+";"+NouvelleCategorie+";";
            return s;
        }

        public string ToHTMLResultats()
        {
            string details_temps = "";
            foreach (double t in temps)
            {
                details_temps += "<td>&nbsp;" + ToHMS(t) + "&nbsp;</td>";
            }
            return "<td>" + classement.ToString()+ "</td>" +
                   "<td>" + Formatte(nom.ToUpper() + " " + prenom, 20) + "</td>" +
                   "<td>" + Formatte(num_club, 8) + "</td>" +
                   "<td>" + Formatte(nom_club, 15) + "</td>" +
                   "<td>" + Formatte(nom_categorie_court, 8) + "</td>" +
                   "<td>" + details_temps + "</td>" +
                   "<td>" + ToHMS(temps_total) + "</td>";
        }

    }

}
