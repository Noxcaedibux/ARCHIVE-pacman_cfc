using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Clyde
    {
        #region private attributes
        private int _vitesse;
        private int _positionX;
        private int _positionY;
        private int _positionXMap;
        private int _positionYMap;
        private string _orientationGhost = "Nord";
        private int[,] _map;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// permet de créer le fantome clyde en lui passant en paramètre une vitesse et la map
        /// </summary>
        /// <param name="vitesse"></param>
        /// <param name="map"></param>
        public Clyde(int vitesse, int[,] map)
        {
            _vitesse = vitesse;
            _map = map;
            Emplacement();
        }
        #endregion constructors

        #region accessors and mutators
        /// <summary>
        /// retourne la position x de Clyde
        /// </summary>
        public int positionX
        {
            get
            {
                return this._positionX;
            }
        }
        /// <summary>
        /// retourne la position y de Clyde
        /// </summary>
        public int positionY
        {
            get
            {
                return this._positionY;
            }
        }
        /// <summary>
        /// retourne la position x de base (cage) de clyde
        /// </summary>
        public int positionXMap
        {
            get
            {
                return this._positionXMap;
            }
        }
        /// <summary>
        /// retourne la position y de base (cage) de Clyde
        /// </summary>
        public int positionYMap
        {
            get
            {
                return this._positionYMap;
            }
        }
        /// <summary>
        /// retourne la position x graphique de Clyde
        /// </summary>
        public int positionXGraph
        {
            get
            {
                return this._positionX * 20;
            }
        }
        /// <summary>
        /// retourne la position y graphique de Clyde
        /// </summary>
        public int positionYGraph
        {
            get
            {
                return this._positionY * 20;
            }
        }
        /// <summary>
        /// retourne la vitesse de Clyde
        /// </summary>
        public int vitesse
        {
            get
            {
                return this._vitesse;
            }
        }
        /// <summary>
        /// retourne l'orientation de Clyde
        /// </summary>
        public string orientationClyde
        {
            get
            {
                return this._orientationGhost;
            }
        }
        #endregion accessors and mutators

        #region public methods
        /// <summary>
        /// méthode permettant de déplacer Clyde dans la direction demandé en paramètre
        /// </summary>
        /// <param name="direction">direction dans laquel Clyde doit se déplacer</param>
        public void AvancerDirection(string direction)
        {
            _orientationGhost = direction;
            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;
            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;
            else if (_orientationGhost == "Est") _positionX++;
            else if (_orientationGhost == "Ouest") _positionX--;
            else if (_orientationGhost == "Nord") _positionY--;
            else if (_orientationGhost == "Sud") _positionY++;
        }
        /// <summary>
        /// Permet de déplacer Clyde selon son orientation
        /// </summary>
        public void DeplacementClyde()
        {
            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;
            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;
            else if (_orientationGhost == "Est") _positionX++;
            else if (_orientationGhost == "Ouest") _positionX--;
            else if (_orientationGhost == "Nord") _positionY--;
            else if (_orientationGhost == "Sud") _positionY++;

            avancer();
        }
        #endregion public methods

        #region private methods
        private void avancer()
        {
            if (_orientationGhost == "Est" && _positionX == 37)
            {
                _positionX = 0;
            }
            else if (_orientationGhost == "Ouest" && _positionX == 0)
            {
                _positionX = 37;
            }
            else if (_orientationGhost == "Nord" && (_map[positionY - 1, positionX] == 1 || _map[positionY - 1, positionX] == 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost == "Sud" && (_map[positionY + 1, positionX] == 1 || _map[positionY + 1, positionX] == 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost == "Est" && (_map[positionY, positionX + 1] == 1 || _map[positionY, positionX + 1] == 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost == "Ouest" && (_map[positionY, positionX - 1] == 1 || _map[positionY, positionX - 1] == 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost != "Nord" && (_map[positionY - 1, positionX] != 1 && _map[positionY - 1, positionX] != 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost != "Sud" && (_map[positionY + 1, positionX] != 1 && _map[positionY + 1, positionX] != 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost != "Est" && (_map[positionY, positionX + 1] != 1 && _map[positionY, positionX + 1] != 9))
            {
                TournerRandom();
            }
            else if (_orientationGhost != "Ouest" && (_map[positionY, positionX - 1] != 1 && _map[positionY, positionX - 1] != 9))
            {
                TournerRandom();
            }
        }

        private void TournerRandom()
        {
            int rand;
            int i = 1;
            string orientationBase = _orientationGhost;

            while (i == 1)
            {
                Random randomDirection = new Random();
                rand = randomDirection.Next(0, 4);

                switch (rand)
                {
                    case 0:
                        _orientationGhost = "Nord";
                        break;
                    case 1:
                        _orientationGhost = "Sud";
                        break;
                    case 2:
                        _orientationGhost = "Est";
                        break;
                    case 3:
                        _orientationGhost = "Ouest";
                        break;
                    default:
                        _orientationGhost = "Nord";
                        break;

                }

                i = 0;
                if (_orientationGhost == "Nord" && (_map[positionY - 1, positionX] == 1 || _map[positionY - 1, positionX] == 9))
                {
                    i = 1;
                }
                else if (_orientationGhost == "Sud" && (_map[positionY + 1, positionX] == 1 || _map[positionY + 1, positionX] == 9))
                {
                    i = 1;
                }
                else if (_orientationGhost == "Est" && (_map[positionY, positionX + 1] == 1 || _map[positionY, positionX + 1] == 9))
                {
                    i = 1;
                }
                else if (_orientationGhost == "Ouest" && (_map[positionY, positionX - 1] == 1 || _map[positionY, positionX - 1] == 9))
                {
                    i = 1;
                }
                else if (_orientationGhost == "Nord" && orientationBase == "Sud" && (_map[positionY + 1, positionX] != 1 && _map[positionY + 1, positionX] != 9))
                {
                    i = 1;
                }
                else if (_orientationGhost == "Sud" && orientationBase == "Nord" && (_map[positionY - 1, positionX] != 1 && _map[positionY - 1, positionX] != 9))
                {
                    i = 1;
                }
                else if (_orientationGhost == "Est" && orientationBase == "Ouest" && _positionX != 0)
                {
                    if (_map[positionY, positionX - 1] != 1 && _map[positionY, positionX - 1] != 9)
                    {
                        i = 1;
                    }
                }
                else if (_orientationGhost == "Ouest" && orientationBase == "Est" && _positionX != 37)
                {
                    if (_map[positionY, positionX + 1] != 1 && _map[positionY, positionX + 1] != 9)
                    {
                        i = 1;
                    }
                }
                else if (_orientationGhost == "Est" && orientationBase == "Ouest" && _positionX == 0)
                {
                    _orientationGhost = "Ouest";
                }
                else if (_orientationGhost == "Ouest" && orientationBase == "Est" && _positionX == 37)
                {
                    _orientationGhost = "Est";
                }
            }
        }
        private void Emplacement()
        {
            int x;
            int y;
            for (y = 0; y <= 19; y++)
            {
                for (x = 0; x <= 37; x++)
                {
                    if (_map[y, x] == 5)
                    {
                        _positionY = y;
                        _positionX = x;
                        _positionYMap = y;
                        _positionXMap = x;
                    }
                }
            }
        }
        #endregion private methods
    }
}
