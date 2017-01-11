using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
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
        public Blinky(int vitesse, int[,]map)
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
        public string orientationBlinky
        {
            get
            {
                return this._orientationGhost;
            }
        }
        #endregion accessors and mutators

        #region public methods
        public void AvancerDirection(string direction)
        {
            _orientationGhost = direction;
            if (_orientationGhost == "Est") _positionX++;
            if (_orientationGhost == "Ouest") _positionX--;
            if (_orientationGhost == "Nord") _positionY--;
            if (_orientationGhost == "Sud") _positionY++;
        }

        public void DeplacementBlinky()
        {
            if (_orientationGhost == "Est") _positionX++;
            if (_orientationGhost == "Ouest") _positionX--;
            if (_orientationGhost == "Nord") _positionY--;
            if (_orientationGhost == "Sud") _positionY++;
        }

        public void SuivrePacman(int positionXPacman, int positionYPacman)
        {
            int differenceX = 0;
            int differenceY = 0;

            if (_positionX > positionXPacman) differenceX = _positionX - positionXPacman;
            else if (_positionX < positionXPacman) differenceX = positionXPacman - _positionX;

            if (_positionY > positionYPacman) differenceY = _positionY - positionYPacman;
            else if (_positionY < positionYPacman) differenceY = positionYPacman - _positionY;

            if(differenceX >= differenceY && differenceX != 0)
            {
                if (_positionX > positionXPacman) _orientationGhost = "Ouest";
                else if (_positionX < positionXPacman) _orientationGhost = "Est";
            }

            else if(differenceY != 0)
            {
                if (_positionY > positionYPacman) _orientationGhost = "Nord";
                else if (_positionY < positionYPacman) _orientationGhost = "Sud";
            }

            if (_orientationGhost == "Est" && _positionX == 37) _positionX = 0;

            else if (_orientationGhost == "Ouest" && _positionX == 0) _positionX = 37;

            else if (_orientationGhost == "Ouest" && (_map[_positionY, _positionX - 1] == 1 || _map[_positionY, _positionX - 1] == 9))
            {
                if (_positionY >= positionYPacman) _orientationGhost = "Nord";
                else if (_positionY < positionYPacman) _orientationGhost = "Sud";

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
                if (_positionY >= positionYPacman) _orientationGhost = "Nord";
                else if (_positionY < positionYPacman) _orientationGhost = "Sud";

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
                if (_positionX >= positionXPacman) _orientationGhost = "Ouest";
                else if (_positionX < positionXPacman) _orientationGhost = "Est";

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
                if (_positionX >= positionXPacman) _orientationGhost = "Ouest";
                else if (_positionX < positionXPacman) _orientationGhost = "Est";

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
        public void TournerRandom()
        {
            int rand;
            int i = 1;

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
        #endregion private methods
    }
}
