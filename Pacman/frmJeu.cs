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
    /// classe du form jeu
    /// grâce à elle on pourra afficher le jeu 
    /// </summary>
    public partial class frmJeu : Form
    {
        #region private attributes
        private ClassPacman _pacman;
        private PictureBox _pacmanImage;
        private Map _classMap;
        private int _vitessePacman=20;
        private int _positionX=6;
        private int _positionY=10;
        private int _coins=0;
        private int _ghostEaten=0;
        private int _life=3;
        private int _actualisation = 0;
        private string _orientationPacman = "Ouest";
        private bool _Nord = false;
        private bool _Est = false;
        private bool _Ouest = false;
        private bool _Sud = false;
        private int _deplacement=0;
        private int _actualisation2 = 0;
        private int _avancer = 1;
        private string _nomMap = "Map01";

        #endregion private attributes

        #region constructors
        /// <summary>
        /// via le constructeur, nous allons créer l'objet pacman, les 4 fantômes,
        /// et regler les different paramètres de la form du jeu.
        /// </summary>
        public frmJeu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = new Size(794, 606);
            this.MinimumSize = new Size(794, 606);
            this.MaximizeBox = false;
            this.Name = "Jeu";
            _pacman = new ClassPacman(_vitessePacman, _positionX, _positionY, _life, _coins, _ghostEaten);
            _pacmanImage = new PictureBox();
            _pacmanImage.Image = Pacman.Properties.Resources.gauche;
            _pacmanImage.SizeMode = PictureBoxSizeMode.StretchImage;
            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
            _pacmanImage.Size = new Size(21, 21);
            this.Controls.Add(_pacmanImage);
            timerDeplacement.Start();
            _classMap = new Map(_nomMap);
        }

        #endregion constructors

        #region accessors and mutators
        #endregion accessors and mutators

        #region public methods
        #endregion public methods

        #region private methods
        #endregion private methods
        /// <summary>
        /// timeur qui va incrémenter une variable pour qu'à un certain moment
        /// on lise la nouvelle direction que nous donnons à pacman,
        /// on aura aussi un affichage graphique de pacman au lieu d'avoir un déplacement de case en case(comme si 
        /// on déplaçait pacman dans un tableau)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDeplacement_Tick(object sender, EventArgs e)
        {
            if (_Nord) _orientationPacman = "Nord";
            if (_Sud) _orientationPacman = "Sud";
            if (_Ouest) _orientationPacman = "Ouest";
            if (_Est) _orientationPacman = "Est";
            if (_avancer == 1)
            {
                _actualisation++;
                _actualisation2++;
                if (_actualisation2 == _pacman.vitesse / 20)
                {
                    _deplacement += 1;
                    switch (_pacman.orientation)
                    {
                        case "Nord":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph - _deplacement);
                            break;
                        case "Sud":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph + _deplacement);
                            break;
                        case "Ouest":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph - _deplacement, _pacman.positionYGraph);
                            break;
                        case "Est":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph + _deplacement, _pacman.positionYGraph);
                            break;
                    }
                    _actualisation2 = 0;
                }
                if (_actualisation == _pacman.vitesse)
                {
                    _pacman.DeplacementPacman(this._orientationPacman);
                    switch (_pacman.orientation)
                    {
                        case "Nord":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                            _pacmanImage.Image = global::Pacman.Properties.Resources.haut;
                            break;
                        case "Sud":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                            _pacmanImage.Image = global::Pacman.Properties.Resources.bas;
                            break;
                        case "Ouest":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                            _pacmanImage.Image = global::Pacman.Properties.Resources.gauche;
                            break;
                        case "Est":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                            _pacmanImage.Image = global::Pacman.Properties.Resources.droite;
                            break;
                    }
                    _actualisation = 0;
                    _deplacement = 0;
                }
            }
            else
            {
                _pacman.DeplacementPacman(this._orientationPacman);
                switch (_pacman.orientation)
                {
                    case "Nord":
                        _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                        _pacmanImage.Image = global::Pacman.Properties.Resources.haut;
                        break;
                    case "Sud":
                        _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                        _pacmanImage.Image = global::Pacman.Properties.Resources.bas;
                        break;
                    case "Ouest":
                        _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                        _pacmanImage.Image = global::Pacman.Properties.Resources.gauche;
                        break;
                    case "Est":
                        _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                        _pacmanImage.Image = global::Pacman.Properties.Resources.droite;
                        break;
                }
            }
            _avancer = _pacman.avancer();
        }

        /// <summary>
        /// pour chaque touche pressée nous retournons un vrai ou faux qui sera lu part le timeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">evenement des touches du clavier</param>
        private void frmJeu_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    _Nord = true;
                    _Est = false;
                    _Ouest = false;
                    _Sud = false;
                    break;
                case Keys.Left:
                    _Nord = false;
                    _Est = false;
                    _Ouest = true;
                    _Sud = false;
                    break;
                case Keys.Right:
                    _Nord = false;
                    _Est = true;
                    _Ouest = false;
                    _Sud = false;
                    break;
                case Keys.Down:
                    _Nord = false;
                    _Est = false;
                    _Ouest = false;
                    _Sud = true;
                    break;
                default:
                    break;
            }
        }
        
    }
}
