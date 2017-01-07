namespace Pacman
{
    partial class frmJeu
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
            this.components = new System.ComponentModel.Container();
            this.timerDeplacement = new System.Windows.Forms.Timer(this.components);
            this.timerClydeSortirCage = new System.Windows.Forms.Timer(this.components);
            this.timerClyde = new System.Windows.Forms.Timer(this.components);
            this.timerBlinkySortirCage = new System.Windows.Forms.Timer(this.components);
            this.timerBlinky = new System.Windows.Forms.Timer(this.components);
            this.timerPinkySortirCage = new System.Windows.Forms.Timer(this.components);
            this.timerPinky = new System.Windows.Forms.Timer(this.components);
            this.timerInkySortirCage = new System.Windows.Forms.Timer(this.components);
            this.timerInky = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerDeplacement
            // 
            this.timerDeplacement.Interval = 10;
            this.timerDeplacement.Tick += new System.EventHandler(this.timerDeplacement_Tick);
            // 
            // timerClydeSortirCage
            // 
            this.timerClydeSortirCage.Interval = 10;
            this.timerClydeSortirCage.Tick += new System.EventHandler(this.timerClydeSortirCage_Tick);
            // 
            // timerClyde
            // 
            this.timerClyde.Interval = 10;
            this.timerClyde.Tick += new System.EventHandler(this.timerClyde_Tick);
            // 
            // timerBlinkySortirCage
            // 
            this.timerBlinkySortirCage.Interval = 10;
            this.timerBlinkySortirCage.Tick += new System.EventHandler(this.timerBlinkySortirCage_Tick);
            // 
            // timerBlinky
            // 
            this.timerBlinky.Interval = 10;
            this.timerBlinky.Tick += new System.EventHandler(this.timerBlinky_Tick);
            // 
            // timerPinkySortirCage
            // 
            this.timerPinkySortirCage.Interval = 10;
            this.timerPinkySortirCage.Tick += new System.EventHandler(this.timerPinkySortirCage_Tick);
            // 
            // timerPinky
            // 
            this.timerPinky.Interval = 10;
            this.timerPinky.Tick += new System.EventHandler(this.timerPinky_Tick);
            // 
            // timerInkySortirCage
            // 
            this.timerInkySortirCage.Interval = 10;
            this.timerInkySortirCage.Tick += new System.EventHandler(this.timerInkySortirCage_Tick);
            // 
            // timerInky
            // 
            this.timerInky.Interval = 10;
            this.timerInky.Tick += new System.EventHandler(this.timerInky_Tick);
            // 
            // frmJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 567);
            this.Name = "frmJeu";
            this.Text = "frmJeu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmJeu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerDeplacement;
        private System.Windows.Forms.Timer timerClydeSortirCage;
        private System.Windows.Forms.Timer timerClyde;
        private System.Windows.Forms.Timer timerBlinkySortirCage;
        private System.Windows.Forms.Timer timerBlinky;
        private System.Windows.Forms.Timer timerPinkySortirCage;
        private System.Windows.Forms.Timer timerPinky;
        private System.Windows.Forms.Timer timerInkySortirCage;
        private System.Windows.Forms.Timer timerInky;
    }
}