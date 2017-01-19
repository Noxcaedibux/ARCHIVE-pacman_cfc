using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    /// <summary>
    /// classe de test pour Inky le fantôme qui avance en ligne
    /// droite dès qu'il vous voit
    /// </summary>
    [TestClass]
    public class TestInky
    {
        #region private attributes
        private Inky _classInky;
        private Map _classMap;
        private int[,] _map;
        private int _positionXActual;
        private int _positionXExpected;
        private int _positionYActual;
        private int _positionYExpected;
        private int _positionXMapActual;
        private int _positionXMapExpected;
        private int _positionYMapActual;
        private int _positionYMapExpected;
        private int _positionXGraphActual;
        private int _positionXGraphExpected;
        private int _positionYGraphActual;
        private int _positionYGraphExpected;
        private int _vitesseActual;
        private int _vitesseExpected;
        private string _orientationActual;
        private string _orientationExpected;
        private int _murActual;
        private int _murExpected;
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie nos variables
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _classMap = new Map("Map01");
            _map = _classMap.map;
            _vitesseExpected = 20;
            _classInky = new Inky(_vitesseExpected, _map);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on test s'il à la bonne position x
        /// </summary>
        [TestMethod]
        public void TestInky_positionX_callAccessor_success()
        {
            //refer to Initialize()
            _positionXExpected = 20;
            _positionXActual = _classInky.positionX;

            Assert.AreEqual(_positionXExpected, _positionXActual);
        }

        /// <summary>
        /// on test s'il à la bonne position y
        /// </summary>
        [TestMethod]
        public void TestInky_positionY_callAccessor_success()
        {
            //refer to Initialize()
            _positionYExpected = 11;
            _positionYActual = _classInky.positionY;

            Assert.AreEqual(_positionYExpected, _positionYActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestInky_positionXMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionXMapExpected = 20;
            _positionXMapActual = _classInky.positionXMap;

            Assert.AreEqual(_positionXMapExpected, _positionXMapActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestInky_positionYMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionYMapExpected = 11;
            _positionYMapActual = _classInky.positionYMap;

            Assert.AreEqual(_positionYMapExpected, _positionYMapActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestInky_positionXGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionXGraphExpected = 400;
            _positionXGraphActual = _classInky.positionXGraph;

            Assert.AreEqual(_positionXGraphExpected, _positionXGraphActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestInky_positionYGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionYGraphExpected = 220;
            _positionYGraphActual = _classInky.positionYGraph;

            Assert.AreEqual(_positionYGraphExpected, _positionYGraphActual);
        }

        /// <summary>
        /// on vérifie qu'il ait la bonne vitesse
        /// </summary>
        [TestMethod]
        public void TestInky_vitesse_callAccessor_success()
        {
            //refer to Initialize()
            _vitesseActual = _classInky.vitesse;

            Assert.AreEqual(_vitesseExpected, _vitesseActual);
        }

        /// <summary>
        /// on vérifie bien que Inky regarde en haut
        /// </summary>
        [TestMethod]
        public void TestInky_orientationInky_callAccessor_success()
        {
            //refer to Initialize()
            _orientationExpected = "Nord";
            _orientationActual = _classInky.orientationInky;

            Assert.AreEqual(_orientationExpected, _orientationActual);
        }
        /// <summary>
        /// on test le fait que inky regarde s'il n'y a pas un mur avant d'avancer
        /// </summary>
        [TestMethod]
        public void TestInky_mur_callAccessor_success()
        {
            //refer to Initialize()
            _murExpected = 0;
            _murActual = _classInky.mur;

            Assert.AreEqual(_murExpected, _murActual);
        }
        #endregion TestMethods

        #region CleanUp
        /// <summary>
        /// on remet à zero les variables
        /// </summary>
        [TestCleanup]
        public void CleanUp()
        {
            _classMap = null;
            _map = null;
            _classInky = null;
            _positionXActual = 0;
            _positionYActual = 0;
            _positionXMapActual = 0;
            _positionYMapActual = 0;
            _positionXGraphActual = 0;
            _positionYGraphActual = 0;
            _vitesseActual = 0;
            _orientationActual = null;
            _murActual = 0;
        }
        #endregion CleanUp
    }
}
