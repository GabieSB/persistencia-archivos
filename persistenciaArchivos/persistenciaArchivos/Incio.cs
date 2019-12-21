using Cheques;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace persistenciaArchivos
{
    public partial class Incio : Form
    {
        public Incio()
        {
            InitializeComponent();
        }

        private void CrearChequesButton_Click(object sender, EventArgs e)
        {
            CreateFilesForm create = new CreateFilesForm();
            this.Hide();
            create.Show();
        }

        private void VerChequesButton_Click(object sender, EventArgs e)
        {
            ControlCheques control = new ControlCheques();
            this.Hide();
            control.Show();
        }
    }
}
