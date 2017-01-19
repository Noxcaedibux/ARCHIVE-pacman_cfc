using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    /// <summary>
    /// classe de test pour clyde le fantôme débile
    /// il avance là où il le peut
    /// </summary>
    [TestClass]
    public class TestClyde
    {
        #region private attributes
        private Clyde _classClyde;
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
            _map = _classMap.map;
            _vitesseExpected = 20;
            _classClyde = new Clyde(_vitesseExpected, _map);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on test s'il à la bonne position x
        /// </summary>
        [TestMethod]
        public void TestClyde_positionX_callAccessor_success()
        {
            //refer to Initialize()
            _positionXExpected = 17;
            _positionXActual = _classClyde.positionX;

            Assert.AreEqual(_positionXExpected, _positionXActual);
        }

        /// <summary>
        /// on test s'il à la bonne position y
        /// </summary>
        [TestMethod]
        public void TestClyde_positionY_callAccessor_success()
        {
            //refer to Initialize()
            _positionYExpected = 11;
            _positionYActual = _classClyde.positionY;

            Assert.AreEqual(_positionYExpected, _positionYActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestClyde_positionXMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionXMapExpected = 17;
            _positionXMapActual = _classClyde.positionXMap;

            Assert.AreEqual(_positionXMapExpected, _positionXMapActual);
        }

        /// <summary>
        /// on regarde qu'il demarre au bon endroit sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestClyde_positionYMap_callAccessor_success()
        {
            //refer to Initialize()
            _positionYMapExpected = 11;
            _positionYMapActual = _classClyde.positionYMap;

            Assert.AreEqual(_positionYMapExpected, _positionYMapActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestClyde_positionXGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionXGraphExpected = 340;
            _positionXGraphActual = _classClyde.positionXGraph;

            Assert.AreEqual(_positionXGraphExpected, _positionXGraphActual);
        }

        /// <summary>
        /// on regarde qu'il soit bien placé pour l'interface graphique sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestClyde_positionYGraph_callAccessor_success()
        {
            //refer to Initialize()
            _positionYGraphExpected = 220;
            _positionYGraphActual = _classClyde.positionYGraph;

            Assert.AreEqual(_positionYGraphExpected, _positionYGraphActual);
        }

        /// <summary>
        /// on vérifie qu'il ait la bonne vitesse
        /// </summary>
        [TestMethod]
        public void TestClyde_vitesse_callAccessor_success()
        {
            //refer to Initialize()
            _vitesseActual = _classClyde.vitesse;

            Assert.AreEqual(_vitesseExpected, _vitesseActual);
        }

        /// <summary>
        /// on vérifie bien que Clyde regarde en haut
        /// </summary>
        [TestMethod]
        public void TestClyde_orientationClyde_callAccessor_success()
        {
            //refer to Initialize()
            _orientationExpected = "Nord";
            _orientationActual = _classClyde.orientationClyde;

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
            _classClyde = null;
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
