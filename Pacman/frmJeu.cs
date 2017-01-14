using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private Clyde _clyde;
        private Blinky _blinky;
        private Pinky _pinky;
        private Inky _inky;
        private Map _classMap;
        private PictureBox _pacmanImage;
        private PictureBox _clydeImage;
        private PictureBox _blinkyImage;
        private PictureBox _pinkyImage;
        private PictureBox _inkyImage;
        private PictureBox _interface_vie;
        private Label _lblNbPac_gomme;
        private Label _lblNbSuperPac_gomme;
        private Label _lblNbFantomes;
        private PictureBox[] _piece;
        private Point _positionPacman;
        protected int _totalScore;
        private int _actualisation = 0;
        private int _actualisation2 = 0;
        private int _deplacementPacman = 0;
        private int _actualisationClyde = 0;
        private int _deplacementClyde = 0;
        private int _actualisationBlinky = 0;
        private int _deplacementBlinky = 0;
        private int _actualisationPinky = 0;
        private int _deplacementPinky = 0;
        private int _actualisationInky = 0;
        private int _deplacementInky = 0;
        private int _life=3;
        private int _superPacman = 0;
        private int _blinkyFuite = 0;
        private string _orientationPacman = "Nord";
        private string _orientationClyde;
        private string _orientationBlinky;
        private string _orientationPinky;
        private string _orientationInky;
        private string _nomMap = "MapGlace";
        private bool _Nord = false;
        private bool _Est = false;
        private bool _Ouest = false;
        private bool _Sud = false;
        private bool _nouvelleMap = true;
        private bool _recommencer = true;
        private bool _rechargerMap = false;
        
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

            int rand;

            Random randomMap = new Random();
            rand = randomMap.Next(0, 3);

            switch(rand)
            {
                case 0:
                    _nomMap = "Map01";
                    break;
                case 1:
                    _nomMap = "Map02";
                    break;
                case 2:
                    _nomMap = "MapGlace";
                    break;
            }

            switch(_nomMap)
            {
                case "MapGlace":
                    this.BackColor = Color.CornflowerBlue;
                    break;
                case "MapFeu":
                    this.BackColor = Color.DarkRed;
                    break;
                default:
                    this.BackColor = Color.Black;
                    break;
            }

            try
            {
                gestionMap();
            }
            catch (Exception s)
            {
                MessageBox.Show("Veuillez créer une Map01.txt dans le dossier Map\n faites une map de 20→ sur 39↓:\n\nChiffres à Utiliser:\n\n 1=mur,\n 2=pac-gomme,\n 3=super pac-gomme\n 4=pacman,\n 5-8=fantômes,\n 9=mur invisible pour la sortie des fantômes", "Fichier inexistant", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
            do
            {
                int i = 0;
                int a = 0;
                int x;
                int y;
                if (_nouvelleMap)
                {
                    int vitesse = 20;
                    if (_recommencer)
                    {
                        switch (_nomMap)
                        {
                            case "MapGlace":
                                this.BackColor = Color.CornflowerBlue;
                                break;
                            case "MapFeu":
                                this.BackColor = Color.DarkRed;
                                break;
                            default:
                                this.BackColor = Color.Black;
                                break;
                        }
                        _lblNbPac_gomme = new Label();
                        _lblNbSuperPac_gomme = new Label();
                        _lblNbFantomes = new Label();
                        _classMap = new Map(_nomMap);
                        _recommencer = false;

                        _pacman = new ClassPacman(vitesse, _life, _classMap.map);
                        _pacmanImage = new PictureBox();
                        _pacmanImage.Image = Pacman.Properties.Resources.haut;
                        _pacmanImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        _pacmanImage.Size = new Size(20, 20);
                    }
                    if(_rechargerMap)
                    {
                        _rechargerMap = false;

                        int rand;
                        string nomMap = _nomMap;
                        
                        while(_nomMap == nomMap)
                        {
                            Random randomMap = new Random();
                            rand = randomMap.Next(0, 3);


                            switch (rand)
                            {
                                case 0:
                                    _nomMap = "Map01";
                                    break;
                                case 1:
                                    _nomMap = "Map02";
                                    break;
                                case 2:
                                    _nomMap = "MapGlace";
                                    break;
                            }
                        }

                        _classMap = new Map(_nomMap);
                        _pacman.ResetPiecesMap(_classMap.map, _classMap.NbPiece());

                        _pacmanImage = new PictureBox();
                        _pacmanImage.Image = Pacman.Properties.Resources.haut;
                        _pacmanImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        _pacmanImage.Size = new Size(20, 20);

                        _orientationPacman = "Nord";
                        _pacman.DeplacementPacman(_orientationPacman);
                        _Nord = true;
                        _Sud = false;
                        _Est = false;
                        _Ouest = false;
                    }
                    _pacman.replacement();
                    _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph);
                    //mise en place des icones de base
                    _interface_vie = new PictureBox();
                    switch(_life)
                    {
                        case 1:
                            _interface_vie.Image = Pacman.Properties.Resources._1vies;
                            break;
                        case 2:
                            _interface_vie.Image = Pacman.Properties.Resources._2vies;
                            break;
                        case 3:
                            _interface_vie.Image = Pacman.Properties.Resources._3vies;
                            break;
                        default:
                            _interface_vie.Image = Pacman.Properties.Resources._0vies;
                            break;
                    }
                    _interface_vie.Location = new Point(11, 425);
                    _interface_vie.Size = new Size(169, 61);
                    //mise en place des icones de base et l'interface
                    PictureBox _interface_icones = new PictureBox();
                    _interface_icones.Image = Pacman.Properties.Resources.Icones_Interface2;
                    _interface_icones.Location = new Point(0, 401);
                    _interface_icones.Size = new Size(768, 167);
                    _interface_icones.BackgroundImage = Pacman.Properties.Resources.Interface_Bas;
                    _interface_icones.BackColor = Color.Transparent;

                    _lblNbPac_gomme.Location = new Point(213, 430);
                    _lblNbPac_gomme.ForeColor = Color.Yellow;
                    _lblNbPac_gomme.Font = new Font("Modern No. 20", 36, FontStyle.Regular);
                    _lblNbPac_gomme.BackColor = Color.Transparent;
                    _lblNbPac_gomme.Text = _pacman.pac_gome.ToString();
                    _lblNbPac_gomme.AutoSize = true;

                    _lblNbSuperPac_gomme.Location = new Point(416, 430);
                    _lblNbSuperPac_gomme.ForeColor = Color.Yellow;
                    _lblNbSuperPac_gomme.Font = new Font("Modern No. 20", 36, FontStyle.Regular);
                    _lblNbSuperPac_gomme.BackColor = Color.Transparent;
                    _lblNbSuperPac_gomme.Text = _pacman.superPac_gome.ToString();
                    _lblNbSuperPac_gomme.AutoSize = true;

                    _lblNbFantomes.Location = new Point(600, 430);
                    _lblNbFantomes.ForeColor = Color.Yellow;
                    _lblNbFantomes.Font = new Font("Modern No. 20", 36, FontStyle.Regular);
                    _lblNbFantomes.BackColor = Color.Transparent;
                    _lblNbFantomes.Text = _pacman.ghostEaten.ToString();
                    _lblNbFantomes.AutoSize = true;


                    _clyde = new Clyde(vitesse, _classMap.map);
                    _clydeImage = new PictureBox();
                    _clydeImage.Image = Pacman.Properties.Resources.orange_haut;
                    _clydeImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph);
                    _clydeImage.Size = new Size(20, 20);

                    _blinky = new Blinky(vitesse, _classMap.map);
                    _blinkyImage = new PictureBox();
                    _blinkyImage.Image = Pacman.Properties.Resources.rouge;
                    _blinkyImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph);
                    _blinkyImage.Size = new Size(20, 20);

                    _pinky = new Pinky(vitesse, _classMap.map);
                    _pinkyImage = new PictureBox();
                    _pinkyImage.Image = Pacman.Properties.Resources.pink_haut;
                    _pinkyImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph);
                    _pinkyImage.Size = new Size(20, 20);

                    _inky = new Inky(vitesse, _classMap.map);
                    _inkyImage = new PictureBox();
                    _inkyImage.Image = Pacman.Properties.Resources.bleu_haut;
                    _inkyImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph);
                    _inkyImage.Size = new Size(20, 20);

                    this.Controls.Add(_pacmanImage);
                    this.Controls.Add(_interface_vie);
                    this.Controls.Add(_lblNbPac_gomme);
                    this.Controls.Add(_lblNbSuperPac_gomme);
                    this.Controls.Add(_lblNbFantomes);
                    this.Controls.Add(_interface_icones);
                    this.Controls.Add(_clydeImage);
                    this.Controls.Add(_blinkyImage);
                    this.Controls.Add(_pinkyImage);
                    this.Controls.Add(_inkyImage);

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
                                if (_nomMap == "Map01") _mur[i].Image = Pacman.Properties.Resources.mur2;
                                else if (_nomMap == "Map02") _mur[i].Image = Pacman.Properties.Resources.mur;
                                else if (_nomMap == "Map03") _mur[i].Image = Pacman.Properties.Resources.murBase;
                                else if (_nomMap == "Map04") _mur[i].Image = Pacman.Properties.Resources.MUR4;
                                else if (_nomMap == "Map05") _mur[i].Image = Pacman.Properties.Resources.MUR5;
                                else if (_nomMap == "MapGlace") _mur[i].Image = Pacman.Properties.Resources.MurGlace;
                                else if (_nomMap == "MapFeu") _mur[i].Image = Pacman.Properties.Resources.MurFeu;
                                this.Controls.Add(_mur[i]);
                                i++;
                            }
                            if (_classMap.map[y, x] == 2 || _classMap.map[y, x] == 3)
                            {
                                _piece[a] = new PictureBox();
                                _piece[a].Location = new Point(x * 20, y * 20);
                                _piece[a].Size = new Size(20, 20);
                                _piece[a].SizeMode = PictureBoxSizeMode.StretchImage;
                                if (_classMap.map[y, x] == 2) _piece[a].Image = Pacman.Properties.Resources.piece;
                                else _piece[a].Image = Pacman.Properties.Resources.superPiece;
                                this.Controls.Add(_piece[a]);
                                a++;
                            }
                        }
                    }
                    _nouvelleMap = false;
                    _actualisation = 0;
                    _actualisation2 = 0;
                    _deplacementPacman = 0;
                    timerDeplacement.Start();
                    _actualisationClyde = 0;
                    _deplacementClyde = 0;
                    timerClydeSortirCage.Start();
                    _actualisationBlinky = 0;
                    _deplacementBlinky = 0;
                    timerBlinkySortirCage.Start();
                    _actualisationPinky = 0;
                    _deplacementPinky = 0;
                    timerPinkySortirCage.Start();
                    _actualisationInky = 0;
                    _deplacementInky = 0;
                    timerInkySortirCage.Start();
                }
                else
                {
                    
                    if (_classMap.map[_pacman.positionY, _pacman.positionX] == 2 || _classMap.map[_pacman.positionY, _pacman.positionX] == 3)
                    {
                        foreach (PictureBox removePicture in this._piece)
                        {
                            if (removePicture.Location == _positionPacman) this.Controls.Remove(removePicture);
                            
                        }
                        if (_classMap.map[_pacman.positionY, _pacman.positionX] == 3)
                        {
                            if (timeSuperPacman.Enabled == true) timeSuperPacman.Stop();
                            _superPacman = 1;
                            _blinkyFuite = 1;
                            _blinky.RandomDirection();
                            _pinky.RandomDirection();
                            _inky.RandomDirection();
                            
                            timeSuperPacman.Start();
                        }
                    }
                    _pacman.PiecesRestantes();
                    _lblNbPac_gomme.Text = _pacman.pac_gome.ToString();
                    _lblNbSuperPac_gomme.Text = _pacman.superPac_gome.ToString();
                    _lblNbFantomes.Text = _pacman.ghostEaten.ToString();
                    int lifeTemp = _life;
                    if (_pacman.collisionGhost(_clyde.orientationClyde, _clyde.positionX, _clyde.positionY) == 1 || 
                        _pacman.collisionGhost(_blinky.orientationBlinky, _blinky.positionX, _blinky.positionY) == 1 ||
                        _pacman.collisionGhost(_pinky.orientationPinky, _pinky.positionX, _pinky.positionY) == 1 ||
                        _pacman.collisionGhost(_inky.orientationInky, _inky.positionX, _inky.positionY) == 1)
                    {
                        if (_superPacman == 1)
                        {
                            if (_pacman.collisionGhost(_clyde.orientationClyde, _clyde.positionX, _clyde.positionY) == 1)
                            {
                                if (timerClyde.Enabled == true) _pacman.GhostEatenAdd();
                                timerClyde.Stop();

                                _actualisationClyde = 0;
                                _deplacementClyde = 0;

                                timerClydeRetourneCage.Start();
                            }

                            if (_pacman.collisionGhost(_blinky.orientationBlinky, _blinky.positionX, _blinky.positionY) == 1)
                            {
                                if (timerBlinky.Enabled == true) _pacman.GhostEatenAdd();
                                timerBlinky.Stop();

                                _actualisationBlinky = 0;
                                _deplacementBlinky = 0;

                                _blinkyImage.Image = Pacman.Properties.Resources.yeux_blinky;
                                timerBlinkyRetourneCage.Start();
                            }

                            if (_pacman.collisionGhost(_pinky.orientationPinky, _pinky.positionX, _pinky.positionY) == 1)
                            {
                                if (timerPinky.Enabled == true) _pacman.GhostEatenAdd();
                                timerPinky.Stop();

                                _actualisationPinky = 0;
                                _deplacementPinky = 0;

                                timerPinkyRetourneCage.Start();
                            }

                            if (_pacman.collisionGhost(_inky.orientationInky, _inky.positionX, _inky.positionY) == 1)
                            {
                                if (timerInky.Enabled == true) _pacman.GhostEatenAdd();
                                timerInky.Stop();

                                _actualisationInky = 0;
                                _deplacementInky = 0;

                                timerInkyRetourneCage.Start();
                            }
                        }
                        else
                        {
                            _life--;
                            _pacman.DeplacementPacman("Nord");
                            _Nord = true;
                            _Sud = false;
                            _Est = false;
                            _Ouest = false;
                        }
                    }
                    if (_life != lifeTemp || _pacman.NbPiecesRestantes == 0)
                    {
                        timerBlinky.Stop();
                        timerPinky.Stop();
                        timerInky.Stop();
                        timerClyde.Stop();
                        timerDeplacement.Stop();
                        if(_life==0)
                        {
                            _totalScore = _pacman.ScoreTotal();
                            FrmInputMessageBox inputMessageBox = new FrmInputMessageBox(_totalScore);
                            inputMessageBox.ShowDialog();
                            break;
                            if (DialogResult.No == MessageBox.Show("Votre score est de " + _totalScore.ToString() + "\n voulez vous recommencer?", "Fin de partie", MessageBoxButtons.YesNo))
                            {
                                this.Close();
                                break;
                            }
                            _life = 3;
                            _recommencer = true;
                        }
                        if(_pacman.NbPiecesRestantes == 0)
                        {
                            _rechargerMap = true;
                        }
                        _nouvelleMap = true;
                        this.Controls.Clear();
                    }
                }
            } while (_nouvelleMap);
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
                    _deplacementPacman += 1;
                    switch (_pacman.orientation)
                    {
                        case "Nord":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph - _deplacementPacman);
                            break;
                        case "Sud":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph, _pacman.positionYGraph + _deplacementPacman);
                            break;
                        case "Ouest":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph - _deplacementPacman, _pacman.positionYGraph);
                            break;
                        case "Est":
                            _pacmanImage.Location = new Point(_pacman.positionXGraph + _deplacementPacman, _pacman.positionYGraph);
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
                    _deplacementPacman = 0;
                }
            }
            else
            {
                _actualisation++;
                if (_actualisation == _pacman.vitesse)
                {
                    _pacman.DeplacementPacman(this._orientationPacman);
                    _actualisation = 0;
                    _actualisation2 = 0;
                    gestionMap();
                }

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
            }
        }
        private void timerClydeSortirCage_Tick(object sender, EventArgs e)
        {
            _actualisationClyde++;

            if (_actualisationClyde > 0)
            {
                if (_actualisationClyde <= _clyde.vitesse)
                {
                    _orientationClyde = "Nord";

                    _clydeImage.Image = Pacman.Properties.Resources.orange_haut;
                    _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph - _deplacementClyde);
                }
                else if (_actualisationClyde <= _clyde.vitesse * 2)
                {
                    _orientationClyde = "Est";

                    _clydeImage.Image = Pacman.Properties.Resources.orange_right;
                    _clydeImage.Location = new Point(_clyde.positionXGraph + _deplacementClyde, _clyde.positionYGraph);
                }
                else if (_actualisationClyde <= _clyde.vitesse * 4)
                {
                    _orientationClyde = "Nord";

                    _clydeImage.Image = Pacman.Properties.Resources.orange_haut;
                    _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph - _deplacementClyde);
                }
                _deplacementClyde++;

                if (_actualisationClyde == _clyde.vitesse || _actualisationClyde == _clyde.vitesse * 3)
                {
                    _deplacementClyde = 0;
                    _clyde.AvancerDirection(_orientationClyde);
                }
                else if (_actualisationClyde == _clyde.vitesse * 2)
                {
                    _deplacementClyde = 0;
                    _clyde.AvancerDirection(_orientationClyde);
                }
                else if (_actualisationClyde == _clyde.vitesse * 4)
                {
                    _clyde.DeplacementClyde();
                    _actualisationClyde = 0;
                    _deplacementClyde = 0;
                    timerClyde.Start();
                    timerClydeSortirCage.Stop();
                }
            }
        }

        private void timerBlinkySortirCage_Tick(object sender, EventArgs e)
        {
            _actualisationBlinky++;

            if(_actualisationBlinky > 0)
            {
                if(_actualisationBlinky == 1)
                {
                    _blinkyImage.Image = Pacman.Properties.Resources.rouge;
                }
                _orientationBlinky = "Nord";

                if (_actualisationBlinky <= _blinky.vitesse * 3)
                {
                    _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph - _deplacementBlinky);
                }
                _deplacementBlinky++;

                if (_actualisationBlinky == _blinky.vitesse || _actualisationBlinky == _blinky.vitesse * 2)
                {
                    _deplacementBlinky = 0;
                    _blinky.AvancerDirection(_orientationBlinky);
                }
                else if (_actualisationBlinky == _blinky.vitesse * 3)
                {
                    _blinky.DeplacementBlinky();
                    _blinky.SuivrePacman(_pacman.positionX, _pacman.positionY);
                    _actualisationBlinky = 0;
                    _deplacementBlinky = 0;
                    timerBlinky.Start();
                    timerBlinkySortirCage.Stop();
                }
            }
        }

        private void timerPinkySortirCage_Tick(object sender, EventArgs e)
        {
            _actualisationPinky++;

            _orientationPinky = "Nord";

            if(_actualisationPinky > 0)
            {
                if(_actualisationPinky == 1)
                {
                    _pinkyImage.Image = Pacman.Properties.Resources.pink_haut;
                }

                if (_actualisationPinky <= _pinky.vitesse * 3)
                {
                    _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph - _deplacementPinky);
                }
                _deplacementPinky++;

                if (_actualisationPinky == _pinky.vitesse || _actualisationPinky == _pinky.vitesse * 2)
                {
                    _deplacementPinky = 0;
                    _pinky.AvancerDirection(_orientationPinky);
                }
                else if (_actualisationPinky == _pinky.vitesse * 3)
                {
                    _pinky.DeplacementPinky();
                    _pinky.ChangerDirectionPinky("Ouest");
                    _actualisationPinky = 0;
                    _deplacementPinky = 0;
                    timerPinky.Start();
                    timerPinkySortirCage.Stop();
                }
            }
        }

        private void timerInkySortirCage_Tick(object sender, EventArgs e)
        {
            _actualisationInky++;

            if(_actualisationInky > 0)
            {
                if(_actualisationInky == 1)
                {
                    _inkyImage.Image = Pacman.Properties.Resources.bleu_haut;
                }
                if (_actualisationInky <= _inky.vitesse)
                {
                    _orientationInky = "Nord";

                    _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph - _deplacementInky);
                }
                else if (_actualisationInky <= _inky.vitesse * 2)
                {
                    _orientationInky = "Ouest";

                    _inkyImage.Location = new Point(_inky.positionXGraph - _deplacementInky, _inky.positionYGraph);
                }
                else if (_actualisationInky <= _inky.vitesse * 4)
                {
                    _orientationInky = "Nord";

                    _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph - _deplacementInky);
                }
                _deplacementInky++;

                if (_actualisationInky == _inky.vitesse || _actualisationInky == _inky.vitesse * 3)
                {
                    _deplacementInky = 0;
                    _inky.AvancerDirection(_orientationInky);
                }
                else if (_actualisationInky == _inky.vitesse * 2)
                {
                    _deplacementInky = 0;
                    _inky.AvancerDirection(_orientationInky);
                }
                else if (_actualisationInky == _inky.vitesse * 4)
                {
                    _inky.DeplacementInky();
                    _inky.ChangerDirectionInky("Est");
                    _actualisationInky = 0;
                    _deplacementInky = 0;
                    timerInky.Start();
                    timerInkySortirCage.Stop();
                }
            }
        }

        private void timerClyde_Tick(object sender, EventArgs e)
        {
            _actualisationClyde++;
            _deplacementClyde++;

            if(_superPacman == 1)
            {
                switch (_clyde.orientationClyde)
                {
                    case "Nord":
                        _clydeImage.Image = Pacman.Properties.Resources.fuite_haut;
                        _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph - _deplacementClyde);
                        break;
                    case "Sud":
                        _clydeImage.Image = Pacman.Properties.Resources.fuite_bas;
                        _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph + _deplacementClyde);
                        break;
                    case "Est":
                        _clydeImage.Image = Pacman.Properties.Resources.fuite_doite;
                        _clydeImage.Location = new Point(_clyde.positionXGraph + _deplacementClyde, _clyde.positionYGraph);
                        break;
                    case "Ouest":
                        _clydeImage.Image = Pacman.Properties.Resources.fuite_gauche;
                        _clydeImage.Location = new Point(_clyde.positionXGraph - _deplacementClyde, _clyde.positionYGraph);
                        break;
                }
            }

            else
            {
                switch (_clyde.orientationClyde)
                {
                    case "Nord":
                        _clydeImage.Image = Pacman.Properties.Resources.orange_haut;
                        _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph - _deplacementClyde);
                        break;
                    case "Sud":
                        _clydeImage.Image = Pacman.Properties.Resources.orange_bas;
                        _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph + _deplacementClyde);
                        break;
                    case "Est":
                        _clydeImage.Image = Pacman.Properties.Resources.orange_right;
                        _clydeImage.Location = new Point(_clyde.positionXGraph + _deplacementClyde, _clyde.positionYGraph);
                        break;
                    case "Ouest":
                        _clydeImage.Image = Pacman.Properties.Resources.orange_left;
                        _clydeImage.Location = new Point(_clyde.positionXGraph - _deplacementClyde, _clyde.positionYGraph);
                        break;
                }
            }

            if (_actualisationClyde == _clyde.vitesse)
            {
                _actualisationClyde = 0;
                _deplacementClyde = 0;
                _clyde.DeplacementClyde();
                _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph);
            }
        }

        private void timerBlinky_Tick(object sender, EventArgs e)
        {
            _actualisationBlinky++;
            _deplacementBlinky++;

            if(_superPacman == 1 && _blinkyFuite == 1)
            {
                _blinkyFuite = 0;

                _blinkyImage.Image = Pacman.Properties.Resources.fuite_blinky;
            }
            else if(_superPacman == 0 && _blinkyFuite == 1)
            {
                _blinkyFuite = 0;

                _blinkyImage.Image = Pacman.Properties.Resources.rouge;
            }

            if(_superPacman == 0)
            {
                switch (_blinky.orientationBlinky)
                {
                    case "Nord":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph - _deplacementBlinky);
                        break;
                    case "Sud":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph + _deplacementBlinky);
                        break;
                    case "Est":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph + _deplacementBlinky, _blinky.positionYGraph);
                        break;
                    case "Ouest":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph - _deplacementBlinky, _blinky.positionYGraph);
                        break;
                }

                if (_actualisationBlinky == _blinky.vitesse)
                {
                    _actualisationBlinky = 0;
                    _deplacementBlinky = 0;
                    _blinky.DeplacementBlinky();
                    _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph);
                    _blinky.SuivrePacman(_pacman.positionX, _pacman.positionY);
                }
            }
            else
            {
                switch (_blinky.orientationBlinky)
                {
                    case "Nord":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph - _deplacementBlinky);
                        break;
                    case "Sud":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph + _deplacementBlinky);
                        break;
                    case "Est":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph + _deplacementBlinky, _blinky.positionYGraph);
                        break;
                    case "Ouest":
                        _blinkyImage.Location = new Point(_blinky.positionXGraph - _deplacementBlinky, _blinky.positionYGraph);
                        break;
                }

                if (_actualisationBlinky == _blinky.vitesse)
                {
                    _actualisationBlinky = 0;
                    _deplacementBlinky = 0;
                    _blinky.DeplacementBlinky();
                    _blinky.RandomDirection();
                    _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph);
                }
            }
        }

        private void timerPinky_Tick(object sender, EventArgs e)
        {
            _actualisationPinky++;
            _deplacementPinky++;

            if(_superPacman == 0)
            {
                if (_pinky.mur == 0)
                {
                    switch (_pinky.orientationPinky)
                    {
                        case "Nord":
                            _pinkyImage.Image = Pacman.Properties.Resources.pink_haut;
                            _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph - _deplacementPinky);
                            break;
                        case "Sud":
                            _pinkyImage.Image = Pacman.Properties.Resources.pink_bas;
                            _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph + _deplacementPinky);
                            break;
                        case "Est":
                            _pinkyImage.Image = Pacman.Properties.Resources.pink_droite;
                            _pinkyImage.Location = new Point(_pinky.positionXGraph + _deplacementPinky, _pinky.positionYGraph);
                            break;
                        case "Ouest":
                            _pinkyImage.Image = Pacman.Properties.Resources.pink_left;
                            _pinkyImage.Location = new Point(_pinky.positionXGraph - _deplacementPinky, _pinky.positionYGraph);
                            break;
                    }

                    if (_actualisationPinky == _pinky.vitesse)
                    {
                        _actualisationPinky = 0;
                        _deplacementPinky = 0;
                        _pinky.DeplacementPinky();
                        _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph);
                    }
                }
                else
                {
                    if (_actualisationPinky == _pinky.vitesse)
                    {
                        _actualisationPinky = 0;
                        _deplacementPinky = 0;
                        _pinky.SuivrePacman(_pacman.positionX, _pacman.positionY);
                    }
                }
            }
            
            else
            {
                switch (_pinky.orientationPinky)
                {
                    case "Nord":
                        _pinkyImage.Image = Pacman.Properties.Resources.fuite_haut;
                        _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph - _deplacementPinky);
                        break;
                    case "Sud":
                        _pinkyImage.Image = Pacman.Properties.Resources.fuite_bas;
                        _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph + _deplacementPinky);
                        break;
                    case "Est":
                        _pinkyImage.Image = Pacman.Properties.Resources.fuite_doite;
                        _pinkyImage.Location = new Point(_pinky.positionXGraph + _deplacementPinky, _pinky.positionYGraph);
                        break;
                    case "Ouest":
                        _pinkyImage.Image = Pacman.Properties.Resources.fuite_gauche;
                        _pinkyImage.Location = new Point(_pinky.positionXGraph - _deplacementPinky, _pinky.positionYGraph);
                        break;
                }

                if (_actualisationPinky == _pinky.vitesse)
                {
                    _actualisationPinky = 0;
                    _deplacementPinky = 0;
                    _pinky.DeplacementPinky();
                    _pinky.RandomDirection();
                    _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph);
                }
            }
        }

        private void timerInky_Tick(object sender, EventArgs e)
        {
            _actualisationInky++;
            _deplacementInky++;

            if(_superPacman == 0)
            {
                if (_inky.mur == 0)
                {
                    switch (_inky.orientationInky)
                    {
                        case "Nord":
                            _inkyImage.Image = Pacman.Properties.Resources.bleu_haut;
                            _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph - _deplacementInky);
                            break;
                        case "Sud":
                            _inkyImage.Image = Pacman.Properties.Resources.bleu_bas;
                            _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph + _deplacementInky);
                            break;
                        case "Est":
                            _inkyImage.Image = Pacman.Properties.Resources.bleu_right;
                            _inkyImage.Location = new Point(_inky.positionXGraph + _deplacementInky, _inky.positionYGraph);
                            break;
                        case "Ouest":
                            _inkyImage.Image = Pacman.Properties.Resources.bleu_left;
                            _inkyImage.Location = new Point(_inky.positionXGraph - _deplacementInky, _inky.positionYGraph);
                            break;
                    }

                    if (_actualisationInky == _inky.vitesse)
                    {
                        _actualisationInky = 0;
                        _deplacementInky = 0;
                        _inky.DeplacementInky();
                        _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph);
                        _inky.SuivrePacman(_pacman.positionX, _pacman.positionY);
                    }
                }
                else
                {
                    if (_actualisationInky == _inky.vitesse)
                    {
                        _actualisationInky = 0;
                        _deplacementInky = 0;
                        _inky.SuivrePacman(_pacman.positionX, _pacman.positionY);
                    }
                }
            }
            else
            {
                switch (_inky.orientationInky)
                {
                    case "Nord":
                        _inkyImage.Image = Pacman.Properties.Resources.fuite_haut;
                        _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph - _deplacementInky);
                        break;
                    case "Sud":
                        _inkyImage.Image = Pacman.Properties.Resources.fuite_bas;
                        _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph + _deplacementInky);
                        break;
                    case "Est":
                        _inkyImage.Image = Pacman.Properties.Resources.fuite_doite;
                        _inkyImage.Location = new Point(_inky.positionXGraph + _deplacementInky, _inky.positionYGraph);
                        break;
                    case "Ouest":
                        _inkyImage.Image = Pacman.Properties.Resources.fuite_gauche;
                        _inkyImage.Location = new Point(_inky.positionXGraph - _deplacementInky, _inky.positionYGraph);
                        break;
                }

                if (_actualisationInky == _inky.vitesse)
                {
                    _actualisationInky = 0;
                    _deplacementInky = 0;
                    _inky.DeplacementInky();
                    _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph);
                    _inky.RandomDirection();
                }
            }
        }

        private void timerClydeRetourneCage_Tick(object sender, EventArgs e)
        {
            _actualisationClyde++;
            _deplacementClyde += 2;
            if(_clyde.positionY < _clyde.positionYMap)
            {
                _orientationClyde = "Sud";
            }

            else if(_clyde.positionY > _clyde.positionYMap)
            {
                _orientationClyde = "Nord";
            }

            else if (_clyde.positionX < _clyde.positionXMap)
            {
                _orientationClyde = "Est";
            }

            else if (_clyde.positionX > _clyde.positionXMap)
            {
                _orientationClyde = "Ouest";
            }

            switch (_orientationClyde)
            {
                case "Nord":
                    _clydeImage.Image = Pacman.Properties.Resources.yeux_haut;
                    _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph - _deplacementClyde);
                    break;
                case "Sud":
                    _clydeImage.Image = Pacman.Properties.Resources.yeux_bas;
                    _clydeImage.Location = new Point(_clyde.positionXGraph, _clyde.positionYGraph + _deplacementClyde);
                    break;
                case "Est":
                    _clydeImage.Image = Pacman.Properties.Resources.yeux_droite;
                    _clydeImage.Location = new Point(_clyde.positionXGraph + _deplacementClyde, _clyde.positionYGraph);
                    break;
                case "Ouest":
                    _clydeImage.Image = Pacman.Properties.Resources.yeux_gauche;
                    _clydeImage.Location = new Point(_clyde.positionXGraph - _deplacementClyde, _clyde.positionYGraph);
                    break;
            }

            if (_actualisationClyde == 10)
            {
                _clyde.AvancerDirection(_orientationClyde);
                _actualisationClyde = 0;
                _deplacementClyde = 0;

                if(_clyde.positionX == _clyde.positionXMap && _clyde.positionY == _clyde.positionYMap)
                {
                    _actualisationClyde = -200;
                    timerClydeSortirCage.Start();
                    timerClydeRetourneCage.Stop();
                }
            }
        }

        private void timerBlinkyRetourneCage_Tick(object sender, EventArgs e)
        {
            _actualisationBlinky++;
            _deplacementBlinky += 2;

            if(_blinky.positionY < _blinky.positionYMap)
            {
                _orientationBlinky = "Sud";
            }

            else if (_blinky.positionY > _blinky.positionYMap)
            {
                _orientationBlinky = "Nord";
            }

            else if (_blinky.positionX < _blinky.positionXMap)
            {
                _orientationBlinky = "Est";
            }

            else if (_blinky.positionX > _blinky.positionXMap)
            {
                _orientationBlinky = "Ouest";
            }

            switch (_orientationBlinky)
            {
                case "Nord":
                    _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph - _deplacementBlinky);
                    break;
                case "Sud":
                    _blinkyImage.Location = new Point(_blinky.positionXGraph, _blinky.positionYGraph + _deplacementBlinky);
                    break;
                case "Est":
                    _blinkyImage.Location = new Point(_blinky.positionXGraph + _deplacementBlinky, _blinky.positionYGraph);
                    break;
                case "Ouest":
                    _blinkyImage.Location = new Point(_blinky.positionXGraph - _deplacementBlinky, _blinky.positionYGraph);
                    break;
            }

            if(_actualisationBlinky == 10)
            {
                _blinky.AvancerDirection(_orientationBlinky);
                _actualisationBlinky = 0;
                _deplacementBlinky = 0;

                if(_blinky.positionX == _blinky.positionXMap && _blinky.positionY == _blinky.positionYMap)
                {
                    _actualisationBlinky = -200;
                    timerBlinkySortirCage.Start();
                    timerBlinkyRetourneCage.Stop();
                }
            }
        }

        private void timerPinkyRetourneCage_Tick(object sender, EventArgs e)
        {
            _actualisationPinky++;
            _deplacementPinky += 2;

            if (_pinky.positionY < _pinky.positionYMap)
            {
                _orientationPinky = "Sud";
            }

            else if (_pinky.positionY > _pinky.positionYMap)
            {
                _orientationPinky = "Nord";
            }

            else if (_pinky.positionX < _pinky.positionXMap)
            {
                _orientationPinky = "Est";
            }

            else if (_pinky.positionX > _pinky.positionXMap)
            {
                _orientationPinky = "Ouest";
            }

            switch (_orientationPinky)
            {
                case "Nord":
                    _pinkyImage.Image = Pacman.Properties.Resources.yeux_haut;
                    _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph - _deplacementPinky);
                    break;
                case "Sud":
                    _pinkyImage.Image = Pacman.Properties.Resources.yeux_bas;
                    _pinkyImage.Location = new Point(_pinky.positionXGraph, _pinky.positionYGraph + _deplacementPinky);
                    break;
                case "Est":
                    _pinkyImage.Image = Pacman.Properties.Resources.yeux_droite;
                    _pinkyImage.Location = new Point(_pinky.positionXGraph + _deplacementPinky, _pinky.positionYGraph);
                    break;
                case "Ouest":
                    _pinkyImage.Image = Pacman.Properties.Resources.yeux_gauche;
                    _pinkyImage.Location = new Point(_pinky.positionXGraph - _deplacementPinky, _pinky.positionYGraph);
                    break;
            }

            if (_actualisationPinky == 10)
            {
                _pinky.AvancerDirection(_orientationPinky);
                _actualisationPinky = 0;
                _deplacementPinky = 0;

                if (_pinky.positionX == _pinky.positionXMap && _pinky.positionY == _pinky.positionYMap)
                {
                    _actualisationPinky = -200;
                    timerPinkySortirCage.Start();
                    timerPinkyRetourneCage.Stop();
                }
            }
        }

        private void timerInkyRetourneCage_Tick(object sender, EventArgs e)
        {
            _actualisationInky++;
            _deplacementInky += 2;

            if (_inky.positionY < _inky.positionYMap)
            {
                _orientationInky = "Sud";
            }

            else if (_inky.positionY > _inky.positionYMap)
            {
                _orientationInky = "Nord";
            }

            else if (_inky.positionX < _inky.positionXMap)
            {
                _orientationInky = "Est";
            }

            else if (_inky.positionX > _inky.positionXMap)
            {
                _orientationInky = "Ouest";
            }

            switch (_orientationInky)
            {
                case "Nord":
                    _inkyImage.Image = Pacman.Properties.Resources.yeux_haut;
                    _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph - _deplacementInky);
                    break;
                case "Sud":
                    _inkyImage.Image = Pacman.Properties.Resources.yeux_bas;
                    _inkyImage.Location = new Point(_inky.positionXGraph, _inky.positionYGraph + _deplacementInky);
                    break;
                case "Est":
                    _inkyImage.Image = Pacman.Properties.Resources.yeux_droite;
                    _inkyImage.Location = new Point(_inky.positionXGraph + _deplacementInky, _inky.positionYGraph);
                    break;
                case "Ouest":
                    _inkyImage.Image = Pacman.Properties.Resources.yeux_gauche;
                    _inkyImage.Location = new Point(_inky.positionXGraph - _deplacementInky, _inky.positionYGraph);
                    break;
            }

            if (_actualisationInky == 10)
            {
                _inky.AvancerDirection(_orientationInky);
                _actualisationInky = 0;
                _deplacementInky = 0;

                if (_inky.positionX == _inky.positionXMap && _inky.positionY == _inky.positionYMap)
                {
                    _actualisationInky = -200;
                    timerInkySortirCage.Start();
                    timerInkyRetourneCage.Stop();
                }
            }
        }

        private void timeSuperPacman_Tick(object sender, EventArgs e)
        {
            _superPacman = 0;
            _blinkyFuite = 1;

            timeSuperPacman.Stop();
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
