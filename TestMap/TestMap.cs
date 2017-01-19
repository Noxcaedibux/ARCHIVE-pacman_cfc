using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    /// <summary>
    /// classe de test de la map
    /// </summary>
    [TestClass]
    public class TestMap
    {

        #region private attributes
        private string _nomMapExpected;
        private int[,] _mapActual;
        private int _nbPiecesActual;
        private bool _DossierExistant;
        private bool _FichierExistant;
        private Map _classMap;
        private int _nbMursActual;
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie nos variables
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _DossierExistant=false;
            _FichierExistant=false;
            _mapActual = null;
            _nomMapExpected = "Map01";
            _classMap = new Map(_nomMapExpected);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on vérifie que le dossier existe
        /// </summary>
        [TestMethod]
        public void TestMap_DirectoryExist_success()
        {
            //refert to init()
            _DossierExistant = Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Map\");
            Assert.IsTrue(_DossierExistant);
        }

        /// <summary>
        /// on vérifie que le fichier existe
        /// </summary>
        [TestMethod]
        public void TestMap_FileExist_success()
        {
            //refert to init()
            _FichierExistant = File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Map\" + _nomMapExpected + ".txt");
            Assert.IsTrue(_FichierExistant);
        }

        /// <summary>
        /// on regarde si notre map nous retourne bien des valeurs
        /// </summary>
        [TestMethod]
        public void TestMap_CreerMap_CallAccessor_Success()
        {
            //refert to init()
            _mapActual = _classMap.map;
            Assert.AreNotEqual(null, _mapActual);
        }

        /// <summary>
        /// on vérifie bien qu'on ait des pièces
        /// </summary>
        [TestMethod]
        public void TestMap_NbPieces_CallAccessor_Success()
        {
            //refert to init()
            _nbPiecesActual = _classMap.NbPiece();
            Assert.AreNotEqual(0, _nbPiecesActual);
        }

        /// <summary>
        /// on compte le nombre de burs qu'il nus faut pour dessiner la map
        /// </summary>
        [TestMethod]
        public void TestMap_NbMurs_CallAccessor_Success()
        {
            //refert to init()
            _nbMursActual = _classMap.NbMurs();
            Assert.AreNotEqual(0, _nbMursActual);
        }
        #endregion TestMethods

        #region CleanUp
        /// <summary>
        /// on remet à zero les variables
        /// </summary>
        [TestCleanup]
        public void TestMap_CleanUp_Success()
        {
            _nomMapExpected = null;
            _classMap = null;
        }
        #endregion CleanUp
    }
}
