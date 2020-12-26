using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjetEspionKeyLogger;

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

            List<Enregistrement> list_enregistrement = collection_enregistrement.List_Enregistrement;

            //On affiche dans la console 
            foreach (Enregistrement enregistrement in list_enregistrement)
            {
                this.listBox_enregistrements.Items.Add(enregistrement.Date);


            }

            listBox_enregistrements.EndUpdate();

        }
    }
}
