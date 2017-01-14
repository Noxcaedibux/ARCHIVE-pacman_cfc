using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    public class SQLiteManager
    {
        #region pivate attributes
        private SQLiteConnection _dbConnection;
        private string _databaseName;
        #endregion private attributes

        #region constructors
        public SQLiteManager (string databaseName)
        {
            this._databaseName = databaseName;
            this._dbConnection = new SQLiteConnection("Data Source=" + this._databaseName + "; Version=3;");
            CreateDatabase(this._databaseName);
        }
        #endregion constructors

        #region accessors and mutators
        public string DatabaesName
        {
            get { return this._databaseName; }
        }

        public System.Data.ConnectionState DatabaseState
        {
            get
            {
                return this._dbConnection.State;
            }
        }
        #endregion accessors and mutators

        #region private methods
        private void CreateDatabase(string databaseName)
        {
            SQLiteConnection.CreateFile(databaseName);
        }

        private void ExecuteNonQuery(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, this._dbConnection);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        private int ExecuteScalarQuery(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, this._dbConnection);
            cmd.Dispose();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private SQLiteDataReader ExecuteReader(string query)
        {
            SQLiteCommand cmd = new SQLiteCommand(query, this._dbConnection);
            SQLiteDataReader dataReader = cmd.ExecuteReader();
            cmd.Dispose();
            return dataReader;
        }
        #endregion private methods

        #region public methods
        public void OpenConnection()
        {
            this._dbConnection.Open();
        }

        public void CloseConnection()
        {
            this._dbConnection.Close();
        }

        public int QueryCount(string query)
        {
            int queryResult = -1;

            this.OpenConnection();
            queryResult = this.ExecuteScalarQuery(query);
            this.CloseConnection();

            return queryResult;
        }

        public void QueryCreateTable(string query)
        {
            this.OpenConnection();
            this.ExecuteNonQuery(query);
            this.CloseConnection();
        }

        public void QueryInsert(string query)
        {
            this.OpenConnection();
            this.ExecuteNonQuery(query);
            this.CloseConnection();
        }

        public List<string> QuerySelect(string query, List<string> listOfAttributes)
        {
            SQLiteDataReader dataReader;
            List<string> listOfSqlStringResults = new List<string>();

            this.OpenConnection();
            dataReader = this.ExecuteReader(query);
            while(dataReader.Read())
            {
                string result = "";
                foreach (string attribut in listOfAttributes)
                {
                    if (result != "")
                    {
                        result += ",";
                    }
                    result += dataReader[attribut];
                }
                listOfSqlStringResults.Add(result);
            }
            dataReader.Close();
            this.CloseConnection();
            return listOfSqlStringResults;
        }
        #endregion public methods
    }
}
