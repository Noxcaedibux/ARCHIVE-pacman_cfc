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
        private string _emplacementDossier = AppDomain.CurrentDomain.BaseDirectory + @"\Scores\";
        private string _emplacementFichier;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// constructeur qui va regarder si le dossier 
        /// ou doit se trouver notre base de données existe.
        /// il va créer un fichier de base de données pour stocker nos scores
        /// </summary>
        /// <param name="name">nom du fichier de la base de données</param>
        public BaseDeDonnees(string name)
        {
            name += ".sqlite";
            _emplacementFichier = _emplacementDossier+name;
            _dbConnection = new SQLiteConnection("Data Source=" + _emplacementFichier + ";Version=3;");
            
            if (!Directory.Exists(_emplacementDossier)) Directory.CreateDirectory(_emplacementDossier);
            if (!File.Exists(_emplacementFichier))
            {
                SQLiteConnection.CreateFile(_emplacementFichier);
                OpenDataBase();
                CommandSQLite("CREATE TABLE HighScores (PlayerName TEXT, score INTEGER)");
                CloseDataBase();
            }
        }
        #endregion constructors 

        #region accessors and mutators
        #endregion accessors and mutators

        #region public methods
        /// <summary>
        /// méthode publique qui va écrire dans la base de données 
        /// le nom de la personne dans la bonne table et pareil pour le score
        /// </summary>
        /// <param name="playerName">Nom que le joueur aura écrit</param>
        /// <param name="score">le score total du joueur</param>
        public void WriteInDbTable(string playerName, int score)
        {
            OpenDataBase();
            CommandSQLite(" INSERT INTO HighScores (PlayerName, score) values(\"" + playerName + "\", " + score + ")");
            CloseDataBase();
        }
        /// <summary>
        /// méthode publique qui vas enregistrer toute
        /// la basse de données dans une liste et nous
        /// la retourne après
        /// </summary>
        /// <returns>retourne notre liste qui contien le nom des joueurs et leur scores </returns>
        public List<string> retournerListeMeilleursScores()
        {
            if (_highScores == null) _highScores = new List<string>();
            _sql = "select * from HighScores order by score desc";
            _command = new SQLiteCommand(_sql, _dbConnection);
            OpenDataBase();
            _reader = _command.ExecuteReader();
            _command.Dispose();
            while (_reader.Read())
            {
                _highScores.Add(_reader["PlayerName"] + ":      " + "\t" + _reader["score"]);
            }
            CloseDataBase();
            return _highScores;
        }
        #endregion public methods

        #region private methods

        private void CloseDataBase()
        {
            _dbConnection.Close();
        }
        private void OpenDataBase()
        {
            _dbConnection.Open();
        }
        private void CommandSQLite(string commandSqlite)
        {
            _command = new SQLiteCommand(commandSqlite, _dbConnection);
            _command.ExecuteNonQuery();
            _command.Dispose();
        }
        #endregion private methods
    }
}
