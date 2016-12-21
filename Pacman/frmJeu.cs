using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;


namespace Pacman
{
    /// <summary>
    /// classe du form jeu "frmJeu"
    /// grâce à elle on pourra afficher le jeu 
    /// </summary>
    public partial class frmJeu : Form
    {
        #region private attributes
        private ClassPacman _pacman;
        private Map _classMap;
        private PictureBox _pacmanImage;
        private PictureBox _interface_vie;
        private PictureBox[] _piece;
        private Point _positionPacman;
        private Label lblNbPac_gomme;//240 435
        private Label lblNbSuperPac_gomme;
        private int _actualisation = 0;
        private int _actualisation2 = 0;
        private int _deplacement = 0;
        private int _ghostEaten=0;
        private int _life=3;
        private string _orientationPacman = "Nord";
        private string _nomMap = "Map01";
        private bool _Nord = false;
        private bool _Est = false;
        private bool _Ouest = false;
        private bool _Sud = false;
        private bool _nouvelleMap = true;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// via le constructeur, nous allons créer l'objet pacman, les 4 fantômes, le labyrinthe
        /// et regler les different paramètres de la form de jeu.
        /// </summary>
        public frmJeu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = new Size(777, 606);
            this.MinimumSize = new Size(777, 606);
            this.MaximizeBox = false;
            this.Name = "Jeu";
            this.BackColor = Color.Black;
            try
            {
                gestionMap();
                timerDeplacement.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show("Veuillez créer une Map01.txt dans le dossier Map\n faites une map de 20→ sur 39↓:\n\nChiffres à Utiliser:\n\n 1=mur,\n 2=pac-gomme,\n 3=super pac-gomme\n 4=pacman,\n 5-8=fantômes,\n 9=mur invisible pour la sortie des fantômes", "Fichier inexistant", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            }
            
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
                lblNbPac_gomme = new Label();
                lblNbSuperPac_gomme = new Label();
                //mise en place des icones de base
                _interface_vie = new PictureBox();
                _interface_vie.Image = Pacman.Properties.Resources._3vies;
                _interface_vie.Location = new Point(11, 425);
                _interface_vie.Size = new Size(169, 61);
                //mise en place des icones de base et l'interface
                PictureBox _interface_icones = new PictureBox();
                _interface_icones.Image = Pacman.Properties.Resources.Icones_Interface2;
                _interface_icones.Location = new Point(0, 401);
                _interface_icones.Size = new Size(768, 167);
                _interface_icones.BackgroundImage= Pacman.Properties.Resources.Interface_Bas;
                _interface_icones.BackColor = Color.Transparent;

                int vitessePacman = 20;
                _classMap = new Map(_nomMap);
                _pacman = new ClassPacman(vitessePacman, _life, _ghostEaten, _classMap.map);
;                _pacmanImage = new PictureBox();
                _pacmanImage.Image = Pacman.Properties.Resources.haut;
                _pacmanImage.SizeMode = PictureBoxSizeMode.StretchImage;
                _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                _pacmanImage.Size = new Size(20, 20);
                this.Controls.Add(_pacmanImage);

                lblNbPac_gomme.Location = new Point(213, 430);
                lblNbPac_gomme.ForeColor = Color.Yellow;
                lblNbPac_gomme.Font = new Font("Modern No. 20", 36, FontStyle.Regular);
                lblNbPac_gomme.BackColor = Color.Transparent;
                lblNbPac_gomme.Text = _pacman.pac_gome.ToString();
                lblNbPac_gomme.AutoSize = true;

                lblNbSuperPac_gomme.Location = new Point(416, 430);
                lblNbSuperPac_gomme.ForeColor = Color.Yellow;
                lblNbSuperPac_gomme.Font = new Font("Modern No. 20", 36, FontStyle.Regular);
                lblNbSuperPac_gomme.BackColor = Color.Transparent;
                lblNbSuperPac_gomme.Text = _pacman.superPac_gome.ToString();
                lblNbSuperPac_gomme.AutoSize = true;

                this.Controls.Add(_interface_vie);
                this.Controls.Add(lblNbPac_gomme);
                this.Controls.Add(lblNbSuperPac_gomme);
                this.Controls.Add(_interface_icones);

                _piece = new PictureBox[_classMap.NbPiece()];
                PictureBox[] _mur;
                _mur = new PictureBox[_classMap.NbMurs()];
                for (y = 0; y <= 19; y++)
                {
                    for (x = 0; x <= 37; x++)
                    {
                        if (_classMap.map[y, x] == 1)
                        {
                            _mur[i] = new PictureBox();
                            _mur[i].Location = new Point(x * 20, y * 20);
                            _mur[i].Size = new Size(20, 20);
                            _mur[i].SizeMode = PictureBoxSizeMode.StretchImage;
                            _mur[i].Image = Pacman.Properties.Resources.mur2;
                            this.Controls.Add(_mur[i]);
                            i++;
                        }
                        if (_classMap.map[y, x] == 2 || _classMap.map[y, x] == 3)
                        {
                            _piece[a] = new PictureBox();
                            _piece[a].Location = new Point(x * 20, y * 20);
                            _piece[a].Size = new Size(20, 20);
                            _piece[a].SizeMode = PictureBoxSizeMode.StretchImage;
                            if(_classMap.map[y, x] == 2) _piece[a].Image = Pacman.Properties.Resources.piece;
                            else _piece[a].Image = Pacman.Properties.Resources.superPiece;
                            this.Controls.Add(_piece[a]);
                            a++;
                        }
                    }
                }
                _nouvelleMap = false;
            }
            else
            {
                if(_classMap.map[_pacman.positionY, _pacman.positionX] == 2 || _classMap.map[_pacman.positionY, _pacman.positionX] == 3)
                {
                    foreach(PictureBox removePicture in this._piece)
                    {
                        if(removePicture.Location == _positionPacman) this.Controls.Remove(removePicture);
                    }
                }
            }
            _pacman.PiecesRestantes();
            lblNbPac_gomme.Text = _pacman.pac_gome.ToString();
            lblNbSuperPac_gomme.Text = _pacman.superPac_gome.ToString();
            if (_pacman.NbPiecesRestantes == 0)
            {
                timerDeplacement.Stop();
                if (DialogResult.No == MessageBox.Show("Vous avez attrapé toutes les pièces voulez vous recommencer?", "Fin de partie", MessageBoxButtons.YesNo)) this.Close();
                _nouvelleMap = true;
                this.Controls.Clear();
                timerDeplacement.Start();
            }
        }

        private void timerDeplacement_Tick(object sender, EventArgs e)
        {
            if (_Nord) _orientationPacman = "Nord";
            if (_Sud) _orientationPacman = "Sud";
            if (_Ouest) _orientationPacman = "Ouest";
            if (_Est) _orientationPacman = "Est";
            if (_pacman.avancer() == 1)
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
                    _positionPacman = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                    gestionMap();
                    switch (_pacman.orientation)
                    {
                        case "Nord":
                            _pacmanImage.Image = global::Pacman.Properties.Resources.haut;
                            break;
                        case "Sud":
                            _pacmanImage.Image = global::Pacman.Properties.Resources.bas;
                            break;
                        case "Ouest":
                            _pacmanImage.Image = global::Pacman.Properties.Resources.gauche;
                            break;
                        case "Est":
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
        }
        
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
