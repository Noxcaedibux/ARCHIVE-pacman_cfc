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
        public int vitesse
        {
            get
            {
                return this._vitesse;
            }
        }
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
        /// méthode permettant de diriger pacman en fonction de l'orientation retournée
        /// </summary>
        /// <param name="orientationPacman"></param>
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
