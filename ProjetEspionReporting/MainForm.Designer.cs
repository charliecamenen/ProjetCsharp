﻿
namespace ProjetEspionReporting
{
    partial class Reporting
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_enregistrements = new System.Windows.Forms.ListBox();
            this.label_contenu = new System.Windows.Forms.Label();
            this.label_recherche = new System.Windows.Forms.Label();
            this.button_recherche = new System.Windows.Forms.Button();
            this.textBox_recherche = new System.Windows.Forms.TextBox();
            this.comboBox_adresse = new System.Windows.Forms.ComboBox();
            this.label_adresse = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.comboBox_date = new System.Windows.Forms.ComboBox();
            this.openFileDialog_ouvrir = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // listBox_enregistrements
            // 
            this.listBox_enregistrements.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox_enregistrements.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_enregistrements.ForeColor = System.Drawing.Color.LawnGreen;
            this.listBox_enregistrements.FormattingEnabled = true;
            this.listBox_enregistrements.ItemHeight = 25;
            this.listBox_enregistrements.Location = new System.Drawing.Point(22, 126);
            this.listBox_enregistrements.Name = "listBox_enregistrements";
            this.listBox_enregistrements.Size = new System.Drawing.Size(297, 354);
            this.listBox_enregistrements.TabIndex = 1;
            this.listBox_enregistrements.SelectedIndexChanged += new System.EventHandler(this.listBox_enregistrements_SelectedIndexChanged);
            // 
            // label_contenu
            // 
            this.label_contenu.BackColor = System.Drawing.Color.Black;
            this.label_contenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_contenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_contenu.ForeColor = System.Drawing.Color.LawnGreen;
            this.label_contenu.Location = new System.Drawing.Point(367, 126);
            this.label_contenu.Name = "label_contenu";
            this.label_contenu.Size = new System.Drawing.Size(835, 354);
            this.label_contenu.TabIndex = 2;
            // 
            // label_recherche
            // 
            this.label_recherche.AutoSize = true;
            this.label_recherche.Location = new System.Drawing.Point(363, 69);
            this.label_recherche.Name = "label_recherche";
            this.label_recherche.Size = new System.Drawing.Size(153, 20);
            this.label_recherche.TabIndex = 3;
            this.label_recherche.Text = "Rechercher un mot :";
            // 
            // button_recherche
            // 
            this.button_recherche.Location = new System.Drawing.Point(762, 62);
            this.button_recherche.Name = "button_recherche";
            this.button_recherche.Size = new System.Drawing.Size(120, 34);
            this.button_recherche.TabIndex = 4;
            this.button_recherche.Text = "Rechercher";
            this.button_recherche.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button_recherche.UseVisualStyleBackColor = true;
            this.button_recherche.Click += new System.EventHandler(this.updateListBox);
            // 
            // textBox_recherche
            // 
            this.textBox_recherche.Location = new System.Drawing.Point(522, 66);
            this.textBox_recherche.Name = "textBox_recherche";
            this.textBox_recherche.Size = new System.Drawing.Size(234, 26);
            this.textBox_recherche.TabIndex = 5;
            this.textBox_recherche.TextChanged += new System.EventHandler(this.updateListBox);
            // 
            // comboBox_adresse
            // 
            this.comboBox_adresse.FormattingEnabled = true;
            this.comboBox_adresse.Location = new System.Drawing.Point(149, 36);
            this.comboBox_adresse.Name = "comboBox_adresse";
            this.comboBox_adresse.Size = new System.Drawing.Size(160, 28);
            this.comboBox_adresse.TabIndex = 6;
            this.comboBox_adresse.SelectedIndexChanged += new System.EventHandler(this.updateListBox);
            // 
            // label_adresse
            // 
            this.label_adresse.AutoSize = true;
            this.label_adresse.Location = new System.Drawing.Point(29, 39);
            this.label_adresse.Name = "label_adresse";
            this.label_adresse.Size = new System.Drawing.Size(76, 20);
            this.label_adresse.TabIndex = 7;
            this.label_adresse.Text = "Adresse :";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(29, 76);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(52, 20);
            this.label_date.TabIndex = 8;
            this.label_date.Text = "Date :";
            // 
            // comboBox_date
            // 
            this.comboBox_date.FormattingEnabled = true;
            this.comboBox_date.Location = new System.Drawing.Point(149, 78);
            this.comboBox_date.Name = "comboBox_date";
            this.comboBox_date.Size = new System.Drawing.Size(160, 28);
            this.comboBox_date.TabIndex = 9;
            this.comboBox_date.SelectedIndexChanged += new System.EventHandler(this.updateListBox);
            // 
            // openFileDialog_ouvrir
            // 
            this.openFileDialog_ouvrir.FileName = "openFileDialog1";
            this.openFileDialog_ouvrir.Multiselect = true;
            // 
            // Reporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 492);
            this.Controls.Add(this.comboBox_date);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_adresse);
            this.Controls.Add(this.comboBox_adresse);
            this.Controls.Add(this.textBox_recherche);
            this.Controls.Add(this.button_recherche);
            this.Controls.Add(this.label_recherche);
            this.Controls.Add(this.label_contenu);
            this.Controls.Add(this.listBox_enregistrements);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Reporting";
            this.Text = "Reporting";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox_enregistrements;
        private System.Windows.Forms.Label label_contenu;
        private System.Windows.Forms.Label label_recherche;
        private System.Windows.Forms.Button button_recherche;
        private System.Windows.Forms.TextBox textBox_recherche;
        private System.Windows.Forms.ComboBox comboBox_adresse;
        private System.Windows.Forms.Label label_adresse;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.ComboBox comboBox_date;
        private System.Windows.Forms.OpenFileDialog openFileDialog_ouvrir;
    }
}

