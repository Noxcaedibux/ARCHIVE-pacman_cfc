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
            _emplacement = AppDomain.CurrentDomain.BaseDirectory + @"Map\" + nomMap + ".txt";
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
                    string mapTemporaire = strReader.ReadToEnd();
                    strReader.Close();
                    MessageBox.Show(mapTemporaire, "Map chargée ↓");
                    mapTemporaire = mapTemporaire.Replace("\r\n", "");
                    MessageBox.Show(mapTemporaire, "Map chargée sans \\r\\n ↓");
                    for (y = 0; y <= 19; y++)
                    {
                        for (x = 0; x <= 37; x++)
                        {
                           _map[y, x] = int.Parse(mapTemporaire.Substring(lecteur, 1));
                            lecteur++;
                        }
                    }
                    StreamWriter writer = new StreamWriter(_emplacement.Substring(0, _emplacement.LastIndexOf("txt")) +"test");
                     for (y = 0; y <= 19; y++)
                     {
                         for (x = 0; x <= 37; x++)
                         {
                             writer.Write(_map[y, x]);
                        }
                        writer.Write("\n");
                    }
                    writer.Close();
                }
                catch (Exception e)
                {
                    _error = e.ToString();
                    MessageBox.Show(_error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez créer un dossier Map");
            }

        }
        #endregion private methods
    }
}
