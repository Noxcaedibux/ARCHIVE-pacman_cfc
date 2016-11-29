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
    public partial class frmJeu : Form
    {
        public frmJeu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = new Size(794, 606);
            this.MinimumSize = new Size(794, 606);
            this.MaximizeBox = false;
            this.Name = "Jeu";
        }

    }
}
