using Cheques.UNA.Cheques;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cheques
{
    public partial class ControlCheques : Form
    {
        private readonly string userPassword = "El20Examen20Estaba20Faci20";
        public ControlCheques()
        {
            InitializeComponent();
        }

        private void RefrescarButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = ConvertCSVtoDataTable(@"C:\Users\604450844\Desktop\persistencia-archivos\persistenciaArchivos\persistenciaArchivos\bin\Debug\21_12_2019 10_49_11.csv");
            
        }

        public static DataTable ConvertCSVtoDataTable(string Path)
        {
            StreamReader sr = new StreamReader(Path);
          //  string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("Emisor");
            dt.Columns.Add("Receptor");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Numero de Cheques");
            dt.Columns.Add("Monto");
            dt.Columns.Add("Institucion Financiera");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Moneda");

            /*foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }*/
            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < rows.Length; i++)
                {
                    dr[i] = rows[i];
                    if (i == 6)
                    {
                        //dr[i] = Encriptacion.DesencriptarString(rows[i],userPassword);
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
