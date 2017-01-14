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
        private List<string> _highScores;
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
                string sql = "create table highScores (PlayerName varchar(20), score int)";
                SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
                command.ExecuteNonQuery();
                command.Dispose();
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
            string sql = "insert into highScores (PlayerName, score) values ('" + playerName+"', "+score+")";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public List<string> retournerListeMeilleursScores()
        {
            if (_highScores == null) _highScores = new List<string>();
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand(sql, _dbConnection);
            _reader = command.ExecuteReader();
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
