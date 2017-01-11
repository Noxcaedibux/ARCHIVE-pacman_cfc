using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Inky
    {
        #region private attributes
        private int _vitesse;
        private int _positionX;
        private int _positionY;
        private int _positionXMap;
        private int _positionYMap;
        private int _mur = 0;
        private string _orientationGhost = "Nord";
        private int[,] _map;
        #endregion private attributes

        #region constructors
        public Inky(int vitesse, int[,] map)
        {
            _vitesse = vitesse;
            _map = map;
            Emplacement();
        }
        #endregion constructors

        #region accessors and mutators
        public int positionX
        {
            get
            {
                return this._positionX;
            }
        }
        public int positionY
        {
            get
            {
                return this._positionY;
            }
        }

        public int positionXMap
        {
            get
            {
                return this._positionXMap;
            }
        }
        public int positionYMap
        {
            get
            {
                return this._positionYMap;
            }
        }
        public int positionXGraph
        {
            get
            {
                return this._positionX * 20;
            }
        }
        public int positionYGraph
        {
            get
            {
                return this._positionY * 20;
            }
        }
        public int vitesse
        {
            get
            {
                return this._vitesse;
            }
        }
        public string orientationInky
        {
            get
            {
                return this._orientationGhost;
            }
        }
        public int mur
        {
            get
            {
                return this._mur;
            }
        }
        #endregion accessors and mutators

        #region public methods
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

        public void DeplacementInky()
        {
            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;
            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;
            else if (_orientationGhost == "Est") _positionX++;
            else if (_orientationGhost == "Ouest") _positionX--;
            else if (_orientationGhost == "Nord") _positionY--;
            else if (_orientationGhost == "Sud") _positionY++;

            Avancer();
        }

        public void ChangerDirectionInky(string orientationInky)
        {
            _orientationGhost = orientationInky;
            Avancer();
        }

        public void SuivrePacman(int positionXPacman, int positionYPacman)
        {
            if(_positionX == positionXPacman)
            {
                if (_positionY > positionYPacman) _orientationGhost = "Nord";
                else if (_positionY < positionYPacman) _orientationGhost = "Sud";
            }

            else if (_positionY == positionYPacman)
            {
                if (_positionX > positionXPacman) _orientationGhost = "Ouest";
                else if (_positionX < positionXPacman) _orientationGhost = "Est";
            }

            Avancer();
        }

        public void TournerRandom()
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
                    if (_map[y, x] == 8)
                    {
                        _positionY = y;
                        _positionX = x;
                        _positionYMap = y;
                        _positionXMap = x;
                    }
                }
            }
        }

        private void Avancer()
        {
            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;
            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;
            else if (_orientationGhost == "Nord" && (_map[_positionY - 1, _positionX] == 1 || _map[_positionY - 1, _positionX] == 9)) _mur = 1;
            else if (_orientationGhost == "Sud" && (_map[_positionY + 1, _positionX] == 1 || _map[_positionY + 1, _positionX] == 9)) _mur = 1;
            else if (_orientationGhost == "Est" && (_map[_positionY, _positionX + 1] == 1 || _map[_positionY, _positionX + 1] == 9)) _mur = 1;
            else if (_orientationGhost == "Ouest" && (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9)) _mur = 1;
            else _mur = 0;
        }
        #endregion private methods
    }
}
