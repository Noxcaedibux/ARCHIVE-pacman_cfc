using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    /// <summary>
    /// classe de test pour Blinky le fantôme qui 
    /// poursuit pacman dans tout le labyrinthe
    /// </summary>
    [TestClass]
    public class TestBlinky
    {
        #region private attributes
        private Blinky _classBlinky;
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
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie nos variables
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _classMap = new Map("Map01");
            _map=_classMap.map;
            _vitesseExpected = 20;
            _classBlinky = new Blinky(_vitesseExpected, _map);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on test s'il à la bonne position x
        /// </summary>
        [TestMethod]
        public void TestBlinky_positionX_callAccessor_success()
        {
            //refer to Initialize()
            _positionXExpected = 18;
            _positionXActual = _classBlinky.positionX;

            Assert.AreEqual(_positionXExpected, _positionXActual);
        }

        /// <summary>
        /// on test s'il à la bonne position y
        /// </summary>
        [TestMethod]
        public void TestBlinky_positionY_callAccessor_success()
        {
            //refer to Initialize()
            _positionYExpected = 11;
            _positionYActual = _classBlinky.positionY;

            Assert.AreEqual(_positionYExpected, _positionYActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestBlinky_positionXMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionXMapExpected = 18;
            _positionXMapActual = _classBlinky.positionXMap;

            Assert.AreEqual(_positionXMapExpected, _positionXMapActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestBlinky_positionYMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionYMapExpected = 11;
            _positionYMapActual = _classBlinky.positionYMap;

            Assert.AreEqual(_positionYMapExpected, _positionYMapActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestBlinky_positionXGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionXGraphExpected = 360;
            _positionXGraphActual = _classBlinky.positionXGraph;

            Assert.AreEqual(_positionXGraphExpected, _positionXGraphActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestBlinky_positionYGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionYGraphExpected = 220;
            _positionYGraphActual = _classBlinky.positionYGraph;

            Assert.AreEqual(_positionYGraphExpected, _positionYGraphActual);
        }

        /// <summary>
        /// on vérifie qu'il ait la bonne vitesse
        /// </summary>
        [TestMethod]
        public void TestBlinky_vitesse_callAccessor_success()
        {
            //refer to Initialize()
            _vitesseActual = _classBlinky.vitesse;

            Assert.AreEqual(_vitesseExpected, _vitesseActual);
        }

        /// <summary>
        /// on vérifie bien que blinky regarde en haut
        /// </summary>
        [TestMethod]
        public void TestBlinky_orientationBlinky_callAccessor_success()
        {
            //refer to Initialize()
            _orientationExpected = "Nord";
            _orientationActual = _classBlinky.orientationBlinky;

            Assert.AreEqual(_orientationExpected, _orientationActual);
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
            _classBlinky = null;
            _positionXActual = 0;
            _positionYActual = 0;
            _positionXMapActual = 0;
            _positionYMapActual = 0;
            _positionXGraphActual = 0;
            _positionYGraphActual = 0;
            _vitesseActual = 0;
            _orientationActual = null;
        }
        #endregion CleanUp
    }
}
