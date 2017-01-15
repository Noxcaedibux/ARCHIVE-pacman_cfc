namespace Pacman
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.cmdRegles = new System.Windows.Forms.Button();
            this.cmdNouvellePartie = new System.Windows.Forms.Button();
            this.cmdScores = new System.Windows.Forms.Button();
            this.lblRegles = new System.Windows.Forms.Label();
            this.pbPacman = new System.Windows.Forms.PictureBox();
            this.lblScores = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPacman)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRegles
            // 
            this.cmdRegles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRegles.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRegles.Location = new System.Drawing.Point(-1, -1);
            this.cmdRegles.Name = "cmdRegles";
            this.cmdRegles.Size = new System.Drawing.Size(171, 144);
            this.cmdRegles.TabIndex = 0;
            this.cmdRegles.Text = "Règles";
            this.cmdRegles.UseVisualStyleBackColor = true;
            this.cmdRegles.MouseEnter += new System.EventHandler(this.cmdRegles_MouseEnter);
            this.cmdRegles.MouseLeave += new System.EventHandler(this.cmdRegles_MouseLeave);
            // 
            // cmdNouvellePartie
            // 
            this.cmdNouvellePartie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNouvellePartie.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNouvellePartie.Location = new System.Drawing.Point(-1, 142);
            this.cmdNouvellePartie.Name = "cmdNouvellePartie";
            this.cmdNouvellePartie.Size = new System.Drawing.Size(171, 144);
            this.cmdNouvellePartie.TabIndex = 1;
            this.cmdNouvellePartie.Text = "Nouvelle Partie";
            this.cmdNouvellePartie.UseVisualStyleBackColor = true;
            this.cmdNouvellePartie.Click += new System.EventHandler(this.cmdNouvellePartie_Click);
            this.cmdNouvellePartie.MouseEnter += new System.EventHandler(this.cmdNouvellePartie_MouseEnter);
            this.cmdNouvellePartie.MouseLeave += new System.EventHandler(this.cmdNouvellePartie_MouseLeave);
            // 
            // cmdScores
            // 
            this.cmdScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdScores.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdScores.Location = new System.Drawing.Point(-1, 285);
            this.cmdScores.Name = "cmdScores";
            this.cmdScores.Size = new System.Drawing.Size(171, 144);
            this.cmdScores.TabIndex = 2;
            this.cmdScores.Text = "Scores";
            this.cmdScores.UseVisualStyleBackColor = true;
            this.cmdScores.MouseEnter += new System.EventHandler(this.cmdScores_MouseEnter);
            this.cmdScores.MouseLeave += new System.EventHandler(this.cmdScores_MouseLeave);
            // 
            // lblRegles
            // 
            this.lblRegles.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegles.Location = new System.Drawing.Point(176, 17);
            this.lblRegles.Name = "lblRegles";
            this.lblRegles.Size = new System.Drawing.Size(405, 375);
            this.lblRegles.TabIndex = 3;
            this.lblRegles.Text = resources.GetString("lblRegles.Text");
            // 
            // pbPacman
            // 
            this.pbPacman.Image = global::Pacman.Properties.Resources.droite;
            this.pbPacman.Location = new System.Drawing.Point(176, 17);
            this.pbPacman.Name = "pbPacman";
            this.pbPacman.Size = new System.Drawing.Size(401, 375);
            this.pbPacman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPacman.TabIndex = 4;
            this.pbPacman.TabStop = false;
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Font = new System.Drawing.Font("Engravers MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.Location = new System.Drawing.Point(175, 17);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(0, 25);
            this.lblScores.TabIndex = 5;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 426);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.pbPacman);
            this.Controls.Add(this.lblRegles);
            this.Controls.Add(this.cmdScores);
            this.Controls.Add(this.cmdNouvellePartie);
            this.Controls.Add(this.cmdRegles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pbPacman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdRegles;
        private System.Windows.Forms.Button cmdNouvellePartie;
        private System.Windows.Forms.Button cmdScores;
        private System.Windows.Forms.Label lblRegles;
        private System.Windows.Forms.PictureBox pbPacman;
        private System.Windows.Forms.Label lblScores;
    }
}

