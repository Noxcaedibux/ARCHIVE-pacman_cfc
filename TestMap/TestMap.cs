using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    [TestClass]
    public class TestMap
    {
        string nomMapExpected;
        Map _classMap;
        /// <summary>
        /// Initialisement de nos variables
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            nomMapExpected = "Map01";
            _classMap = new Map(nomMapExpected);
        }
        /// <summary>
        /// on va tester que notre map retourne une
        /// valeur qui n'est pas nulle
        /// </summary>
        [TestMethod]
        public void TestCreerMapSuccess()
        {
            Assert.AreNotEqual(null, _classMap.map);
        }
        /// <summary>
        /// on va tester que notre map nous retourne bien
        /// une valeur de pièces
        /// </summary>
        [TestMethod]
        public void TestNbPiecesSuccess()
        {
            Assert.AreNotEqual(0, _classMap.NbPiece());
        }
        /// <summary>
        /// on regarde qu'on ait bien des murs
        /// </summary>
        [TestMethod]
        public void TestNbMursSuccess()
        {
            Assert.AreNotEqual(0, _classMap.NbMurs());
        }
        /// <summary>
        /// on remet à zero nos variables pour le prochain test
        /// </summary>
        [TestCleanup]
        public void TestClean()
        {
            nomMapExpected = null;
            _classMap = null;
        }
    }
}
