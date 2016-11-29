using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
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
        private string _orientationPacman = "Ouest";
        #endregion private attributes

        #region constructors
        public ClassPacman(int vitesse, int positionX, int positionY, int life, int coins, int ghostEaten)
        {
            _vitesse = vitesse;
            _positionX = positionX;
            _positionY = positionY;
            _coins = coins;
            _ghostEaten = ghostEaten;
            _life = life;
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
        public int positionXGraph
        {
            get
            {
                return this._positionX * 20 + 2;
            }
        }
        public int positionYGraph
        {
            get
            {
                return this._positionY * 20;
            }
        }
        #endregion accessors and mutators

        #region public methods
        public void DeplacementPacman(string orientationPacman)
        {
            if (_orientationPacman == "Est") _positionX++;
            if (_orientationPacman == "Ouest") _positionX--;
            if (_orientationPacman == "Nord") _positionY--;
            if (_orientationPacman == "Sud") _positionY++;
            _orientationPacman = orientationPacman;
        }
        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
