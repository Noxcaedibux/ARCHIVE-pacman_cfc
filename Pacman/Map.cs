using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// classe publique qui permettra de lire le fichier de la map et
    /// de la mettre sous forme de tableau pour pouvoir l'utiliser.
    /// </summary>
    public class Map
    {
        #region private attributes
        private string _emplacement;
        private string _error;
        private int _nbMurs;
        private int _nbPieces;
        private int[,] _map = new int[20,38];
        #endregion private attributes

        #region constructors
        /// <summary>
        /// Constructeur de la classe map 
        /// permettra d'ouvrir la bonne map au bon emplacement
        /// </summary>
        /// <param name="nomMap">on lui envoie le nom que notre fichier doit avoir sans l'extension</param>
        public Map(string nomMap)
        {
            _emplacement = AppDomain.CurrentDomain.BaseDirectory + @"Map\" + nomMap + ".txt";
            ReadFile();
        }
        #endregion constructors

        #region accessors and mutators
        /// <summary>
        /// accesseur du tableau contenant la ap du jeu
        /// </summary>
        public int[,] map
        {
            get
            {
                return _map;
            }
        }
        #endregion accessors and mutators

        #region public methods
        /// <summary>
        /// methode publique qui retourne le nombre de pieces dont on va avoir besoin 
        /// pour construire l'interace graphique et le nombre total de pieces dont
        /// on a besoin de manger pour finir le jeu
        /// </summary>
        /// <returns></returns>
        public int NbPiece()
        {
            _nbPieces = 0;
            foreach (int piece in _map)
            {
                if (piece == 2 || piece == 3)
                {
                    _nbPieces++;
                }
            }
            return _nbPieces;
        }
        /// <summary>
         /// methode publique qui retourne le nombre de murs dont on va avoir besoin 
         /// pour construire l'interace graphique
         /// </summary>
         /// <returns></returns>
        public int NbMurs()
        {
            _nbMurs = 0;
            foreach (int mur in _map)
            {
                if (mur == 1)
                {
                    _nbMurs++;
                }
            }
            return _nbMurs;
        }
        #endregion public methods

        #region private methods
        /// <summary>
        /// methode privé qui lis le fichier et l'enregistre dans un tableau,
        /// s'il y a une erreur on averti l'utilisateur sans que le programme ne plante.
        /// </summary>
        private void ReadFile()
        {
            StreamReader strReader = null;
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Map\")) Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"Map\");
            
            if (File.Exists(_emplacement))
            {
                strReader = new StreamReader(_emplacement);
                int x;
                int y;
                int lecteur = 0;
                string mapTemporaire = strReader.ReadToEnd();
                strReader.Close();
                mapTemporaire = mapTemporaire.Replace("\r\n", "");
                for (y = 0; y <= 19; y++)
                {
                    for (x = 0; x <= 37; x++)
                    {
                        _map[y, x] = int.Parse(mapTemporaire.Substring(lecteur, 1));
                        lecteur++;
                    }
                }
            }
            else
            {
                throw new Exception(_error);
            }
        }
        #endregion private methods
    }
}
