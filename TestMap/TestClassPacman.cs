using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    /// <summary>
    /// classe de test pour pacman
    /// </summary>
    [TestClass]
    public class TestClassPacman
    {
        #region private attributes
        private ClassPacman _classPacman;
        private Map _classMap;
        private int _vitesseActual;
        private int _vitesseExpected;
        private int _nbPacgomeActual;
        private int _nbPacgomeExpected;
        private int _ghostEatenActual;
        private int _ghostEatenExpected;
        private int _superPac_gomeActual;
        private int _superPac_gomeExpected;
        private int _positionXActual;
        private int _positionXExpected;
        private int _positionYActual;
        private int _positionYExpected;
        private int _positionXGraphActual;
        private int _positionXGraphExpected;
        private int _positionYGraphActual;
        private int _positionYGraphExpected;
        private int _nbPiecesRestantesActual;
        private int _avancerActual;
        private int _collisionActual;
        private int _PiecesRestantesActual;
        private int _scoreActual;
        private int _scoreExpected;
        private string _orientationActual;
        private string _orientationExpected;
        private int[,] _map;
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie nos variables
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _classMap = new Map("Map01");
            _vitesseExpected = 20;
            _map = _classMap.map;
            _classPacman = new ClassPacman(_vitesseExpected, _map);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on va tester le nombre de pac gomes mangées
        /// </summary>
        [TestMethod]
        public void TestClassPacman_Pac_gome_callAccessor_success()
        {
            //refer to Initialize()

            _nbPacgomeExpected = 0;
            _nbPacgomeActual = _classPacman.pac_gome;

            Assert.AreEqual(_nbPacgomeExpected, _nbPacgomeActual);
        }
        /// <summary>
        /// on va tester le nombre de fantômes mangés 
        /// </summary>
        [TestMethod]
        public void TestClassPacman_ghostEaten_callAccessor_success()
        {
            //refer to Initialize()

            _ghostEatenExpected = 0;
            _ghostEatenActual = _classPacman.ghostEaten;

            Assert.AreEqual(_ghostEatenExpected, _ghostEatenActual);
        }
        /// <summary>
        /// on va tester le nombre de superPac gomes mangées
        /// </summary>
        [TestMethod]
        public void TestClassPacman_superPac_gome_callAccessor_success()
        {
            //refer to Initialize()

            _superPac_gomeExpected = 0;
            _superPac_gomeActual = _classPacman.superPac_gome;

            Assert.AreEqual(_superPac_gomeExpected, _superPac_gomeActual);
        }
        /// <summary>
        /// on va voir si pacman se trouve au bon endroit sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestClassPacman_positionX_callAccessor_success()
        {
            //refer to Initialize()

            _positionXExpected = 18;
            _positionXActual = _classPacman.positionX;

            Assert.AreEqual(_positionXExpected, _positionXActual);
        }

        /// <summary>
        /// on va voir si pacman se trouve au bon endroit sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestClassPacman_positionY_callAccessor_success()
        {
            //refer to Initialize()

            _positionYExpected = 16;
            _positionYActual = _classPacman.positionY;

            Assert.AreEqual(_positionYExpected, _positionYActual);
        }

        /// <summary>
        /// on va voir si l'image de pacman va être au bon endroit sur l'axe x
        /// </summary>
        [TestMethod]
        public void TestClassPacman_positionXGraph_callAccessor_success()
        {
            //refer to Initialize()

            _positionXGraphExpected = 360;
            _positionXGraphActual = _classPacman.positionXGraph;

            Assert.AreEqual(_positionXGraphExpected, _positionXGraphActual);
        }

        /// <summary>
        /// on va voir si l'image de pacman va être au bon endroit sur l'axe y
        /// </summary>
        [TestMethod]
        public void TestClassPacman_positionYGraph_callAccessor_success()
        {
            //refer to Initialize()

            _positionYGraphExpected = 320;
            _positionYGraphActual = _classPacman.positionYGraph;

            Assert.AreEqual(_positionYGraphExpected, _positionYGraphActual);
        }

        /// <summary>
        /// on test si pacman va à la bonne vitesse
        /// </summary>
        [TestMethod]
        public void TestClassPacman_Vitesse_callAccessor_success()
        {
            //refer to Initialize()

            _vitesseActual = _classPacman.vitesse;

            Assert.AreEqual(_vitesseExpected, _vitesseActual);
        }

        /// <summary>
        /// on regarde si pacman regarde au bon endroit
        /// </summary>
        [TestMethod]
        public void TestClassPacman_Orientation_callAccessor_success()
        {
            //refer to Initialize()
            _orientationExpected = "Nord";
            _orientationActual = _classPacman.orientation;

            Assert.AreEqual(_orientationExpected, _orientationActual);
        }

        /// <summary>
        /// on regarde s'il y a bien des pièces pour pacman
        /// </summary>
        [TestMethod]
        public void TestClassPacman_NbPiecesRestantes_callAccessor_success()
        {
            //refer to Initialize()
            _nbPiecesRestantesActual = _classPacman.NbPiecesRestantes;

            Assert.IsFalse(_nbPiecesRestantesActual == 0);
        }

        /// <summary>
        /// on teste si pacman peut avancer alors qu'il à un mur en face
        /// </summary>
        [TestMethod]
        public void TestClassPacman_Avancer_callMethod_success()
        {
            //refer to Initialize()
            _avancerActual = _classPacman.avancer();

            Assert.IsTrue(_avancerActual == 0);
        }

        /// <summary>
        /// on test que pacman n'a pas touché un fantôme
        /// </summary>
        [TestMethod]
        public void TestClassPacman_collisionGhost_callMethod_Failed()
        {
            //refer to Initialize()
            _collisionActual = _classPacman.collisionGhost("Nord", 1, 1);

            Assert.IsTrue(_collisionActual == 0);
        }

        /// <summary>
        /// on test que pacman a été touché par un fantôme
        /// </summary>
        [TestMethod]
        public void TestClassPacman_collisionGhost_callMethod_success()
        {
            //refer to Initialize()
            _collisionActual = _classPacman.collisionGhost("Nord", 18, 16);

            Assert.IsTrue(_collisionActual == 1);
        }

        /// <summary>
        /// on test le nombre de pieces restantes pour le graphique
        /// </summary>
        [TestMethod]
        public void TestClassPacman_PiecesRestantes_callMethod_success()
        {
            //refer to Initialize()
            _PiecesRestantesActual = _classPacman.PiecesRestantes();

            Assert.IsTrue(_PiecesRestantesActual != 0);
        }

        /// <summary>
        /// on calcule le score total
        /// </summary>
        [TestMethod]
        public void TestClassPacman_ScoreTotal_callMethod_success()
        {
            //refer to Initialize()
            _scoreExpected = 0;
            _scoreActual = _classPacman.ScoreTotal();

            Assert.AreEqual(_scoreExpected, _scoreActual);
        }
        #endregion TestMethods

        #region CleanUp
        /// <summary>
        /// on remet à zero les variables
        /// </summary>
        [TestCleanup]
        public void CleanUp()
        {
            _classPacman = null;
            _classMap = null;
            _vitesseActual = 0;
            _nbPacgomeActual = 0;
            _ghostEatenActual = 0;
            _superPac_gomeActual = 0;
            _positionXActual = 0;
            _positionYActual = 0;
            _positionXGraphActual = 0;
            _positionYGraphActual = 0;
            _nbPiecesRestantesActual = 0;
            _avancerActual = 0;
            _collisionActual = 0;
            _PiecesRestantesActual = 0;
            _scoreActual = 0;
            _scoreExpected = 0;
            _orientationActual = null;
            _orientationExpected = null;
            _map = null;
        }
        #endregion CleanUp
    }
}
