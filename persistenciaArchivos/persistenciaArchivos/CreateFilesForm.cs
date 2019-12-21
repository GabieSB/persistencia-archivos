using persistenciaArchivos.UNA.Cheques;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.Cheques;

namespace persistenciaArchivos
{
    public partial class CreateFilesForm : Form
    {
        private readonly string rutaPorDefecto = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string userPassword="El20Examen20Estaba20Faci20";

        public CreateFilesForm()
        {
            InitializeComponent();
        }

        private void CreateFilesForm_Load(object sender, EventArgs e)
        {
            InformacionRutaLabel.Text = $"Los archivos serán creados por defecto en la ruta {rutaPorDefecto}";
        } 

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarInterfaz();
        }

        private void LimpiarInterfaz()
        {
            EmisorTextBox.Text = "";
            NumeroChequeTextBox.Text = "";
            MontoTextBox.Text = "";
            DescripcionTextBox.Text = "";
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            if (InformacionEsValida())
            {
                Cheque cheque = RellenarCheque();
                ChequesDataGridView.Rows.Add(cheque.Emisor, cheque.Receptor, cheque.Fecha, cheque.Numero, cheque.Monto, cheque.InstitucionFinanciera, cheque.Descripcion, cheque.Moneda);
            }

        }

        private bool InformacionEsValida()
        {
            LimpiarErrorProviders();
            bool esValida = true;
            if (EmisorTextBox.Text.Length < 3)
            {
                esValida = false;
                ErrorProvider.SetError(EmisorTextBox, "Debe especificar un nombre de más de 3 caracteres");
            }
            if (ReceptorTextBox.Text.Length < 3)
            {
                esValida = false;
                ErrorProvider.SetError(ReceptorTextBox, "Debe especificar un nombre de más de 3 caracteres");
            }
            if (NumeroChequeTextBox.Text.Length < 5)
            {
                esValida = false;
                ErrorProvider.SetError(NumeroChequeTextBox, "Debe especificar un número de cheque de más de 5 caracteres");
            }

            if (!EsUnValorNumerico(MontoTextBox.Text))
            {
                esValida = false;
                ErrorProvider.SetError(MontoTextBox, "Debe especificar un monto númerico");
            }
            if (InstitucionTextBox.Text.Length < 3)
            {
                esValida = false;
                ErrorProvider.SetError(InstitucionTextBox, "Debe especificar una Institucion de más de 10 caracteres");
            }
            if (DescripcionTextBox.Text.Length < 10)
            {
                esValida = false;
                ErrorProvider.SetError(DescripcionTextBox, "Debe especificar una Descripción de más de 10 caracteres");
            }
            return esValida;
        }

        private bool EsUnValorNumerico(string valor)
        {
            return Double.TryParse(valor, out _);
        }

        private Cheque RellenarCheque()
        {
            return new Cheque
            {
                Emisor = EmisorTextBox.Text,
                Receptor = ReceptorTextBox.Text,
                Fecha = FechaDateTime.Value,
                Numero = Convert.ToDouble(NumeroChequeTextBox.Text),
                Monto = Convert.ToDouble(MontoTextBox.Text),
                InstitucionFinanciera = InstitucionTextBox.Text,
                Descripcion = DescripcionTextBox.Text,
                Moneda = MonedaComboBox.SelectedItem.ToString()
            };
        }

        private void CerrarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool HayInformacionEnLaGrid()
        {
            return ChequesDataGridView.Rows.Count >= 1;
        }

        private void BorrarRenglonButton_Click(object sender, EventArgs e)
        {

            if (HayInformacionEnLaGrid())
            {
                LimpiarErrorProviders();
                ChequesDataGridView.Rows.RemoveAt(ChequesDataGridView.Rows.Count - 1);
            }
            else
            {
                InformationProvider.SetError(BorrarRenglonButton, "No hay renglones para borrar");
            }
        }
         
        private void CreateFilesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HayInformacionEnLaGrid() && DeseaCerrarSinGuardar())
            {
                e.Cancel = true;
            }

        }

        private bool DeseaCerrarSinGuardar()
        {
            return MessageBox.Show("No se ha guardado la información, realmente desea cerrar este formulario",
                                        "¿Desea Continuar?", MessageBoxButtons.YesNo) == DialogResult.No;
        }

        private void CrearArchivoButton_Click(object sender, EventArgs e)
        {
            if (HayInformacionEnLaGrid())
            {
                LimpiarErrorProviders();

                ArchivoManager archivoManager = new ArchivoManager();

                CargarInformacion(archivoManager);

                ConstruirElArchivo(archivoManager);

                ChequesDataGridView.Rows.Clear();
            }
            else
            {
                ErrorProvider.SetError(ChequesDataGridView, "No hay información para crear el archivo");
                InformationProvider.SetError(CrearArchivoButton, "Primero agregue información para crear el archivo");
            }
        }

        private void LimpiarErrorProviders()
        {
            ErrorProvider.SetError(EmisorTextBox, "");
            ErrorProvider.SetError(NumeroChequeTextBox, "");
            ErrorProvider.SetError(MontoTextBox, "");
            ErrorProvider.SetError(DescripcionTextBox, "");
            ErrorProvider.SetError(InstitucionTextBox, "");
            ErrorProvider.SetError(ReceptorTextBox, "");

            ErrorProvider.SetError(ChequesDataGridView, "");
            InformationProvider.SetError(CrearArchivoButton, "");
            InformationProvider.SetError(CerrarButton, "");

        }
        
        private void CargarInformacion(ArchivoManager archivoManager)
        {
            for (int rowIndex = 0; rowIndex < ChequesDataGridView.Rows.Count ; rowIndex++)
            {
                string descripcionEncriptada = Encriptacion.EncriptarString(ChequesDataGridView.Rows[rowIndex].Cells[6].Value.ToString(),userPassword);

                archivoManager.ChequesList.Add(new Cheque
                {
                    Emisor = ChequesDataGridView.Rows[rowIndex].Cells[0].Value.ToString(),
                    Receptor = ChequesDataGridView.Rows[rowIndex].Cells[1].Value.ToString(),
                    Fecha = Convert.ToDateTime(ChequesDataGridView.Rows[rowIndex].Cells[2].Value.ToString()),
                    Numero = Convert.ToDouble(ChequesDataGridView.Rows[rowIndex].Cells[3].Value.ToString()),
                    Monto = Convert.ToDouble(ChequesDataGridView.Rows[rowIndex].Cells[4].Value.ToString()),
                    InstitucionFinanciera = ChequesDataGridView.Rows[rowIndex].Cells[5].Value.ToString(),
                    Descripcion = descripcionEncriptada,
                    Moneda = ChequesDataGridView.Rows[rowIndex].Cells[7].Value.ToString(),
                    
                });
            }
        }
        
        private void ConstruirElArchivo(ArchivoManager archivoManager)
        {
            try
            {
                string nombreNuevoArchivo = archivoManager.CrearArchivo(rutaPorDefecto);
                MessageBox.Show($"El archivo {nombreNuevoArchivo} se creo de manera correcta", "Excelente!", MessageBoxButtons.OK);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Se ha presentado el siguiente inconveniente al crear el archivo: {exception.Message}", "Atención", MessageBoxButtons.OK);
            }
        }

        private void NombreLabel_Click(object sender, EventArgs e)
        {

        }

        
    }
}
