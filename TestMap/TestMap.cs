using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pacman
{
    [TestClass]
    public class TestMap
    {
        string nomMapExpected;
        Map _classMap;

        [TestInitialize]
        public void TestInit()
        {
            nomMapExpected = "Map01";
            _classMap = new Map(nomMapExpected);
        }

        [TestMethod]
        public void TestCreerMapSuccess()
        {
            Assert.AreNotEqual(null, _classMap.map);
        }

        [TestMethod]
        public void TestNbPiecesSuccess()
        {
            Assert.AreNotEqual(0, _classMap.NbPiece());
        }

        [TestMethod]
        public void TestNbMursSuccess()
        {
            Assert.AreNotEqual(0, _classMap.NbMurs());
        }

        [TestCleanup]
        public void TestClean()
        {
            nomMapExpected = null;
            _classMap = null;
        }
    }
}
