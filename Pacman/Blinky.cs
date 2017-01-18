using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// classe du fantôme rouge, celui qui suit pacman sur tout le labyrinthe
    /// </summary>
    public class Blinky
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
        /// Permet de créer le fantome Blinky avec pour paramètres la vitesse du fantôme ainsi que la map
        /// </summary>
        /// <param name="vitesse">vitesse de déplacement du fantome</param>
        /// <param name="map">contient les données de la map</param>
        public Blinky(int vitesse, int[,]map)
        {
            _vitesse = vitesse;
            _map = map;
            Emplacement();
        }
        #endregion constructors

        #region accessors and mutators
        /// <summary>
        /// retourne la posisiton x de blinky
        /// </summary>
        public int positionX
        {
            get
            {
                return this._positionX;
            }
        }
        /// <summary>
        /// retourne la position y de blinky
        /// </summary>
        public int positionY
        {
            get
            {
                return this._positionY;
            }
        }
        /// <summary>
        /// retourne la position x de base (cage) de blinky
        /// </summary>
        public int positionXMap
        {
            get
            {
                return this._positionXMap;
            }
        }
        /// <summary>
        /// retourne la position y de base (cage) de blinky
        /// </summary>
        public int positionYMap
        {
            get
            {
                return this._positionYMap;
            }
        }
        /// <summary>
        /// retourne la position x graphique de blinky
        /// </summary>
        public int positionXGraph
        {
            get
            {
                return this._positionX * 20;
            }
        }
        /// <summary>
        /// retourne la position y graphique de blinky
        /// </summary>
        public int positionYGraph
        {
            get
            {
                return this._positionY * 20;
            }
        }
        /// <summary>
        /// retourne la vitesse de blinky
        /// </summary>
        public int vitesse
        {
            get
            {
                return this._vitesse;
            }
        }
        /// <summary>
        /// retourne l'orientation de blinky
        /// </summary>
        public string orientationBlinky
        {
            get
            {
                return this._orientationGhost;
            }
        }
        #endregion accessors and mutators

        #region public methods
        /// <summary>
        /// méthode permettant de déplacer blinky dans la direction passée en paramètres
        /// </summary>
        /// <param name="direction">direction vers laquel blinky devra se déplacer</param>
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
        /// méthode permettant de déplacer blinky selon l'orientation qu'il a
        /// </summary>
        public void DeplacementBlinky()
        {
            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;
            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;
            else if (_orientationGhost == "Est") _positionX++;
            else if (_orientationGhost == "Ouest") _positionX--;
            else if (_orientationGhost == "Nord") _positionY--;
            else if (_orientationGhost == "Sud") _positionY++;
        }
        /// <summary>
        /// méthode permettant à blinky de déterminer dans quel direction aller pour suivre pacman
        /// </summary>
        /// <param name="positionXPacman">position x de pacman</param>
        /// <param name="positionYPacman">position y de pacman</param>
        public void SuivrePacman(int positionXPacman, int positionYPacman)
        {
            int differenceX = 0;
            int differenceY = 0;

            string orientationBase = _orientationGhost;

            if (_positionX > positionXPacman) differenceX = _positionX - positionXPacman;
            else if (_positionX < positionXPacman) differenceX = positionXPacman - _positionX;

            if (_positionY > positionYPacman) differenceY = _positionY - positionYPacman;
            else if (_positionY < positionYPacman) differenceY = positionYPacman - _positionY;

            if(differenceX >= differenceY && differenceX != 0)
            {
                if (_positionX > positionXPacman && orientationBase != "Est") _orientationGhost = "Ouest";
                else if (_positionX < positionXPacman && orientationBase != "Ouest") _orientationGhost = "Est";
            }

            else if(differenceY != 0)
            {
                if (_positionY > positionYPacman && orientationBase != "Sud") _orientationGhost = "Nord";
                else if (_positionY < positionYPacman && orientationBase != "Nord") _orientationGhost = "Sud";
            }

            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;

            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;

            else if (_orientationGhost == "Ouest" && (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9))
            {
                if (_positionY >= positionYPacman && orientationBase != "Sud" || orientationBase == "Nord") _orientationGhost = "Nord";
                else if (orientationBase != "Nord") _orientationGhost = "Sud";
                else _orientationGhost = "Est";

                if (_orientationGhost == "Nord" && (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9))
                {
                    if (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9) _orientationGhost = "Est";
                    else _orientationGhost = "Sud";
                }

                else if (_orientationGhost == "Sud" && (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9))
                {
                    if (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9) _orientationGhost = "Est";
                    else _orientationGhost = "Nord";
                }
            }

            else if (_orientationGhost == "Est" && (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9))
            {
                if (_positionY >= positionYPacman && orientationBase != "Sud" || orientationBase == "Nord") _orientationGhost = "Nord";
                else if (orientationBase != "Nord") _orientationGhost = "Sud";
                else _orientationGhost = "Ouest";

                if (_orientationGhost == "Nord" && (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9))
                {
                    if (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9) _orientationGhost = "Ouest";
                    else _orientationGhost = "Sud";
                }

                else if (_orientationGhost == "Sud" && (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9))
                {
                    if (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9) _orientationGhost = "Ouest";
                    else _orientationGhost = "Nord";
                }
            }

            else if (_orientationGhost == "Nord" && (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9))
            {
                if (_positionX >= positionXPacman && orientationBase != "Est" || orientationBase == "Ouest") _orientationGhost = "Ouest";
                else if (orientationBase != "Ouest") _orientationGhost = "Est";
                else _orientationGhost = "Sud";

                if (_orientationGhost == "Ouest" && (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9))
                {
                    if (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9) _orientationGhost = "Sud";
                    else _orientationGhost = "Est";
                }

                else if (_orientationGhost == "Est" && (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9))
                {
                    if (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9) _orientationGhost = "Sud";
                    else _orientationGhost = "Ouest";
                }
            }

            else if (_orientationGhost == "Sud" && (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9))
            {
                if (_positionX >= positionXPacman && orientationBase != "Est" || orientationBase == "Ouest") _orientationGhost = "Ouest";
                else if (orientationBase != "Ouest") _orientationGhost = "Est";
                else _orientationGhost = "Nord";

                if (_orientationGhost == "Ouest" && (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9))
                {
                    if (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9) _orientationGhost = "Nord";
                    else _orientationGhost = "Est";
                }

                else if (_orientationGhost == "Est" && (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9))
                {
                    if (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9) _orientationGhost = "Nord";
                    else _orientationGhost = "Ouest";
                }
            }
        }
        /// <summary>
        /// méthode permettant de tourner dans une direction aléatoire selon quelques critères
        /// </summary>
        public void RandomDirection()
        {
            if (_orientationGhost == "Est" && _positionX == 37)
            {
                _positionX = 0;
            }
            else if (_orientationGhost == "Ouest" && _positionX == 0)
            {
                _positionX = 37;
            }

            else if (_positionX > 0 && _positionX < 37)
            {
                if (_orientationGhost == "Nord" && (_map[positionY - 1, positionX] == 1 || _map[positionY - 1, positionX] == 9))
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
                    if (_map[y, x] == 6)
                    {
                        _positionY = y;
                        _positionX = x;
                        _positionYMap = y;
                        _positionXMap = x;
                    }
                }
            }
        }

        private void TournerRandom()
        {
            int rand;
            string orientationPossible1 = "Est";
            string orientationPossible2 = _orientationGhost;
            string orientationPossible3 = _orientationGhost;
            int nbRandom = 0;

            Random randomDirection = new Random();

            if (_orientationGhost == "Est")
            {
                if (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9)
                {
                    orientationPossible1 = "Ouest";
                }
                else orientationPossible1 = "Est";
                nbRandom++;

                if (_map[_positionY - 1, _positionX] != 1 && _map[_positionY - 1, _positionX] != 9)
                {
                    orientationPossible2 = "Nord";
                    nbRandom++;

                    if (_map[_positionY + 1, _positionX] != 1 && _map[_positionY + 1, _positionX] != 9)
                    {
                        orientationPossible3 = "Sud";
                        nbRandom++;
                    }
                }

                else if (_map[_positionY + 1, _positionX] != 1 && _map[_positionY + 1, _positionX] != 9)
                {
                    orientationPossible2 = "Sud";
                    nbRandom++;
                }
            }

            else if (_orientationGhost == "Ouest")
            {
                if (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9)
                {
                    orientationPossible1 = "Est";
                }
                else orientationPossible1 = "Ouest";
                nbRandom++;

                if (_map[_positionY - 1, _positionX] != 1 && _map[_positionY - 1, _positionX] != 9)
                {
                    orientationPossible2 = "Nord";
                    nbRandom++;

                    if (_map[_positionY + 1, _positionX] != 1 && _map[_positionY + 1, _positionX] != 9)
                    {
                        orientationPossible3 = "Sud";
                        nbRandom++;
                    }
                }

                else if (_map[_positionY + 1, _positionX] != 1 && _map[_positionY + 1, _positionX] != 9)
                {
                    orientationPossible2 = "Sud";
                    nbRandom++;
                }
            }

            else if (_orientationGhost == "Nord")
            {
                if (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9)
                {
                    if (_map[_positionY + 1, _positionX] != 1 && _map[_positionY + 1, _positionX] != 9)
                        orientationPossible1 = "Sud";
                }
                else orientationPossible1 = "Nord";
                nbRandom++;

                if (_map[_positionY, _positionX - 1] != 1 && _map[_positionY, _positionX - 1] != 9)
                {
                    orientationPossible2 = "Ouest";
                    nbRandom++;

                    if (_map[_positionY, _positionX + 1] != 1 && _map[_positionY, _positionX + 1] != 9)
                    {
                        orientationPossible3 = "Est";
                        nbRandom++;
                    }
                }

                else if (_map[_positionY, _positionX + 1] != 1 && _map[_positionY, _positionX + 1] != 9)
                {
                    orientationPossible2 = "Est";
                    nbRandom++;
                }
            }

            else if (_orientationGhost == "Sud")
            {
                if (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9)
                {
                    orientationPossible1 = "Nord";
                }
                else orientationPossible1 = "Sud";
                nbRandom++;

                if (_map[_positionY, _positionX - 1] != 1 && _map[_positionY, _positionX - 1] != 9)
                {
                    orientationPossible2 = "Ouest";
                    nbRandom++;

                    if (_map[_positionY, _positionX + 1] != 1 && _map[_positionY, _positionX + 1] != 9)
                    {
                        orientationPossible3 = "Est";
                        nbRandom++;
                    }
                }

                else if (_map[_positionY, _positionX + 1] != 1 && _map[_positionY, _positionX + 1] != 9)
                {
                    orientationPossible2 = "Est";
                    nbRandom++;
                }
            }

            if (nbRandom == 1) _orientationGhost = orientationPossible1;

            else
            {
                rand = randomDirection.Next(0, nbRandom);

                switch (rand)
                {
                    case 0:
                        _orientationGhost = orientationPossible1;
                        break;
                    case 1:
                        _orientationGhost = orientationPossible2;
                        break;
                    case 2:
                        _orientationGhost = orientationPossible3;
                        break;
                }
            }
        }
        #endregion private methods
    }
}
