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
    /// <summary>
    /// clase du form menu
    /// qui contiendra l'essentiel avant de lancer une partie
    /// alias le score, les règles et la possibilité de jouer une nouvelle partie
    /// </summary>
    public partial class FrmMenu : Form
    {
        #region private attributes
        private frmJeu _frmJeu;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// via le constructeur du form menu, nous allons la centrer au centre de l'écran,
        /// définir sa taille maximale et minimale,
        /// cacher les labels et pictures box et la nommer.
        /// </summary>
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

        /// <summary>
        /// quand la souris passera sur un bouton un label(règles ou scores) ou une picturebox(nouvelle partie) 
        /// s'affichera et inversement quand la souris sortira du bouton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// quand on cliquera sur nouvelle partie on lancera le form du jeu "frmJeu"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNouvellePartie_Click(object sender, EventArgs e)
        {
            _frmJeu = new frmJeu();
            _frmJeu.Show(this);
        }
        #endregion private methods        
    }
}
