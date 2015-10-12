using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GecoMouli
{
    public partial class FormGecoMouli : Form
    {
        Stream myStream;
        int prevIndex = 0;
        int prevIndexNvlle = 0;
        string[] fichierGeco;
        Random Rnd = new Random();

        ListeCategories liste = new ListeCategories();
        Dictionary<int, Resultats> table = new Dictionary<int, Resultats>();
        Dictionary<int, Resultats> table_qualifies = new Dictionary<int, Resultats>();
        Dictionary<int, Resultats> table_nonqualifies = new Dictionary<int, Resultats>();


        public FormGecoMouli()
        {
            InitializeComponent();
        }

        private void ExtractRootCateg(string s, out string categ, out int n)
        {
            int i = s.Length;
            while ((i > 0) && (char.IsNumber(s, i - 1))) i--;
            if (i > 0)
            {
                if (i != s.Length)
                {
                    categ = s.Substring(0, i);
                    n = int.Parse(s.Substring(i));
                }
                else
                {
                    categ = s;
                    n = 0;
                }
            }
            else
            {
                categ = "";
                n = int.Parse(s.Substring(i));
            }
        }

        private int NbQualifiesParPoule(int concurrents)
        {
            int qualifies=concurrents;
            if (concurrents > 15)
            {
                qualifies = 15;
            }
            else if (concurrents == 15)
            {
                qualifies = 5;
            }
            else if (concurrents > 10)
            {
                qualifies = 10;
            }
            else if (concurrents == 10)
            {
                qualifies = 4;
            }
            else if (concurrents > 5)
            {
                qualifies = 5;
            }

            return qualifies;
        }


        private void CreationTableauPrec()
        {
            var listeCateg = from kpo in table
                             group kpo by kpo.Value.Categorie into groupeParCategorie
                             select new { Categ = groupeParCategorie.Key, Data = groupeParCategorie };

            foreach (var p in listeCateg)
            {
                ListViewItem item = new ListViewItem();
                item.Text = p.Categ;

                int max_circuits = 0;
                int nb_concurrents = 0;
                foreach (var pe in p.Data)
                {
                    nb_concurrents++;
                    if (pe.Value.NbCircuits > max_circuits) max_circuits = pe.Value.NbCircuits;
                }

                string categ;
                int n;
                ExtractRootCateg(p.Categ, out categ, out n);

                // recherche si le groupe existe
                ListViewGroup index_trouve = null;
                foreach (ListViewGroup g in listViewPrec.Groups)
                {
                    if (g.Header == categ)
                    {
                        index_trouve = g;
                    }
                }
                if (index_trouve != null) //trouve
                {
                    item.Group = index_trouve;
                }
                else // on cree un nouveau groupe
                {
                    ListViewGroup lvg = new ListViewGroup();
                    lvg.Name = categ;
                    lvg.Header = categ;
                    listViewPrec.Groups.Add(lvg);
                    item.Group = lvg;

                }
                item.SubItems.Add(nb_concurrents.ToString());
                item.SubItems.Add(max_circuits.ToString());
                item.SubItems.Add(textBoxPrefixe.Text+categ + textBoxSuffixe.Text);

                listViewPrec.Items.Add(item);
            }

        }

        private int CalculTotalQualifies(int concurrents, int qualifies_par_poule, int poules)
        {
            int total_qualifies = qualifies_par_poule * poules;
            if (total_qualifies > concurrents) total_qualifies = concurrents;
            return total_qualifies;
        }

        private void MAJTotalQualifies(ListViewItem lig)
        {
            int concurrents = int.Parse(lig.SubItems[1].Text);
            int poules = int.Parse(lig.SubItems[2].Text);
            int qualifies_par_poule = int.Parse(lig.SubItems[3].Text);

            int total_qualifies = qualifies_par_poule * poules;
            if (total_qualifies > concurrents) total_qualifies = concurrents;
            lig.SubItems[4].Text = total_qualifies.ToString();
        }


        public void CreationTableauNouv()
        {

            // mise à jour table nouvelles categ
            foreach (ListViewGroup g in listViewPrec.Groups)
            {

                // Détermination du nombre de poules dans les catégories d'origine
                int poules = g.Items.Count;

                // Détermination du nombre de concurrents dans la catégorie
                int concurrents = 0;
                foreach (ListViewItem lig in g.Items)
                {
                    concurrents += int.Parse(lig.SubItems[1].Text);
                }

                int qualifies = NbQualifiesParPoule(concurrents);
                int total_qualifies = CalculTotalQualifies(concurrents, qualifies, poules);

                // Remplissage d'une ligne du tableau
                ListViewItem nouv_item = new ListViewItem();
                
                if (checkBoxConserverCateg.Checked)
                    nouv_item.Text = textBoxPrefixe.Text+g.Header + textBoxSuffixe.Text;    // Catégories
                else
                    nouv_item.Text = textBoxPrefixe.Text +textBoxSuffixe.Text;    // Catégories
                
                nouv_item.SubItems.Add(concurrents.ToString());                         // Qualifiables
                nouv_item.SubItems.Add(poules.ToString());                              // Nb poules
                nouv_item.SubItems.Add(qualifies.ToString());                           // Qualifies par poules
                nouv_item.SubItems.Add(total_qualifies.ToString());                     // Nb total de qualifies

                if (checkBoxConserverCircuit.Checked)
                    nouv_item.SubItems.Add(textBoxPrefixeCircuit.Text + g.Header + textBoxSuffixeCircuit.Text);  // Circuit
                else
                    nouv_item.SubItems.Add(textBoxPrefixeCircuit.Text + textBoxSuffixeCircuit.Text);  // Circuit
                
                listViewNouvelle.Items.Add(nouv_item);

                // On en profite pour indiquer dans le tableau précédent le nombre de concurrents
                g.Header += " (" + concurrents.ToString() + ")";

                // Mise à jour de la comboBox de choix de la catégorie au-dessous du tableau prec
                comboBoxGroupeQualif.Items.Add(nouv_item.Text);

            }
        }

        private void VerifCoherenceTableauNouv()
        {
            // parcours de chaque ligne du tableau nouveau
            foreach (ListViewItem lig_nouv in listViewNouvelle.Items)
            {
                int total_poules = 0;
                int qualifiables = 0;
                // Recherche des poules (lignes) dans le tableau precédent utilisant cette nouvelle catégorie
                foreach (ListViewItem lig_prec in listViewPrec.Items)
                {
                    if (lig_prec.SubItems[3].Text == lig_nouv.SubItems[0].Text)
                    {
                        total_poules++;
                        qualifiables += int.Parse(lig_prec.SubItems[1].Text);
                    }
                }
                // Vérification que le nb total de qualifie pour cette ligne du nouveau tableau est
                // congrue à 0 modulo le nombre de lignes du tableau précédent utiliséant cette nouvelle catégorie
                lig_nouv.SubItems[1].Text = qualifiables.ToString();
                MAJTotalQualifies(lig_nouv);
                int total_qualifies = int.Parse(lig_nouv.SubItems[4].Text);

                if (radioButtonPoules.Checked) 
                {
                    // on doit avoir le même nombre de poules si on doit les conserver
                    if (total_poules == int.Parse(lig_nouv.SubItems[2].Text))
                    {
                        lig_nouv.ForeColor = Color.Black;
                    }
                    else
                    {
                        lig_nouv.ForeColor = Color.Red;
                    }
                }
                else // permutation, niveau ou alea
                {

                    if (total_qualifies < qualifiables) // une sélection s'opère
                    {
                        if (total_qualifies % total_poules == 0)
                        {
                            // le total_qualifie est un multiple de l'ancien nombre de poules => OK
                            lig_nouv.ForeColor = Color.Black;
                        }
                        else
                        {
                            lig_nouv.ForeColor = Color.Red;
                        }
                    }
                    else // tout le monde est qualifié ! => OK
                    {
                        lig_nouv.ForeColor = Color.Black;
                    }
                }
            }
        }
        
        
        public void CalculClassement()
        {

            var listeCateg = from kpo in table
                             group kpo by kpo.Value.Categorie into groupeParCategorie
                             select new { Categ = groupeParCategorie.Key, Data = groupeParCategorie };

            double temps_prec = -1.0;
            int rang_prec = 0;

            foreach (var p in listeCateg)
            {
                int rang = 0;
                var classement = from kp in table
                                 where kp.Value.Categorie == p.Categ
                                 orderby kp.Value.TempsTotal
                                 select kp.Value;
                foreach (var concurrent in classement)
                {
                    rang++;
                    if (concurrent.TempsTotal == temps_prec) // ex aequo
                    {
                        table[concurrent.Puce].Classement = rang_prec;
                    }
                    else
                    {
                        table[concurrent.Puce].Classement = rang;
                    }
                    temps_prec = concurrent.TempsTotal;
                    rang_prec = table[concurrent.Puce].Classement;
                }
            }
        }


        public void DetermineQualifications()
        {

            var listeCateg = from kpo in table
                             group kpo by kpo.Value.Categorie into groupeParCategorie
                             select new { Categ = groupeParCategorie.Key, Data = groupeParCategorie };

            foreach (var p in listeCateg)       // par exemple F1
            {
                // determination du nombre à qualifier
                int nb_a_qualifier = 0;
                string nouv_categ="";
                string nouv_circuit = "";
                foreach (ListViewItem lig_nouv in listViewNouvelle.Items)
                {

                    foreach (ListViewItem lig_prec in listViewPrec.Items)
                    {
                        if ((lig_nouv.SubItems[0].Text==lig_prec.SubItems[3].Text)&&(lig_prec.SubItems[0].Text == p.Categ))
                        {
                            nouv_categ = lig_nouv.SubItems[0].Text;
                            nouv_circuit = lig_nouv.SubItems[5].Text;
                            nb_a_qualifier = int.Parse(lig_nouv.SubItems[3].Text);
                        }
                    }
                }

                var classement = from kp in table
                                 where kp.Value.Categorie == p.Categ
                                 orderby kp.Value.TempsTotal
                                 select kp.Value;
                foreach (var concurrent in classement)
                {
                    table[concurrent.Puce].Qualifie = (concurrent.Classement <= nb_a_qualifier);
                    concurrent.NouvelleCategorie = nouv_categ;
                    concurrent.NouveauCircuit = nouv_circuit;
                }
            }


            foreach (ListViewItem lig_nouv in listViewNouvelle.Items)
            {
                // creation de la table de hachage
                int nb_concurrents = int.Parse(lig_nouv.SubItems[1].Text);
                int nb_qualifies = int.Parse(lig_nouv.SubItems[4].Text);
                int nb_poules = int.Parse(lig_nouv.SubItems[2].Text);
                int[] hachage = new int[nb_concurrents];


                if (nb_qualifies > 0)
                {
                    if (radioButtonAlea.Checked) // affectation aleatoire
                    {
                        // on remplie avec une succession de nombre compris entre 0 et nb_poules-1
                        for (int i = 0; i < nb_qualifies; i++)
                        {
                            hachage[i] = i % nb_poules;
                        }
                        // echanges aleatoires parmis les qualifies
                        for (int i = 0; i < 1000; i++)
                        {
                            int c1 = Rnd.Next(nb_qualifies);
                            int c2 = Rnd.Next(nb_qualifies);
                            int tmp =hachage[c2];
                            hachage[c2] = hachage[c1];
                            hachage[c1] = tmp;
                        }
                    }
                    else if(radioButtonNiveau.Checked) // par niveau
                    {
                        int nb_par_poule = nb_qualifies / nb_poules; // nombre min par poules

                        for (int i = 0; i < nb_par_poule * nb_poules; i++)
                        {
                            hachage[i] = i / nb_par_poule;
                        }
                        for (int i = nb_par_poule * nb_poules; i < nb_qualifies; i++)
                        {
                            hachage[i] = i % nb_poules;
                        }
                    }
                    else // permutations circulaires
                    {
                        for (int i = 0; i < nb_qualifies; i++)
                        {
                            hachage[i] = (i+i/nb_poules) % nb_poules;
                        }
                    }
                }

                int nb_non_qualifies = nb_concurrents - nb_qualifies;

                if (nb_non_qualifies > 0)
                {
                    if (radioButtonAlea.Checked) // affectation aleatoire
                    {
                        for (int i = 0; i < nb_non_qualifies; i++)
                        {
                            hachage[nb_qualifies+i] = i % nb_poules;
                        }
                        // echanges aleatoires parmis les non qualifies
                        for (int i = 0; i < 1000; i++)
                        {
                            int c1 = Rnd.Next(nb_non_qualifies);
                            int c2 = Rnd.Next(nb_non_qualifies);
                            int tmp = hachage[nb_qualifies+c2];
                            hachage[nb_qualifies + c2] = hachage[nb_qualifies+c1];
                            hachage[nb_qualifies+c1] = tmp;
                        }
                    }
                    else if (radioButtonNiveau.Checked) // par niveau
                    {
                        int nb_par_poule = nb_non_qualifies / nb_poules; // nombre min par poules

                        for (int i = 0; i < nb_par_poule * nb_poules; i++)
                        {
                            hachage[nb_qualifies+i] = i / nb_par_poule;
                        }
                        for (int i = nb_par_poule * nb_poules; i < nb_non_qualifies; i++)
                        {
                            hachage[nb_qualifies+i] = i % nb_poules;
                        }
                    }
                    else // permutations
                    {
                        for (int i = 0; i < nb_non_qualifies; i++)
                        {
                            hachage[nb_qualifies+i] = (i + i / nb_poules) % nb_poules;
                        }
                    }
                }

                //---- Determination des circuits ----
                var personnes = from kp in table
                                where kp.Value.NouvelleCategorie==lig_nouv.SubItems[0].Text
                                orderby kp.Value.Classement, kp.Value.Categorie
                                select kp.Value;
                int rang = 0;
                foreach (var concurrent in personnes)
                {
                    rang++;
                    string categ_prec;
                    int circuit_prec;
                    ExtractRootCateg(concurrent.Categorie, out categ_prec, out circuit_prec);

                    if (radioButtonPoules.Checked) // on conserve les poules
                    {
                        concurrent.NouvellePoule = circuit_prec;
                        concurrent.NouveauCircuit = concurrent.NouveauCircuit + concurrent.NouvellePoule;
                        concurrent.StartList = rang;
                    }
                    else // affectation aleatoire, par niveau ou permutation
                    {
                        concurrent.NouvellePoule = hachage[rang-1]+1;
                        concurrent.NouveauCircuit = concurrent.NouveauCircuit + concurrent.NouvellePoule;
                        concurrent.StartList = rang;
                    }
                }
            }

        }

        //-----------------------------------------------------------------------------------------------------------------

        private Resultats[] ListeQualifies(ListViewItem nouv_categ, int circuit)
        {
            Resultats[] t;

            if (radioButtonMeilleursPremiers.Checked)
            {
                t = (from kpo in table
                     where ((kpo.Value.NouvelleCategorie == nouv_categ.SubItems[0].Text) && (kpo.Value.NouvellePoule == circuit) && (kpo.Value.Qualifie))
                     orderby kpo.Value.StartList
                     select kpo.Value).ToArray();
            }
            else if (radioButtonMeilleursDerniers.Checked)
            {
                t = (from kpo in table
                     where ((kpo.Value.NouvelleCategorie == nouv_categ.SubItems[0].Text) && (kpo.Value.NouvellePoule == circuit) && (kpo.Value.Qualifie))
                     orderby kpo.Value.StartList descending
                     select kpo.Value).ToArray();
            }
            else
            {
                t = (from kpo in table
                    where ((kpo.Value.NouvelleCategorie == nouv_categ.SubItems[0].Text) && (kpo.Value.NouvellePoule == circuit) && (kpo.Value.Qualifie))
                    orderby kpo.Value.StartList
                    select kpo.Value).ToArray();

                for (int i = 0; i < 1000; i++)
                {
                    int a1 = Rnd.Next(t.Count());
                    int a2 = Rnd.Next(t.Count());
                    Resultats temp;
                    temp = t[a1];
                    t[a1] = t[a2];
                    t[a2] = temp;
                }
            }

            return t;
        }


        private Resultats[] ListeNonQualifies(ListViewItem nouv_categ, int circuit)
        {
            Resultats[] t;

            if (radioButtonMeilleursPremiers.Checked)
            {
                t = (from kpo in table
                     where ((kpo.Value.NouvelleCategorie == nouv_categ.SubItems[0].Text) && (kpo.Value.NouvellePoule == circuit) && (!kpo.Value.Qualifie))
                     orderby kpo.Value.StartList
                     select kpo.Value).ToArray();
            }
            else if (radioButtonMeilleursDerniers.Checked)
            {
                t = (from kpo in table
                     where ((kpo.Value.NouvelleCategorie == nouv_categ.SubItems[0].Text) && (kpo.Value.NouvellePoule == circuit) && (!kpo.Value.Qualifie))
                     orderby kpo.Value.StartList descending
                     select kpo.Value).ToArray();
            }
            else
            {
                t = (from kpo in table
                     where ((kpo.Value.NouvelleCategorie == nouv_categ.SubItems[0].Text) && (kpo.Value.NouvellePoule == circuit) && (!kpo.Value.Qualifie))
                     orderby kpo.Value.StartList
                     select kpo.Value).ToArray();

                for (int i = 0; i < 1000; i++)
                {
                    int a1 = Rnd.Next(t.Count());
                    int a2 = Rnd.Next(t.Count());
                    Resultats temp;
                    temp = t[a1];
                    t[a1] = t[a2];
                    t[a2] = temp;
                }
            }

            return t;
        }

        //-----------------------------------------------------------------------------------------------------------------

        public void GenereFichierClassementHTML()
        {
            //string chemin = Path.GetFullPath(openFileDialogFicIn.FileName);
            StreamWriter FichierResultat = new StreamWriter(labelResultats.Text, false);

            FichierResultat.WriteLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">");
            FichierResultat.WriteLine("<html>");
            FichierResultat.WriteLine("<head>");
            FichierResultat.WriteLine("<meta http-equiv=\"content-type\" content=\"text/html; charset=windows-1250\">");
            FichierResultat.WriteLine("<meta name=\"generator\" content=\"GecoMouli\">");
            FichierResultat.WriteLine("<title>Résultats</title>");
            FichierResultat.WriteLine("<style type=\"text/css\">");
            FichierResultat.WriteLine("tr.categorie { font-style:normal; font-size:24; color=black }");
            FichierResultat.WriteLine("tr.qualif { font-style:normal; color=black }");
            FichierResultat.WriteLine("tr.nonqualif { font-style:italic; color: gray }");
            FichierResultat.WriteLine("</style>");
            FichierResultat.WriteLine("</head>");
            FichierResultat.WriteLine("<body>");
            FichierResultat.WriteLine("<H1>R&eacute;sultats</H1>");
            FichierResultat.WriteLine("<TABLE>");

            var listeCateg = from kpo in table
                             group kpo by kpo.Value.Categorie into groupeParCategorie
                             select new { Categ = groupeParCategorie.Key, Data = groupeParCategorie };


            foreach (var p in listeCateg)
            {
                FichierResultat.WriteLine("<tr class=\"categorie\"><td>" + p.Categ + "</tr></td>");

                var classement = from kp in table
                                 where kp.Value.Categorie==p.Categ
                                 orderby kp.Value.TempsTotal
                                 select kp.Value;
                foreach (var concurrent in classement)
                {
                    if (concurrent.Qualifie) // qualifié
                    {
                        FichierResultat.WriteLine("<tr class=\"qualif\">" + concurrent.ToHTMLResultats() + "</tr>");
                    }
                    else // non qualifié
                    {
                        FichierResultat.WriteLine("<tr class=\"nonqualif\">" + concurrent.ToHTMLResultats() + "</tr>");
                    }
                }

            }

            FichierResultat.WriteLine("</TABLE>");
            FichierResultat.WriteLine("  </body>");
            FichierResultat.WriteLine("</html>");

            FichierResultat.Close();
        }

        public void GenereStartListQualifiesHTML()
        {
            //string chemin = Path.GetFullPath(openFileDialogFicIn.FileName);
            StreamWriter FichierStartListQualifies = new StreamWriter(Path.ChangeExtension(labelFicOutNameQ.Text,".html"), false);

            FichierStartListQualifies.WriteLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">");
            FichierStartListQualifies.WriteLine("<html>");
            FichierStartListQualifies.WriteLine("<head>");
            FichierStartListQualifies.WriteLine("<meta http-equiv=\"content-type\" content=\"text/html; charset=windows-1250\">");
            FichierStartListQualifies.WriteLine("<meta name=\"generator\" content=\"GecoMouli\">");
            FichierStartListQualifies.WriteLine("<title>Start list qualifiés</title>");
            FichierStartListQualifies.WriteLine("<style type=\"text/css\">");
            FichierStartListQualifies.WriteLine("tr.categorie { font-style:normal; font-size:24; color=black }");
            FichierStartListQualifies.WriteLine("tr.qualif { font-style:normal; color=black }");
            FichierStartListQualifies.WriteLine("tr.nonqualif { font-style:italic; color: gray }");
            FichierStartListQualifies.WriteLine("</style>");
            FichierStartListQualifies.WriteLine("</head>");
            FichierStartListQualifies.WriteLine("<body>");
            FichierStartListQualifies.WriteLine("<H1>Start-list qualifi&eacute;s</H1>");
            FichierStartListQualifies.WriteLine("<TABLE>");

            foreach (ListViewItem nouv_categ in listViewNouvelle.Items)
            {
                for (int circuit=1; circuit<=int.Parse(nouv_categ.SubItems[2].Text); circuit++)
                {
                    FichierStartListQualifies.WriteLine("<tr class=\"categorie\"><td>" + nouv_categ.SubItems[0].Text +" ("+nouv_categ.SubItems[5].Text+") "+ circuit.ToString() + "</tr></td>");

                    int rang = 0;
                    Resultats[] t = ListeQualifies(nouv_categ, circuit);
                    foreach (Resultats p in t)
                    {
                        rang++;
                        FichierStartListQualifies.WriteLine("<tr class=\"qualif\">");
                        FichierStartListQualifies.WriteLine("<td>" + rang.ToString() + "</td>" + "<td>" + p.Nom + "</td>");
                        FichierStartListQualifies.WriteLine("</tr>");
                    }
                } // les circuits
            }   // les catégories

            FichierStartListQualifies.WriteLine("</TABLE>");
            FichierStartListQualifies.WriteLine("</body>");
            FichierStartListQualifies.WriteLine("</html>");

            FichierStartListQualifies.Close();
        }

        public void GenereStartListNonQualifiesHTML()
        {
            //string chemin = Path.GetFullPath(openFileDialogFicIn.FileName);
            StreamWriter FichierStartListNonQualifies = new StreamWriter(Path.ChangeExtension(labelFicOutNameNQ.Text, ".html"), false);

            FichierStartListNonQualifies.WriteLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">");
            FichierStartListNonQualifies.WriteLine("<html>");
            FichierStartListNonQualifies.WriteLine("<head>");
            FichierStartListNonQualifies.WriteLine("<meta http-equiv=\"content-type\" content=\"text/html; charset=windows-1250\">");
            FichierStartListNonQualifies.WriteLine("<meta name=\"generator\" content=\"GecoMouli\">");
            FichierStartListNonQualifies.WriteLine("<title>Start list non qualifiés</title>");
            FichierStartListNonQualifies.WriteLine("<style type=\"text/css\">");
            FichierStartListNonQualifies.WriteLine("tr.categorie { font-style:normal; font-size:24; color=black }");
            FichierStartListNonQualifies.WriteLine("tr.qualif { font-style:normal; color=black }");
            FichierStartListNonQualifies.WriteLine("tr.nonqualif { font-style:italic; color: gray }");
            FichierStartListNonQualifies.WriteLine("</style>");
            FichierStartListNonQualifies.WriteLine("</head>");
            FichierStartListNonQualifies.WriteLine("<body>");
            FichierStartListNonQualifies.WriteLine("<H1>Start-list non qualifi&eacute;s</H1>");
            FichierStartListNonQualifies.WriteLine("<TABLE>");

            foreach (ListViewItem nouv_categ in listViewNouvelle.Items)
            {
                for (int circuit = 1; circuit <= int.Parse(nouv_categ.SubItems[2].Text); circuit++)
                {
                    FichierStartListNonQualifies.WriteLine("<tr class=\"categorie\"><td>" + nouv_categ.SubItems[0].Text + " (" + nouv_categ.SubItems[5].Text + ") " + circuit.ToString() + "</tr></td>");

                    int rang = 0;
                    Resultats[] t = ListeNonQualifies(nouv_categ, circuit);
                    foreach (Resultats p in t)
                    {
                        rang++;
                        FichierStartListNonQualifies.WriteLine("<tr class=\"nonqualif\">");
                        FichierStartListNonQualifies.WriteLine("<td>" + rang.ToString() + "</td>" + "<td>" + p.Nom + "</td>");
                        FichierStartListNonQualifies.WriteLine("</tr>");
                    }

                } // les circuits

            }   // les catégories

            FichierStartListNonQualifies.WriteLine("</TABLE>");
            FichierStartListNonQualifies.WriteLine("</body>");
            FichierStartListNonQualifies.WriteLine("</html>");

            FichierStartListNonQualifies.Close();
        }

        //-------------------------------------------------------------------------------------------------------------------

        public void GenereStartListQualifiesCSV()
        {
            //string chemin = Path.GetFullPath(openFileDialogFicIn.FileName);
            StreamWriter FichierStartListQualifies = new StreamWriter(labelFicOutNameQ.Text, false);

            string s = "Nº Start;Ecard;Id archive;Last name;First name;Birth year;Sex;Slot;NC;Start time;Finish time;";
                   s+="Time/'Geco-course';Eval/Course;Nº club;Short club;Long club;Nat;N° cat;Short cat;Long cat";
            FichierStartListQualifies.WriteLine(s);

            foreach (ListViewItem nouv_categ in listViewNouvelle.Items)
            {
                for (int circuit = 1; circuit <= int.Parse(nouv_categ.SubItems[2].Text); circuit++)
                {
                    Resultats[] t=ListeQualifies(nouv_categ,circuit);
                    foreach (Resultats p in t)
                    {
                        FichierStartListQualifies.WriteLine(p.ToStartListCSV());
                    }

                } // les circuits

            }   // les catégories

            FichierStartListQualifies.Close();
        }

        public void GenereStartListNonQualifiesCSV()
        {
            //string chemin = Path.GetFullPath(openFileDialogFicIn.FileName);
            StreamWriter FichierStartListNonQualifies = new StreamWriter(labelFicOutNameNQ.Text, false);

            string s = "Nº Start;Ecard;Id archive;Last name;First name;Birth year;Sex;Slot;NC;Start time;Finish time;";
            s += "Time/'Geco-course';Eval/Course;Nº club;Short club;Long club;Nat;N° cat;Short cat;Long cat";
            FichierStartListNonQualifies.WriteLine(s);

            foreach (ListViewItem nouv_categ in listViewNouvelle.Items)
            {
                for (int circuit = 1; circuit <= int.Parse(nouv_categ.SubItems[2].Text); circuit++)
                {
                    Resultats[] t = ListeNonQualifies(nouv_categ,circuit);
                    foreach (Resultats p in t)
                    {
                        FichierStartListNonQualifies.WriteLine(p.ToStartListCSV());
                    }

                } // les circuits

            }   // les catégories

            FichierStartListNonQualifies.Close();
        }

        //--------------------------------------------------------------------------------------------------------------------
        
        private void buttonFicIn_Click(object sender, EventArgs e)
        {
            if (openFileDialogFicIn.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialogFicIn.OpenFile()) != null)
                {
                    string nomFicIn = Path.GetFileNameWithoutExtension(openFileDialogFicIn.FileName);
                    textBoxFicIn.Text = nomFicIn;
                    textBoxFicOut.Text = "Startlist " + nomFicIn;
                    // Insert code to read the stream here.
                    myStream.Close();
                    fichierGeco = File.ReadAllLines(openFileDialogFicIn.FileName);
                    if (fichierGeco.GetLength(0) > 1)
                    {
                        bool first = true;
                        foreach (string s in fichierGeco)
                        {
                            if (first)
                            {
                                // saut de la première ligne
                                first = false;
                            }
                            else
                            {
                                Resultats lig = new Resultats();
                                if (lig.Parse(s,double.Parse(textBoxPenalitePM.Text)))
                                {
                                    if (table.ContainsKey(lig.Puce))
                                    {
                                        // puce deja utilisee : on ajoute le nouveau temps
                                        table[lig.Puce].AddTemps(lig.TempsTotal,lig.Indice);
                                    }
                                    else
                                    {
                                        table.Add(lig.Puce, lig);
                                    }
                                }
                            }
                        }// fichier OK
                        buttonRun.Enabled = true;
                        groupBox1.Enabled = true;
                        groupBox2.Enabled = true;
                        buttonFicIn.Enabled = false;

                        CreationTableauPrec();
                        CreationTableauNouv();
                     
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxFicOut_TextChanged(object sender, EventArgs e)
        {
            string nomFicOutQualifies = textBoxFicOut.Text + " Qualifies.csv";
            labelFicOutNameQ.Text = nomFicOutQualifies;
            string nomFicOutNonQualifies = textBoxFicOut.Text + " NQ.csv";
            labelFicOutNameNQ.Text = nomFicOutNonQualifies;
            string nomFicOutResultats = textBoxFicOut.Text + " Resultats.html";
            labelResultats.Text = nomFicOutResultats;
        }

        private void FormGecoMouli_Load(object sender, EventArgs e)
        {

        }

        private void listViewPrec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPrec.SelectedItems.Count > 0)
            {
                prevIndex = listViewPrec.SelectedItems[0].Index;
                numericUpDownNbCircuits.Value  = int.Parse(listViewPrec.Items[prevIndex].SubItems[2].Text);
                comboBoxGroupeQualif.Text = listViewPrec.Items[prevIndex].SubItems[3].Text;
                numericUpDownNbCircuits.Enabled = true;
                comboBoxGroupeQualif.Enabled = true;
            }
            else
            {
                listViewPrec.Items[prevIndex].SubItems[2].Text = numericUpDownNbCircuits.Value.ToString();
                listViewPrec.Items[prevIndex].SubItems[3].Text = comboBoxGroupeQualif.Text;
                numericUpDownNbCircuits.Enabled = false;
                comboBoxGroupeQualif.Enabled = false;
            }
        }

        private void listViewNouvelle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNouvelle.SelectedItems.Count > 0)
            {
                prevIndexNvlle = listViewNouvelle.SelectedItems[0].Index;
                textBoxNvlleCateg.Text = listViewNouvelle.Items[prevIndexNvlle].Text;
                textBoxNouvCircuit.Text = listViewNouvelle.Items[prevIndexNvlle].SubItems[5].Text;
                numericUpDownPoules.Value = int.Parse(listViewNouvelle.Items[prevIndexNvlle].SubItems[2].Text);
                numericUpDownQualifies.Value = int.Parse(listViewNouvelle.Items[prevIndexNvlle].SubItems[3].Text);
                textBoxNvlleCateg.Enabled = true;
                numericUpDownPoules.Enabled = true;
                numericUpDownQualifies.Enabled = true;
                textBoxNouvCircuit.Enabled = true;
                buttonSupprNvlleCourse.Enabled = true;
            }
            else
            {
                listViewNouvelle.Items[prevIndexNvlle].Text = textBoxNvlleCateg.Text;
                listViewNouvelle.Items[prevIndexNvlle].SubItems[2].Text = numericUpDownPoules.Value.ToString();
                listViewNouvelle.Items[prevIndexNvlle].SubItems[3].Text = numericUpDownQualifies.Value.ToString();
                listViewNouvelle.Items[prevIndexNvlle].SubItems[5].Text = textBoxNouvCircuit.Text;
                textBoxNvlleCateg.Enabled = false;
                numericUpDownPoules.Enabled = false;
                numericUpDownQualifies.Enabled = false;
                textBoxNouvCircuit.Enabled = false;
                buttonSupprNvlleCourse.Enabled = false;
                prevIndexNvlle = -1;
            }
        }


        // Modification du nombre de poules
        private void numericUpDownPoules_ValueChanged(object sender, EventArgs e)
        {
            listViewNouvelle.Items[prevIndexNvlle].SubItems[2].Text = numericUpDownPoules.Value.ToString();
            MAJTotalQualifies(listViewNouvelle.Items[prevIndexNvlle]);
            VerifCoherenceTableauNouv();
        }

        // Modification du nombre de qualifies par poule
        private void numericUpDownQualifies_ValueChanged(object sender, EventArgs e)
        {
            listViewNouvelle.Items[prevIndexNvlle].SubItems[3].Text = numericUpDownQualifies.Value.ToString();
            MAJTotalQualifies(listViewNouvelle.Items[prevIndexNvlle]);
            VerifCoherenceTableauNouv();
        }


        private void numericUpDownNbCircuits_ValueChanged(object sender, EventArgs e)
        {
            listViewPrec.Items[prevIndex].SubItems[2].Text = numericUpDownNbCircuits.Value.ToString();
        }

        private void comboBoxGroupeQualif_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewPrec.Items[prevIndex].SubItems[3].Text = comboBoxGroupeQualif.Text;
            VerifCoherenceTableauNouv();
        }

        //--------------- Ajout et suppression nouvelle catégorie ---------------------

        private void buttonNouvelleCateg_Click(object sender, EventArgs e)
        {
            ListViewItem nouvelle_course = new ListViewItem();
            nouvelle_course.Text = "new" + (listViewNouvelle.Items.Count+1).ToString(); // catégorie
            nouvelle_course.SubItems.Add(0.ToString());                                 // nb qualifiables
            nouvelle_course.SubItems.Add(numericUpDownPoules.Value.ToString());         // nb poules
            nouvelle_course.SubItems.Add(numericUpDownQualifies.Value.ToString());      // nb qualifies par poules
            nouvelle_course.SubItems.Add(0.ToString());                                 // nb total qualifies
            if (checkBoxConserverCircuit.Checked)
                nouvelle_course.SubItems.Add(textBoxPrefixeCircuit.Text + nouvelle_course.Text + textBoxSuffixeCircuit.Text);  // Circuit
            else
                nouvelle_course.SubItems.Add(textBoxPrefixeCircuit.Text + textBoxSuffixeCircuit.Text);  // Circuit

            listViewNouvelle.Items.Add(nouvelle_course);

            comboBoxGroupeQualif.Items.Add(nouvelle_course.Text);
            listViewNouvelle.Items[listViewNouvelle.Items.Count - 1].Selected = true;
            VerifCoherenceTableauNouv();
        }

        private void buttonSupprNvlleCourse_Click(object sender, EventArgs e)
        {
            if (prevIndexNvlle >= 0)
            {
                listViewNouvelle.Items[prevIndexNvlle].Remove();
            }
            CreateListeCateg();
            VerifCoherenceTableauNouv();
        }

        //----------------------------------------------------------------------------------

        private void CreateListeCateg()
        {
            // Mise à jour liste des categories
            comboBoxGroupeQualif.Items.Clear();
            foreach (ListViewItem item in listViewNouvelle.Items)
            {
                comboBoxGroupeQualif.Items.Add(item.Text);
            }

            // Mise à jour tableau
            foreach (ListViewItem ligne in listViewPrec.Items)
            {
                bool trouve = false;
                foreach(ListViewItem item in listViewNouvelle.Items)
                {
                    if (ligne.SubItems[3].Text == item.Text) trouve = true;
                }
                if (!trouve)
                {
                    ligne.SubItems[3].Text = "?";
                }
            }

            // slection element courant dans combo
            if (listViewPrec.SelectedItems.Count > 0)
            {
                prevIndex = listViewPrec.SelectedItems[0].Index;
                comboBoxGroupeQualif.Text = listViewPrec.Items[prevIndex].SubItems[3].Text;
            }
        }

        private bool VerifCircuits()
        {
            bool ok=false;
            foreach (ListViewItem categ in listViewPrec.Items)
            {
                // verif du nombre de circuits pour chaque concurrent de la catégorie
                var concurrents = from kp in table
                                 where kp.Value.Categorie == categ.Text
                                 select kp.Value;
                foreach (var concurrent in concurrents)
                {
                    int nb_circuits = concurrent.NbCircuits;
                    if ( nb_circuits< int.Parse(categ.SubItems[2].Text))
                    {
                        // on rajoute 1h aux circuits pas effectués
                        while (nb_circuits < int.Parse(categ.SubItems[2].Text))
                        {
                            nb_circuits++;
                            table[concurrent.Puce].AddTemps(double.Parse(textBoxPenalitesManque.Text), "+" + nb_circuits.ToString());
                        }
                        ok = true;
                    }
                    else if (nb_circuits > int.Parse(categ.SubItems[2].Text))
                    {
                        // trop de circuits => message
                        MessageBox.Show("Le concurrent " + concurrent.Nom + " a " + nb_circuits.ToString() + " circuits au lieu de " + categ.SubItems[2].Text);
                        ok = false;
                    }
                    else
                    {
                        ok = true;
                    }
                }


            }
            return ok;
        }


        private void textBoxNvlleCateg_TextChanged(object sender, EventArgs e)
        {
            string prev_text = listViewNouvelle.Items[prevIndexNvlle].Text;
            if (prev_text != textBoxNvlleCateg.Text)
            {
                listViewNouvelle.Items[prevIndexNvlle].Text = textBoxNvlleCateg.Text;

                // Mise à jour tableau
                foreach (ListViewItem ligne in listViewPrec.Items)
                {
                    if (ligne.SubItems[3].Text == prev_text) ligne.SubItems[3].Text = textBoxNvlleCateg.Text;
                }
                CreateListeCateg();
            }
        }

        private void textBoxNouveauCircuit_TextChanged(object sender, EventArgs e)
        {
            string prev_text = listViewNouvelle.Items[prevIndexNvlle].SubItems[5].Text;
            if (prev_text != textBoxNouvCircuit.Text)
            {
                listViewNouvelle.Items[prevIndexNvlle].SubItems[5].Text = textBoxNouvCircuit.Text;
            }
        }


        private void buttonRun_Click(object sender, EventArgs e)
        {
            if(VerifCircuits())
            {
                CalculClassement();
                DetermineQualifications();
                GenereFichierClassementHTML();
                GenereStartListQualifiesHTML();
                GenereStartListNonQualifiesHTML();
                GenereStartListQualifiesCSV();
                GenereStartListNonQualifiesCSV();
            }
            Application.Exit();
        }

    }
}
