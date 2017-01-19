using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Pacman
{
    /// <summary>
    /// classe qui va tester la base de données
    /// </summary>
    [TestClass]
    public class TestBaseDeDonnees
    {
        #region private attributes
        private BaseDeDonnees _baseDeDonnes;
        private string _emplacementDossier;
        private string _emplacementFichier;
        private string _databaseName;
        private List<string> _scoreActual;
        private List<string> _scoreExpected;
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie les variables
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this._databaseName = "Scores";
            this._emplacementDossier= _emplacementDossier = AppDomain.CurrentDomain.BaseDirectory + @"\Scores\";
            this._emplacementFichier= _emplacementDossier = AppDomain.CurrentDomain.BaseDirectory + @"\Scores\"+_databaseName+".sqlite";
            this._scoreActual=null;
            this._scoreExpected=new List<string>();
            this._baseDeDonnes = new BaseDeDonnees(this._databaseName);
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// on regarde si le dossier existe
        /// </summary>
        [TestMethod]
        public void BaseDeDonneesr_Constructor_AfterInitialization_DatabaseDirectory()
        {
            //refere to Initialize()
            Assert.IsTrue(File.Exists(this._emplacementDossier));
        }

        /// <summary>
        /// On regarde si le fichier existe
        /// </summary>
        [TestMethod]
        public void BaseDeDonneesr_Constructor_AfterInitialization_DatabaseExists()
        {
            //refere to Initialize()
            Assert.IsTrue(File.Exists(this._emplacementFichier));
        }

        /// <summary>
        /// on va écrire dans la base de données
        /// et voir si les valeurs qu'on récupére 
        /// sont les mêmes
        /// </summary>
        [TestMethod]
        public void BaseDeDonneesr_WriteInDbTable_callMethod_success()
        {
            //refere to Initialize()

            _baseDeDonnes.WriteInDbTable("player", 0);
            _scoreActual= _baseDeDonnes.retournerListeMeilleursScores();
            _scoreExpected.Add("player:      \t0");

            Assert.AreEqual(_scoreExpected[0], _scoreActual[0]);
        }
        #endregion TestMethods

        #region CleanUp
        /// <summary>
        /// on remet à zero les variables
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            if(Directory.Exists(this._emplacementDossier))
            {
                Directory.Delete(this._emplacementDossier);
            }
            this._emplacementDossier = null;
            this._emplacementFichier = null;
            this._baseDeDonnes = null;
            this._scoreExpected = null;
        }
        #endregion CleanUp
    }
}
