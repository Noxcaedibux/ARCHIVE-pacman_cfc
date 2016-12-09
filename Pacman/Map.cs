using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Pacman
{
    public class Map
    {
        #region private attributes
        private string _emplacement;
        private string _error;
        private int[,] _map = new int[20,38];
        #endregion private attributes

        #region constructors
        public Map(string nomMap)
        {
            _emplacement = AppDomain.CurrentDomain.BaseDirectory + @".\Map\" + nomMap + ".txt";
            ReadFile();
        }
        #endregion constructors

        #region accessors and mutators
        public int[,] map
        {
            get
            {
                return _map;
            }
        }
        public string error
        {
            get
            {
                return _error;
            }
        }
        #endregion accessors and mutators

        #region public methods
        #endregion public methods

        #region private methods
        public void ReadFile()
        {
            StreamReader strReader = null;

            if (File.Exists(_emplacement))
            {
                try
                {
                    strReader = new StreamReader(_emplacement);
                    int x;
                    int y;
                    int lecteur=0;
                    //string mapTemporaire = strReader.ReadToEnd();
                    for (y = 0; y < 19; y++)
                    {
                        for (x = 0; x < 37; x++)
                        {
                            /*if (mapTemporaire.Substring(lecteur, 1) != "\n") _map[y, x] = int.Parse(mapTemporaire.Substring(lecteur, 1) );
                            lecteur++;*/
                            _map[y, x] = strReader.Read() - 48;
                        }
                    }
                    strReader.Close();
                    StreamWriter writer = new StreamWriter(_emplacement+"t");
                     for (y = 0; y < 19; y++)
                     {
                         for (x = 0; x < 37; x++)
                         {
                             writer.Write(_map[y, x]);
                        }
                        writer.Write("\n");
                    }
                    writer.Close();
                    MessageBox.Show(_map[0,0].ToString());
                }
                catch (Exception e)
                {
                    _error = e.ToString();
                    MessageBox.Show(_error);
                }
            }
        }
        #endregion private methods
    }
}
