using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;

namespace SQLite
{
    [TestClass]
    public class TestSQLiteManager
    {
        #region private attributes
        private SQLiteManager _sqLiteMgr;
        private string _databaseNameExpected;
        private string _databaseNameActual;
        #endregion private attributes

        [TestInitialize]
        public void Initialize()
        {
            this._databaseNameExpected = "MyDatabase.sqlite";
            this._sqLiteMgr = new SQLiteManager(this._databaseNameExpected);
        }

        [TestMethod]
        public void SqliteManager_DatabaseName_AfterInitialization_GetDatabaseName()
        {
            //given
            //refere to Initialize()

            //when
            this._databaseNameActual = this._sqLiteMgr.DatabaesName;

            //then
            Assert.AreEqual(this._databaseNameExpected, this._databaseNameActual);
        }

        [TestMethod]
        public void SqliteManager_Constructor_AfterInitialization_DatabaseExists()
        {
            //given
            //refere to Initialize()

            //when
            //the constructor create the database

            //then
            Assert.IsTrue(File.Exists(this._databaseNameExpected));
        }

        [TestMethod]
        public void SqliteManager_DatabaseState_WhenOpened_StateIsOpen()
        {
            //given
            //refere to Initialize()

            //when
            this._sqLiteMgr.OpenConnection();

            //then
            Assert.IsTrue(this._sqLiteMgr.DatabaseState == System.Data.ConnectionState.Open);
        }

        [TestMethod]
        public void SqliteManager_DatabaseState_WhenClosed_StateIsClosed()
        {
            //given
            //refere to Initialize()
            this._sqLiteMgr.OpenConnection();

            //when
            this._sqLiteMgr.CloseConnection();

            //then
            Assert.IsTrue(this._sqLiteMgr.DatabaseState == System.Data.ConnectionState.Closed);
        }

        [TestMethod]
        public void SQLiteManager_QueryCreateTable_QueryCorrect_TableCreated()
        {
            //init
            string tableName = "ANIMALS";
            string queryCreateTable = "CREATE TABLE " + tableName + " (species varchar(20), quantity int)";
            string queryCreateValidation = "SELECT COUNT(name) FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
            int queryResultExpected = 1;
            int queryResultActual = -1;

            //given
            //refere to Initialize()
            this._sqLiteMgr.QueryCreateTable(queryCreateTable);

            //when
            queryResultActual = this._sqLiteMgr.QueryCount(queryCreateValidation);

            //then
            Assert.AreEqual(queryResultExpected, queryResultActual);
        }

        [TestMethod]
        public void SQLiteManager_QueryInsert_QueryCorrect_ValueInserted()
        {
            //init
            string tableName = "ANIMALS";
            string queryCreateTable = "CREATE TABLE " + tableName + " (species varchar(20), quantity int)";
            string queryInsert = "INSERT INTO " + tableName + " (species, quantity) values ('Elephant', 24)";
            string queryInsertValidation = "SELECT COUNT(species) FROM " + tableName;
            int queryResultExpected = 1;
            int queryResultActual = -1;

            //given
            //refere to Initialize()
            this._sqLiteMgr.QueryCreateTable(queryCreateTable);
            this._sqLiteMgr.QueryInsert(queryInsert);

            //when
            queryResultActual = this._sqLiteMgr.QueryCount(queryInsertValidation);

            //then
            Assert.AreEqual(queryResultExpected, queryResultActual);
        }

        [TestMethod]
        public void SQLiteManager_QuerySelect_QueryCorrect_ValuesGet()
        {
            //init
            string tableName = "ANIMALS";
            string attribut1 = "species";
            string attribut2 = "quantity";
            string queryCreateTable = "CREATE TABLE " + tableName + " ("+ attribut1 + " varchar(20), " + attribut2 + " int)";
            string queryInsert = "INSERT INTO " + tableName + " (" + attribut1 + ", " + attribut2 + ") values ('Elephant', 24)";
            string querySelect = "SELECT " + attribut1 + ", " + attribut2 + " FROM " + tableName;
            string queryResultExpected = "Elephant,24";
            string queryResultActual = "";
            List<string> listOfAttributs = new List<string>();
            listOfAttributs.Add(attribut1);
            listOfAttributs.Add(attribut2);

            //given
            //refere to Initialize()
            this._sqLiteMgr.QueryCreateTable(queryCreateTable);
            this._sqLiteMgr.QueryInsert(queryInsert);


            //when
            List<string> querySelectResult = this._sqLiteMgr.QuerySelect(querySelect, listOfAttributs);
            
            //then
            Assert.AreEqual(queryResultExpected, querySelectResult[0]);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (this._sqLiteMgr.DatabaseState != System.Data.ConnectionState.Closed)
            {
                this._sqLiteMgr.CloseConnection();              
            }

            SQLiteConnection.ClearAllPools();

            if (File.Exists(this._databaseNameExpected))
            {
                File.Delete(this._databaseNameExpected);
            }
            this._sqLiteMgr = null;
        }
    }
}
