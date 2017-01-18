using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    /// <summary>
    /// form qui servira à demander à l'utilisateur s'il veut sauvegarder son score ou annuler
    /// </summary>
    public partial class FrmInputMessageBox : Form
    {
        private Label _lblMessage;
        private TextBox _txtNom;
        private Button _cmdOk;
        private Button _cmdCancel;
        private BaseDeDonnees _baseDeDonnes;
        private int _totalScore;
        /// <summary>
        /// constructeur qui va placer les éléments à son
        /// ouverture pour que l'utilisateur puisse intérragir avec ceux-ci
        /// </summary>
        /// <param name="totalScore">ceci est le score total que l'utilisateur aura fait avant de mourir</param>
        public FrmInputMessageBox(int totalScore)
        {
            InitializeComponent();
            _totalScore = totalScore;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "InputMessageBox";
            this.Size = new Size(305, 145);

            _lblMessage = new Label();
            _txtNom = new TextBox();
            _txtNom.MaxLength = 15;
            _cmdOk = new Button();
            _cmdCancel = new Button();

            this._lblMessage.Location = new Point(24, 13);
            this._lblMessage.AutoSize = true;

            this._lblMessage.Text = "                           Score: " + totalScore.ToString() + "\nVeuillez entrer un nom pour enregistrer votre score.";
            this._txtNom.Size = new Size(156, 20);
            this._txtNom.Location = new Point(69, 40);
            this._txtNom.Text = "\"1-15 caractères max\"";

            this._cmdOk.Size = new Size(75, 23);
            this._cmdOk.Location = new Point(114, 73);
            this._cmdOk.Text = "Ok";
            this._cmdOk.Name = "_cmdOk";

            this._cmdCancel.Size = new Size(75, 23);
            this._cmdCancel.Location = new Point(195, 73);
            this._cmdCancel.Text = "Cancel";
            this._cmdCancel.Name = "_cmdCancel";

            this.Controls.Add(_txtNom);
            this.Controls.Add(_lblMessage);
            this.Controls.Add(_cmdOk);
            this.Controls.Add(_cmdCancel);
            _cmdOk.Click += new EventHandler(_cmdOk_Click);
            _cmdCancel.Click += new EventHandler(_cmdCancel_Click);
        }

        private void _cmdOk_Click(object sender, EventArgs e)
        {
            string Nom = _txtNom.Text.Replace(" ", "");
            if (Nom == "") MessageBox.Show("Veuillez écrire un nom svp", "Nom manquant");
            else
            {
                _baseDeDonnes = new BaseDeDonnees("Scores");
                _baseDeDonnes.WriteInDbTable(_txtNom.Text, _totalScore);
                this.Close();
            }
        }
        private void _cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
