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
            collection_enregistrement = CollectionEnregistrement.loadFromXML("../../../TestXML.xml");

            //On affiche dans la console 
            for(int i = 0; i < collection_enregistrement.List_Enregistrement.Count; i++)
            {
                //On affiche la date dans la liste d'enregistrement
                this.listBox_enregistrements.Items.Add(collection_enregistrement.List_Enregistrement[i].Date);
            }

        }

        private void listBox_enregistrements_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_contenu.Text = collection_enregistrement.List_Enregistrement[listBox_enregistrements.SelectedIndex].Contenu;
        }
    }
}
