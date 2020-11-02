namespace ProjetIA_Voilier
{
    partial class FenetreApplication
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
            this.components = new System.ComponentModel.Container();
            this.groupBox_Parametres = new System.Windows.Forms.GroupBox();
            this.groupBox_TailleCarte = new System.Windows.Forms.GroupBox();
            this.label_TailleCarte = new System.Windows.Forms.Label();
            this.trackBar_TailleCarte = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox_PositionFinale = new System.Windows.Forms.GroupBox();
            this.textBox_y_pf = new System.Windows.Forms.TextBox();
            this.textBox_x_pf = new System.Windows.Forms.TextBox();
            this.label_x_pf = new System.Windows.Forms.Label();
            this.label_y_pf = new System.Windows.Forms.Label();
            this.groupBox_PositionInitiale = new System.Windows.Forms.GroupBox();
            this.textBox_y_pi = new System.Windows.Forms.TextBox();
            this.textBox_x_pi = new System.Windows.Forms.TextBox();
            this.label_x_pi = new System.Windows.Forms.Label();
            this.label_y_pi = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.genericNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox_Parametres.SuspendLayout();
            this.groupBox_TailleCarte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TailleCarte)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_PositionFinale.SuspendLayout();
            this.groupBox_PositionInitiale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.genericNodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Parametres
            // 
            this.groupBox_Parametres.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox_Parametres.Controls.Add(this.groupBox_TailleCarte);
            this.groupBox_Parametres.Controls.Add(this.button1);
            this.groupBox_Parametres.Controls.Add(this.groupBox3);
            this.groupBox_Parametres.Controls.Add(this.groupBox_PositionFinale);
            this.groupBox_Parametres.Controls.Add(this.groupBox_PositionInitiale);
            this.groupBox_Parametres.Controls.Add(this.trackBar2);
            this.groupBox_Parametres.Controls.Add(this.label2);
            this.groupBox_Parametres.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Parametres.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Parametres.Name = "groupBox_Parametres";
            this.groupBox_Parametres.Size = new System.Drawing.Size(959, 213);
            this.groupBox_Parametres.TabIndex = 0;
            this.groupBox_Parametres.TabStop = false;
            this.groupBox_Parametres.Text = "Paramètres";
            // 
            // groupBox_TailleCarte
            // 
            this.groupBox_TailleCarte.Controls.Add(this.label_TailleCarte);
            this.groupBox_TailleCarte.Controls.Add(this.trackBar_TailleCarte);
            this.groupBox_TailleCarte.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_TailleCarte.Location = new System.Drawing.Point(22, 40);
            this.groupBox_TailleCarte.Name = "groupBox_TailleCarte";
            this.groupBox_TailleCarte.Size = new System.Drawing.Size(328, 75);
            this.groupBox_TailleCarte.TabIndex = 17;
            this.groupBox_TailleCarte.TabStop = false;
            this.groupBox_TailleCarte.Text = "Taille Carte (km)";
            // 
            // label_TailleCarte
            // 
            this.label_TailleCarte.AutoSize = true;
            this.label_TailleCarte.Location = new System.Drawing.Point(258, 31);
            this.label_TailleCarte.Name = "label_TailleCarte";
            this.label_TailleCarte.Size = new System.Drawing.Size(40, 23);
            this.label_TailleCarte.TabIndex = 2;
            this.label_TailleCarte.Text = "300";
            // 
            // trackBar_TailleCarte
            // 
            this.trackBar_TailleCarte.LargeChange = 50;
            this.trackBar_TailleCarte.Location = new System.Drawing.Point(6, 27);
            this.trackBar_TailleCarte.Maximum = 900;
            this.trackBar_TailleCarte.Minimum = 200;
            this.trackBar_TailleCarte.Name = "trackBar_TailleCarte";
            this.trackBar_TailleCarte.Size = new System.Drawing.Size(245, 45);
            this.trackBar_TailleCarte.SmallChange = 50;
            this.trackBar_TailleCarte.TabIndex = 50;
            this.trackBar_TailleCarte.TickFrequency = 50;
            this.trackBar_TailleCarte.Value = 300;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(770, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 59);
            this.button1.TabIndex = 18;
            this.button1.Text = "Démarrer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(770, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 69);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Type de Vent";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Items.AddRange(new object[] {
            "a",
            "b",
            "c"});
            this.listBox1.Location = new System.Drawing.Point(13, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 23);
            this.listBox1.TabIndex = 15;
            // 
            // groupBox_PositionFinale
            // 
            this.groupBox_PositionFinale.Controls.Add(this.textBox_y_pf);
            this.groupBox_PositionFinale.Controls.Add(this.textBox_x_pf);
            this.groupBox_PositionFinale.Controls.Add(this.label_x_pf);
            this.groupBox_PositionFinale.Controls.Add(this.label_y_pf);
            this.groupBox_PositionFinale.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_PositionFinale.Location = new System.Drawing.Point(400, 111);
            this.groupBox_PositionFinale.Name = "groupBox_PositionFinale";
            this.groupBox_PositionFinale.Size = new System.Drawing.Size(328, 69);
            this.groupBox_PositionFinale.TabIndex = 17;
            this.groupBox_PositionFinale.TabStop = false;
            this.groupBox_PositionFinale.Text = "Position Finale";
            // 
            // textBox_y_pf
            // 
            this.textBox_y_pf.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_y_pf.Location = new System.Drawing.Point(215, 27);
            this.textBox_y_pf.Name = "textBox_y_pf";
            this.textBox_y_pf.Size = new System.Drawing.Size(100, 31);
            this.textBox_y_pf.TabIndex = 6;
            // 
            // textBox_x_pf
            // 
            this.textBox_x_pf.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_x_pf.Location = new System.Drawing.Point(41, 27);
            this.textBox_x_pf.Name = "textBox_x_pf";
            this.textBox_x_pf.Size = new System.Drawing.Size(100, 31);
            this.textBox_x_pf.TabIndex = 5;
            // 
            // label_x_pf
            // 
            this.label_x_pf.AutoSize = true;
            this.label_x_pf.Font = new System.Drawing.Font("Calibri", 12F);
            this.label_x_pf.Location = new System.Drawing.Point(8, 28);
            this.label_x_pf.Name = "label_x_pf";
            this.label_x_pf.Size = new System.Drawing.Size(20, 19);
            this.label_x_pf.TabIndex = 7;
            this.label_x_pf.Text = "x:";
            // 
            // label_y_pf
            // 
            this.label_y_pf.AutoSize = true;
            this.label_y_pf.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_y_pf.Location = new System.Drawing.Point(182, 28);
            this.label_y_pf.Name = "label_y_pf";
            this.label_y_pf.Size = new System.Drawing.Size(20, 19);
            this.label_y_pf.TabIndex = 8;
            this.label_y_pf.Text = "y:";
            // 
            // groupBox_PositionInitiale
            // 
            this.groupBox_PositionInitiale.Controls.Add(this.textBox_y_pi);
            this.groupBox_PositionInitiale.Controls.Add(this.textBox_x_pi);
            this.groupBox_PositionInitiale.Controls.Add(this.label_x_pi);
            this.groupBox_PositionInitiale.Controls.Add(this.label_y_pi);
            this.groupBox_PositionInitiale.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_PositionInitiale.Location = new System.Drawing.Point(22, 121);
            this.groupBox_PositionInitiale.Name = "groupBox_PositionInitiale";
            this.groupBox_PositionInitiale.Size = new System.Drawing.Size(328, 69);
            this.groupBox_PositionInitiale.TabIndex = 16;
            this.groupBox_PositionInitiale.TabStop = false;
            this.groupBox_PositionInitiale.Text = "Position Initiale";
            // 
            // textBox_y_pi
            // 
            this.textBox_y_pi.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_y_pi.Location = new System.Drawing.Point(215, 27);
            this.textBox_y_pi.Name = "textBox_y_pi";
            this.textBox_y_pi.Size = new System.Drawing.Size(100, 31);
            this.textBox_y_pi.TabIndex = 6;
            // 
            // textBox_x_pi
            // 
            this.textBox_x_pi.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_x_pi.Location = new System.Drawing.Point(41, 27);
            this.textBox_x_pi.Name = "textBox_x_pi";
            this.textBox_x_pi.Size = new System.Drawing.Size(100, 31);
            this.textBox_x_pi.TabIndex = 5;
            // 
            // label_x_pi
            // 
            this.label_x_pi.AutoSize = true;
            this.label_x_pi.Font = new System.Drawing.Font("Calibri", 12F);
            this.label_x_pi.Location = new System.Drawing.Point(8, 28);
            this.label_x_pi.Name = "label_x_pi";
            this.label_x_pi.Size = new System.Drawing.Size(20, 19);
            this.label_x_pi.TabIndex = 7;
            this.label_x_pi.Text = "x:";
            // 
            // label_y_pi
            // 
            this.label_y_pi.AutoSize = true;
            this.label_y_pi.Font = new System.Drawing.Font("Calibri", 12F);
            this.label_y_pi.Location = new System.Drawing.Point(182, 28);
            this.label_y_pi.Name = "label_y_pi";
            this.label_y_pi.Size = new System.Drawing.Size(20, 19);
            this.label_y_pi.TabIndex = 8;
            this.label_y_pi.Text = "y:";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(394, 64);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(306, 45);
            this.trackBar2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Taille carte";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 231);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(959, 407);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Simulation";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox5.Location = new System.Drawing.Point(22, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(350, 350);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "350 x 350";
            // 
            // genericNodeBindingSource
            // 
            this.genericNodeBindingSource.DataSource = typeof(ProjetIA_Voilier.GenericNode);
            // 
            // FenetreApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 646);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_Parametres);
            this.Name = "FenetreApplication";
            this.Text = "Form1";
            this.groupBox_Parametres.ResumeLayout(false);
            this.groupBox_Parametres.PerformLayout();
            this.groupBox_TailleCarte.ResumeLayout(false);
            this.groupBox_TailleCarte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TailleCarte)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox_PositionFinale.ResumeLayout(false);
            this.groupBox_PositionFinale.PerformLayout();
            this.groupBox_PositionInitiale.ResumeLayout(false);
            this.groupBox_PositionInitiale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.genericNodeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Parametres;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar_TailleCarte;
        private System.Windows.Forms.Label label_y_pi;
        private System.Windows.Forms.Label label_x_pi;
        private System.Windows.Forms.TextBox textBox_y_pi;
        private System.Windows.Forms.TextBox textBox_x_pi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox_PositionFinale;
        private System.Windows.Forms.TextBox textBox_y_pf;
        private System.Windows.Forms.TextBox textBox_x_pf;
        private System.Windows.Forms.Label label_x_pf;
        private System.Windows.Forms.Label label_y_pf;
        private System.Windows.Forms.GroupBox groupBox_PositionInitiale;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox_TailleCarte;
        private System.Windows.Forms.Label label_TailleCarte;
        private System.Windows.Forms.BindingSource genericNodeBindingSource;
    }
}

