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
    public partial class frmJeu : Form
    {
        #region private attributes
        private ClassPacman _pacman;
        private PictureBox _pacmanImage;
        private int _vitesse=10;
        private int _positionX=6;
        private int _positionY=10;
        private int _coins=0;
        private int _ghostEaten=0;
        private int _life=3;
        private int _actualisation = 0;
        private string _orientationPacman = "Ouest";

        #endregion private attributes

        #region constructors
        public frmJeu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = new Size(794, 606);
            this.MinimumSize = new Size(794, 606);
            this.MaximizeBox = false;
            this.Name = "Jeu";
            _pacman = new ClassPacman(_vitesse, _positionX, _positionY, _life, _coins, _ghostEaten);
            _pacmanImage = new PictureBox();
            _pacmanImage.BackColor = Color.Black;
            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
            _pacmanImage.Size = new Size(21, 21);
            this.Controls.Add(_pacmanImage);
            timerDeplacement.Start();
        }

        #endregion constructors

        #region accessors and mutators
        #endregion accessors and mutators

        #region public methods
        #endregion public methods

        #region private methods
        private void frmJeu_Load(object sender, EventArgs e)
        {

        }
        #endregion private methods

        private void timerDeplacement_Tick(object sender, EventArgs e)
        {
            _actualisation++;
            if(_actualisation == 100)
            {
                _pacman.DeplacementPacman(this._orientationPacman);
                _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                _actualisation = 0;
            }
        }
    }
}
