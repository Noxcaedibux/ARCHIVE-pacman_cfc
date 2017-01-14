using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Pacman
{
    /// <summary>
    /// classe qui permettra d'enregistrer nos scores et de les lire
    /// </summary>
    public class BaseDeDonnees
    {
        #region private attributes
        private SQLiteConnection _dbConnection;
        private SQLiteDataReader _reader;
        private SQLiteCommand _command;
        private List<string> _highScores;
        private string _sql;
        private string _emplacementDossier = AppDomain.CurrentDomain.BaseDirectory + @"Scores\";
        private string _emplacementFichier;
        #endregion private attributes

        #region constructors
        public BaseDeDonnees(string name)
        {
            name += ".SQLite";
            _emplacementFichier = _emplacementDossier + name;
            _dbConnection = new SQLiteConnection("Data Source=" + name + ".SQLite;Version=3;");
            
            if (!Directory.Exists(_emplacementDossier)) Directory.CreateDirectory(_emplacementDossier);
            if (!File.Exists(_emplacementFichier))
            {
                SQLiteConnection.CreateFile(_emplacementFichier);
                _dbConnection.Open();
                _sql = "drop table if exists HighScores";
                _command = new SQLiteCommand(_sql, _dbConnection);
                _command.ExecuteNonQuery();
                _sql = "CREATE TABLE HighScores (PlayerName TEXT, score INTEGER)";
                _command = new SQLiteCommand(_sql, _dbConnection);
                _command.ExecuteNonQuery();
                _command.Dispose();
                _dbConnection.Close();
            }
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
            _sql =" INSERT INTO HighScores (PlayerName, score) values(\""+playerName+"\", "+ score +")";
            _command = new SQLiteCommand(_sql, _dbConnection);
            _command.ExecuteNonQuery();
            _command.Dispose();
        }
        public List<string> retournerListeMeilleursScores()
        {
            if (_highScores == null) _highScores = new List<string>();
            _sql = "select * from HighScores order by score desc";
            _command = new SQLiteCommand(_sql, _dbConnection);
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                _highScores.Add("Name: " + _reader["name"] + "\tScore: " + _reader["score"]);
            }
            return _highScores;
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
