using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetKeyLogger;

namespace ProjetEspionReporting
{
    public partial class Form1 : Form
    {
        CollectionEnregistrement collection_enregistrement = new CollectionEnregistrement();

        public Form1()
        {
            InitializeComponent();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Chargement du fichier XML


            //On affiche dans la console 
            /**/

            if (this.openFileDialog_ouvrir.ShowDialog() == DialogResult.OK)
            {
                //if (this.openFileDialog_ouvrir.FilterIndex == 1)
                //  {
                collection_enregistrement = CollectionEnregistrement.loadFromXML(this.openFileDialog_ouvrir.FileName);
                for (int i = 0; i < collection_enregistrement.List_Enregistrement.Count; i++)
                {
                    //On affiche la date dans la liste d'enregistrement
                    this.listBox_enregistrements.Items.Add(collection_enregistrement.List_Enregistrement[i].Date);
                }
                // }
                //else
                //  {
                ////pas nécessaire mais meilleur pour la clarté
                //valeurs = null;

                ////création de l'objet à partir du flux xml
                //valeurs = StatTab.createFromXMLFile(this.openFileDialog_ouvrir.FileName);

                ////connexion et synchronisation avec la listbox
                //valeurs.connecter(this.lstValeurs);
                //valeurs.setToListbox(this.lstValeurs);
                //}
            }

        }

        private void listBox_enregistrements_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_contenu.Text = collection_enregistrement.List_Enregistrement[listBox_enregistrements.SelectedIndex].Contenu;
        }

        //Recherche du mot saisie dans le textbox 
        private void button_recherche_Click(object sender, EventArgs e)
        {
            //on vide la listBox
            listBox_enregistrements.Items.Clear();

            //Pour chaque enregistrement
            for (int i = 0; i< collection_enregistrement.List_Enregistrement.Count; i++)
            {
                //Si la chaine contient le mot
                if (collection_enregistrement.List_Enregistrement[i].Contenu.Contains(textBox_recherche.Text.ToString()))
                {
                    //Alors on ajoute l'enregistrement a la liste
                    listBox_enregistrements.Items.Add(collection_enregistrement.List_Enregistrement[i].Date);
                }
            }
        }
    }
}