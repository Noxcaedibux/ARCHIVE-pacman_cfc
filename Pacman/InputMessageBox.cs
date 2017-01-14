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
    public partial class FrmInputMessageBox : frmJeu
    {
        private Label _lblMessage;
        private TextBox _txtNom;
        private Button _cmdOk;
        private Button _cmdCancel;
        private BaseDeDonnees _baseDeDonnes;

        public FrmInputMessageBox()
        {
            InitializeComponent();
            this.Controls.Clear();
            _lblMessage = new Label();
            _txtNom = new TextBox();
            _cmdOk = new Button();
            _cmdCancel = new Button();

            this.Name = "InputMessageBox";
            this.Size = new Size(305, 145);
            this._lblMessage.Location = new Point(24, 13);
            this._lblMessage.AutoSize = true;

            this._lblMessage.Text = "Veuillez entrer un nom pour enregistrer votre score.";
            this._txtNom.Size = new Size(156, 20);
            this._txtNom.Location = new Point(69, 40);
            this._txtNom.Text = "\"Votre Nom\"";

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
            if (_baseDeDonnes == null) _baseDeDonnes = new BaseDeDonnees("Scores");
            _baseDeDonnes.OpenDataBase();
            _baseDeDonnes.WriteInDbTable(_txtNom.Text, base._totalScore);
            _baseDeDonnes.CloseDataBase();
            this.Close();
        }
        private void _cmdCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel");
            this.Close();
        }
    }
}
