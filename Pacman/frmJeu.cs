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
        private int _positionX;
        private int _positionY;
        private int _coins=0;
        private int _ghostEaten=0;
        private int _life=3;
        private int _actualisation = 0;
        private string _orientationPacman = "Nord";
        private bool _Nord = false;
        private bool _Est = false;
        private bool _Ouest = false;
        private bool _Sud = false;
        private int _deplacement=0;
        private int _actualisation2 = 0;
        private int _avancer = 1;
        private string _nomMap = "Map01";
        private int[,] _map;
        private int _nbPieces;
        private int _pieceRestantes;
        private bool _nouvelleMap = true;
        private PictureBox[] _piece;
        private Label lblPiecesRestantes = new Label();


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
            this.MaximumSize = new Size(778, 606);
            this.MinimumSize = new Size(778, 606);
            this.MaximizeBox = false;
            this.Name = "Jeu";
            lblPiecesRestantes.Location = new Point(200,540);
            lblPiecesRestantes.AutoSize = true;
            lblPiecesRestantes.Text = "bonjour!";
            Controls.Add(lblPiecesRestantes);
            gestionMap();
            timerDeplacement.Start();
        }

        #endregion constructors

        #region accessors and mutators
        #endregion accessors and mutators

        #region public methods
        #endregion public methods

        #region private methods
        private void gestionMap()
        {
            int i = 0;
            int a = 0;
            int x;
            int y;
            if (_nouvelleMap)
            {
                _classMap = new Map(_nomMap);
                _map = _classMap.map;
                for (y = 0; y <= 19; y++)
                {
                    for (x = 0; x <= 37; x++)
                    {
                        if (_map[y, x] == 4)
                        {
                            _positionY = y;
                            _positionX = x;
                        }
                    }
                }
                _pacman = new ClassPacman(_vitessePacman, _positionX, _positionY, _life, _coins, _ghostEaten, _map);
                _pacmanImage = new PictureBox();
                _pacmanImage.Image = Pacman.Properties.Resources.gauche;
                _pacmanImage.SizeMode = PictureBoxSizeMode.StretchImage;
                _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                _pacmanImage.Size = new Size(21, 21);
                this.Controls.Add(_pacmanImage);
                _nbPieces = _classMap.NbPiece();
                _piece = new PictureBox[_nbPieces];
                PictureBox[] _mur;
                _mur = new PictureBox[_classMap.NbMurs()];
                for (y = 0; y <= 19; y++)
                {
                    for (x = 0; x <= 37; x++)
                    {
                        if (_map[y, x] == 1)
                        {
                            _mur[i] = new PictureBox();
                            _mur[i].Location = new Point(x * 20, y * 20);
                            _mur[i].Size = new Size(21, 21);
                            _mur[i].BackColor = Color.Black;
                            this.Controls.Add(_mur[i]);
                            i++;
                        }
                        if (_map[y, x] == 2 || _map[y, x] == 3)
                        {
                            _piece[a] = new PictureBox();
                            _piece[a].Location = new Point(x * 20, y * 20);
                            _piece[a].Size = new Size(21, 21);
                            _piece[a].SizeMode = PictureBoxSizeMode.StretchImage;
                            if(_map[y, x] == 2) _piece[a].Image = Pacman.Properties.Resources.piece;
                            else _piece[a].Image = Pacman.Properties.Resources.superPiece;
                            this.Controls.Add(_piece[a]);
                            a++;
                        }
                    }
                }
                _pieceRestantes = _nbPieces;
                _nouvelleMap = false;
            }
            else
            {
                if(_map[_pacman.positionY, _pacman.positionX] == 2 || _map[_pacman.positionY, _pacman.positionX] == 3)
                {
                    for(a=0;a<_nbPieces;a++)
                    {
                        if (_piece[a].Location == _pacmanImage.Location) this.Controls.Remove(_piece[a]);
                    }
                    _pieceRestantes = _pacman.PiecesRestantes();
                }
            }
            lblPiecesRestantes.Text = _pieceRestantes.ToString(); if (_pieceRestantes == 0)
            {
                timerDeplacement.Stop();
                if (DialogResult.No == MessageBox.Show("Vous avez attrapé toutes les pièces voulez vous recommencer?", "Fin de partie", MessageBoxButtons.YesNo)) this.Close();
                _nouvelleMap = true;
                this.Controls.Remove(_pacmanImage);
                timerDeplacement.Start();
            }
        }
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
                    gestionMap();
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
        #endregion private methods
    }
}
