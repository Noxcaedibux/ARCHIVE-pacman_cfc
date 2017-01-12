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
        private int _pac_gome=0;
        private int _superPac_gome=0;
        private int _life;
        private int _piecesRestantes;
        private string _orientationPacman = "Nord";
        private int _avancer;
        private int[,] _map;
        private int _ghostEaten = 0;
        private int _nbPiecesTotal;
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
        /// <param name="map"></param>
        public ClassPacman(int vitesse, int life, int[,] map)
        {
            _vitesse = vitesse;
            _life = life;
            _map = map;
            Emplacement();
            _piecesRestantes = 0;
            foreach (int piece in _map)
            {
                if (piece == 2 || piece == 3) _piecesRestantes++;
            }
            _nbPiecesTotal = _piecesRestantes;
        }
        #endregion constructors

        #region accessors and mutators
        /// <summary>
        /// accesseur du nombre de pièces mangées
        /// </summary>
        public int pac_gome
        {
            get
            {
                return this._pac_gome;
            }
        }
        /// <summary>
        /// Retourne le nombre de fantomes mangés
        /// </summary>
        public int ghostEaten
        {
            get
            {
                return this._ghostEaten;
            }
        }
        /// <summary>
        /// accesseur du nombre de pièces mangées
        /// </summary>
        public int superPac_gome
        {
            get
            {
                return this._superPac_gome;
            }
        }
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
        /// accesseur qui nous permettra de savoir la direction dans la quelle pacman regarde:
        /// - Nord
        /// - Sud 
        /// - Est 
        /// - Ouest
        /// </summary>
        public string orientation
        {
            get
            {
                return this._orientationPacman;
            }
        }
        /// <summary>
        /// Accesseur qui nous retourne la valeur des pièces que pacman n'a pas encore mangé
        /// </summary>
        public int NbPiecesRestantes
        {
            get
            {
                return this._piecesRestantes;
            }
        }
        #endregion accessors and mutators

        #region public methods
        /// <summary>
        /// cette methode remet pacman à son point de départ
        /// </summary>
        public void replacement()
        {
            Emplacement();
        }
        /// <summary>
        /// methode public qui informe si on peut ou pas avancer
        /// exemple pacman va dépasser le haut du jeu il est arreté
        /// pareil pour le bas.
        /// et il pourra se teleporter de droite à gauche ou vice versa 
        /// quand il dépace le mur droite ou gauche
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
            else if (_orientationPacman == "Nord" && (_map[positionY - 1, positionX] == 1 || _map[positionY - 1, positionX] == 9))
            {
                _avancer = 0;
            }
            else if (_orientationPacman == "Sud" && (_map[positionY + 1, positionX] == 1 || _map[positionY + 1, positionX] == 9))
            {
                _avancer = 0;
            }
            else if (_orientationPacman == "Est" && (_map[positionY, positionX + 1] == 1 || _map[positionY, positionX + 1] == 9))
            {
                _avancer = 0;
            }
            else if (_orientationPacman == "Ouest" && (_map[positionY, positionX - 1] == 1 || _map[positionY, positionX - 1] == 9))
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
                if (_orientationPacman == "Est") _positionX++;
                if (_orientationPacman == "Ouest") _positionX--;
                if (_orientationPacman == "Nord") _positionY--;
                if (_orientationPacman == "Sud") _positionY++;
            }
            _orientationPacman = orientationPacman;
        }
        /// <summary>
        /// méthode permettant de détecter sir Pacman rencontre un fantôme
        /// </summary>
        /// <param name="orientationGhost">variable pour connaître l'orientation du fantome</param>
        /// <param name="positionGhostX">variable pour connaître la position du fantome sur l'axe x</param>
        /// <param name="positionYGhost">variable pour connaître la position du fantome sur l'axe y</param>
        /// <returns></returns>
        public int collisionGhost(string orientationGhost, int positionGhostX, int positionYGhost)
        {
            int mort = 0;
            if (positionGhostX == _positionX && positionYGhost == _positionY) mort = 1;
            else if(positionYGhost == _positionY)
            {
                if(positionGhostX == _positionX + 1)
                {
                    if(orientationGhost == "Est")
                    {
                        if (_orientationPacman != "Est") mort = 1;
                    }
                    else if(_orientationPacman == "Ouest")
                    {
                        if (orientationGhost != "Ouest") mort = 1; 
                    }
                }

                else if (positionGhostX == _positionX - 1)
                {
                    if (orientationGhost == "Ouest")
                    {
                        if (_orientationPacman != "Ouest") mort = 1;
                    }
                    else if (_orientationPacman == "Est")
                    {
                        if (orientationGhost != "Est") mort = 1;
                    }
                }
            }

            else if(positionGhostX == _positionX)
            {
                if(positionYGhost == _positionY + 1)
                {
                    if(orientationGhost == "Sud")
                    {
                        if (_orientationPacman != "Sud") mort = 1;
                    }

                    else if(_orientationPacman == "Nord")
                    {
                        if (orientationGhost != "Nord") mort = 1;
                    }
                }

                else if (positionYGhost == _positionY - 1)
                {
                    if (orientationGhost == "Nord")
                    {
                        if (_orientationPacman != "Nord") mort = 1;
                    }

                    else if (_orientationPacman == "Sud")
                    {
                        if (orientationGhost != "Sud") mort = 1;
                    }
                }
            }

            return mort;
        }
        /// <summary>
        /// cette méthode sert à savoir si on est sur une pièce, si c'est le cas on va 
        /// éffacer sa valeur(=2) du tableau et on recalcule le nombre de pièces mangées
        /// </summary>
        /// <returns></returns>
        public int PiecesRestantes()
        {
            if (_map[positionY, positionX] == 2)
            {
                _map[positionY, positionX] = 0;
                _piecesRestantes--;
                _pac_gome++;
            }
            if (_map[positionY, positionX] == 3)
            {
                _map[positionY, positionX] = 0;
                _piecesRestantes--;
                _superPac_gome++;
            }
            return this._piecesRestantes;
        }
        /// <summary>
        /// augmente le nombre de fantomes mangés par Pacman
        /// </summary>
        public void GhostEatenAdd()
        {
            _ghostEaten++;
        }

        /// <summary>
        /// méthode qui permet de calculer et de retourner le score final
        /// </summary>
        /// <param name="ghostEaten">nombre de fantomes que pacman a mangé</param>
        /// <returns></returns>
        public int ScoreTotal()
        {
            return this._ghostEaten + this._pac_gome + this._superPac_gome;
        }
        /// <summary>
        /// méthode qui permet de recharger les pieces pour continuer une partie
        /// </summary>
        public void ResetPiecesMap(int[,] nouvelleMap)
        {
            _piecesRestantes = _nbPiecesTotal;
            _map = nouvelleMap;
        }
        #endregion public methods

        #region private methods
        private void Emplacement()
        {
            int x;
            int y;
            for (y = 0; y <= 19; y++)
            {
                for (x = 0; x <= 37; x++)
                {
                    if (_map[y, x] == 4)
                    {
                        _positionY = y;
                        _positionX = x;
;                    }
                }
            }
        }
        #endregion private methods
    }
}
