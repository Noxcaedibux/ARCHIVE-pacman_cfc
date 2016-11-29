using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class FrmMenu : Form
    {
        #region private attributes
        private frmJeu _frmJeu;
        #endregion private attributes

        #region constructors
        public FrmMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = new Size(609, 464);
            this.MinimumSize = new Size(609, 464);
            this.lblRegles.Visible = false;
            this.cmdNouvellePartie.TabIndex = 0;
            this.MaximizeBox = false;
            this.pbPacman.Visible = false;
            this.Name = "Menu";
        }
        #endregion constructors

        #region accessors and mutators
        #endregion accessors and mutators

        #region public methods
        #endregion public methods

        #region private methods
        private void cmdRegles_MouseEnter(object sender, EventArgs e)
        {
            this.lblRegles.Visible = true;
        }

        private void cmdRegles_MouseLeave(object sender, EventArgs e)
        {
            this.lblRegles.Visible = false;
        }

        private void cmdNouvellePartie_MouseEnter(object sender, EventArgs e)
        {
            this.pbPacman.Visible = true;
        }

        private void cmdNouvellePartie_MouseLeave(object sender, EventArgs e)
        {
            this.pbPacman.Visible = false;
        }

        private void cmdScores_MouseEnter(object sender, EventArgs e)
        {

        }

        private void cmdScores_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cmdNouvellePartie_Click(object sender, EventArgs e)
        {
            _frmJeu = new frmJeu();
            _frmJeu.Show(this);
        }
        #endregion private methods



    }
}
