using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    /// <summary>
    /// classe test pour Pinky le fantôme qui vous attend en
    /// embuscade derrière un mur et avance j'usqu'au prochain
    /// mur dès qu'il vous vois
    /// </summary>
    [TestClass]
    public class TestPinky
    {
        #region private attributes
        private Pinky _classPinky;
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
            _classPinky = new Pinky(_vitesseExpected, _map);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on test s'il à la bonne position x
        /// </summary>
        [TestMethod]
        public void TestPinky_positionX_callAccessor_success()
        {
            //refer to Initialize()
            _positionXExpected = 19;
            _positionXActual = _classPinky.positionX;

            Assert.AreEqual(_positionXExpected, _positionXActual);
        }

        /// <summary>
        /// on test s'il à la bonne position y
        /// </summary>
        [TestMethod]
        public void TestPinky_positionY_callAccessor_success()
        {
            //refer to Initialize()
            _positionYExpected = 11;
            _positionYActual = _classPinky.positionY;

            Assert.AreEqual(_positionYExpected, _positionYActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestPinky_positionXMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionXMapExpected = 19;
            _positionXMapActual = _classPinky.positionXMap;

            Assert.AreEqual(_positionXMapExpected, _positionXMapActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestPinky_positionYMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionYMapExpected = 11;
            _positionYMapActual = _classPinky.positionYMap;

            Assert.AreEqual(_positionYMapExpected, _positionYMapActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestPinky_positionXGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionXGraphExpected = 380;
            _positionXGraphActual = _classPinky.positionXGraph;

            Assert.AreEqual(_positionXGraphExpected, _positionXGraphActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestPinky_positionYGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionYGraphExpected = 220;
            _positionYGraphActual = _classPinky.positionYGraph;

            Assert.AreEqual(_positionYGraphExpected, _positionYGraphActual);
        }

        /// <summary>
        /// on vérifie qu'il ait la bonne vitesse
        /// </summary>
        [TestMethod]
        public void TestPinky_vitesse_callAccessor_success()
        {
            //refer to Initialize()
            _vitesseActual = _classPinky.vitesse;

            Assert.AreEqual(_vitesseExpected, _vitesseActual);
        }

        /// <summary>
        /// on vérifie bien que Pinky regarde en haut
        /// </summary>
        [TestMethod]
        public void TestPinky_orientationPinky_callAccessor_success()
        {
            //refer to Initialize()
            _orientationExpected = "Nord";
            _orientationActual = _classPinky.orientationPinky;

            Assert.AreEqual(_orientationExpected, _orientationActual);
        }
        /// <summary>
        /// on vérifie que le fantôme ne détecte pas un mur devant lui
        /// </summary>
        [TestMethod]
        public void TestPinky_mur_callAccessor_success()
        {
            //refer to Initialize()
            _murExpected = 0;
            _murActual = _classPinky.mur;

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
            _classPinky = null;
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
