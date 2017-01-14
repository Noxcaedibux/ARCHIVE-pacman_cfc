using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Pacman
{
    /// <summary>
    /// classe qui permettra d'enregistrer nos scores et de les lire
    /// </summary>
    public class BaseDeDonnees
    {
        #region private attributes
        private SQLiteConnection _dbConnection;
        private SQLiteCommand _command;
        #endregion private attributes

        #region constructors
        public void CreateDataBase(string name)
        {
            name = "MyDatabase.sqlite";
            _dbConnection = new SQLiteConnection("Data Source="+name+";Version=3;");
            string sql = "create table highScores (name varchar(20), score int)";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }
        #endregion constructors 

        #region accessors and mutators
        #endregion accessors and mutators

        #region public methods
        public void OpenDataBase()
        {
            _dbConnection.Open();
        }
        public void WriteInDbTable(string playerName, int score)
        {
            string sql = "insert into highScores (name, score) values ('"+playerName+"', "+score+")";
            _command = new SQLiteCommand(sql, _dbConnection);
            _command.ExecuteNonQuery();
        }
        public void CloseDataBase()
        {
            _dbConnection.Close();
        }
        #endregion public methods

        #region private methods
        #endregion private methods
    }
}
