using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// classe pacman qui permettra de construire un objet pacman
    /// contenant les informations les plus importantes de pacman
    /// </summary>
    public class ClassPacman
    {
        #region private attributes
        private int _vitesse;
        private int _positionX;
        private int _positionY;
        private int _coins;
        private int _ghostEaten;
        private int _life;
        private int _totalScore;
        private string _orientationPacman = "Nord";
        private int _avancer = 1;
        private int[,] _map;
        private int[,] _personnages = new int[20, 38];
        private int _nbPiece;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// constructeur de notre objet pacman
        /// qui contiendra toutes les informations utiles comme,
        /// le nombre de vies qu'il possède,
        /// le nombre de pièces mangées,
        /// le nombre de fontômes mangés,
        /// sa vitesse de déplacement et ces coordonées
        /// </summary>
        /// <param name="vitesse"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        /// <param name="life"></param>
        /// <param name="coins"></param>
        /// <param name="ghostEaten"></param>
        public ClassPacman(int vitesse, int positionX, int positionY, int life, int coins, int ghostEaten, int[,] map)
        {
            _vitesse = vitesse;
            _positionX = positionX;
            _positionY = positionY;
            _coins = coins;
            _ghostEaten = ghostEaten;
            _life = life;
            _map = map;
            _personnages[positionY, _positionX] = 4;
            _nbPiece = 0;
            foreach(int piece in this._map)
            {
                if (piece == 2) _nbPiece++;
            }
        }
        #endregion constructors

        #region accessors and mutators
        /// <summary>
        /// accesseur de la position horizontale de pacman
        /// qui sera des entier comme si on lisait des lignes d'un tableau
        /// </summary>
        public int positionX
        {
            get
            {
                return this._positionX;
            }
        }
        /// <summary>
        /// accesseur de la position verticale de pacman
        /// qui sera des entier comme si on lisait des colonnes d'un tableau
        /// </summary>
        public int positionY
        {
            get
            {
                return this._positionY;
            }
        }
        /// <summary>
        /// accesseur de la position horizontale de pacman qui correspondra aux positions du tableau 
        /// qui fait 20pixels de large et 2 pixels de plus pour etre bien placé
        /// </summary>
        public int positionXGraph
        {
            get
            {
                return this._positionX * 20;
            }
        }
        /// <summary>
        /// accesseur de la position verticale de pacman qui correspondra aux positions du tableau 
        /// qui fait 20pixels de haut
        /// </summary>
        public int positionYGraph
        {
            get
            {
                return this._positionY * 20;
            }
        }
        /// <summary>
        /// accesseur de la vitesse de deplacement de pacman
        /// </summary>
        public int vitesse
        {
            get
            {
                return this._vitesse;
            }
        }
        /// <summary>
        /// accesseur qui nous permettra de savoir la direction dans la quelle pacman regarde
        /// Nord
        /// Sud 
        /// Est 
        /// Öuest
        /// </summary>
        public string orientation
        {
            get
            {
                return this._orientationPacman;
            }
        }
        #endregion accessors and mutators

        #region public methods
        /// <summary>
        /// methode public qui informe si on peut ou pas avancer
        /// exemple pacman va dépasser le haut du jeu il est arreté
        /// pareil pour le bas.
        /// et il pourra se teleporter de droite à gauche ou vice versa 
        /// quand il dépace le droit ou gauche
        /// et s'arretera s'il a un mur en face de lui
        /// </summary>
        /// <returns></returns>
        public int avancer()
        {
            if (_orientationPacman == "Est" && _positionX == 37)
            {
                _avancer = 1;
                _positionX = 0;
            }
            else if (_orientationPacman == "Ouest" && _positionX == 0)
            {
                _avancer = 1;
                _positionX = 37;
            }
            else if (_orientationPacman == "Nord" && _map[positionY - 1, positionX] == 1)
            {
                _avancer = 0;
            }
            else if (_orientationPacman == "Sud" && _map[positionY + 1, positionX] == 1)
            {
                _avancer = 0;
            }
            else if (_orientationPacman == "Est" && _map[positionY, positionX + 1] == 1)
            {
                _avancer = 0;
            }
            else if (_orientationPacman == "Ouest" && _map[positionY, positionX - 1] == 1)
            {
                _avancer = 0;
            }
            else
            {
                _avancer = 1;
            }
            return _avancer;
        }
        /// <summary>
        /// méthode permettant de diriger pacman en fonction de l'orientation retournée
        /// </summary>
        /// <param name="orientationPacman">variable contenant l'orientation de pacman</param>
        public void DeplacementPacman(string orientationPacman)
        {
            if(_avancer == 1)
            {
                _personnages[positionY, _positionX] = 0;
                if (_orientationPacman == "Est") _positionX++;
                if (_orientationPacman == "Ouest") _positionX--;
                if (_orientationPacman == "Nord") _positionY--;
                if (_orientationPacman == "Sud") _positionY++;
                _personnages[positionY, _positionX] = 4;
            }
            _orientationPacman = orientationPacman;
        }

        public int MangerPiece()
        {
            if(_map[positionY, positionX] == 2)
            {
                _map[positionY, positionX] = 0;
                _nbPiece--;
            }
            return _nbPiece;
        }
        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
