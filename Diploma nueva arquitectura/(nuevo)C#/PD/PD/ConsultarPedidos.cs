using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;


namespace PD
{
   
    public partial class ConsultarPedidos : Defaultform
    {
        BLL.UbicacionBLL ubi = new BLL.UbicacionBLL();
        BLL.Bitacora log = new BLL.Bitacora();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        MenuPrincipal mp = MenuPrincipal.Instance;
        BLL.PedidoBLL ped = new BLL.PedidoBLL();

       
        public void Show(object sender, EventArgs e)
        {
            this.Show();
        }

        public ConsultarPedidos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultarPedidos_Load(object sender, EventArgs e)
        {
            //traigo el nombre de los medios
            DataTable datamedio = new DataTable();
            //cargar combobox
            datamedio = ubi.TraerMedios();

            foreach (DataRow row in datamedio.Rows)
            {
                cmbMedio.Items.Add(row[0].ToString());
            }
            cmbMedio.Items.Add("Todos");

       }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < dgvpedidos.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvpedidos.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = dgvpedidos.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }


            MessageBox.Show("Excel Exportado con Exito", "Exportacion Excel OK", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
            //fin
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            try
            {

                DateTime fechadesde = Convert.ToDateTime(dtpdesde.Text);
                DateTime fechahasta = Convert.ToDateTime(dtphasta.Text);
                string medio = cmbMedio.Text;
                string sqlmedio = "";

                switch (medio)
                {
                    case "":
                        MessageBox.Show("seccione un medio por favor", "Medio Vacio", MessageBoxButtons.OK,
                      MessageBoxIcon.Hand);
                        break;

                    case "Todos":
                        sqlmedio = "select distinct medionombre from medio";

                        break;

                    default:
                        sqlmedio = "select distinct medionombre from medio where medionombre like '" + medio + "'";
                        break;
                }

                //llenamos la bitacora con todo lo filtrado

                DataTable dt = new DataTable();

                dt = ped.ConsultarPedido(fechadesde, fechahasta, sqlmedio);



               
                dgvpedidos.DataSource = dt;
                dgvpedidos.ReadOnly = true;

                this.dgvpedidos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvpedidos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvpedidos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvpedidos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvpedidos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void btn_serializar_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();

            try
            {
                XmlSerializer formateador = new XmlSerializer(typeof(DataSet));

                Stream mistream = new FileStream("Pedidos_imp.xml", FileMode.Create, FileAccess.Write, FileShare.None);

                //Recorrer 

                 dt1 = (DataTable)(dgvpedidos.DataSource);

                 dt1.TableName = "Pedidos";

                DataSet ds = new DataSet();

                ds.Tables.Add(dt1);

                 //serializo

                 formateador.Serialize(mistream, ds);

                 mistream.Close();

                }
catch (Exception ex)
{

 MessageBox.Show(ex.Message);

}




}

private void button2_Click(object sender, EventArgs e)
{
try
{
 XmlSerializer formateador1 = new XmlSerializer(typeof(DataSet));

 Stream mistream2 = new FileStream("Pedidos_imp.xml", FileMode.Open, FileAccess.Read, FileShare.None);
                DataSet ds2 = new DataSet();
                DataTable dt2 = new DataTable();

                ds2 = (DataSet)formateador1.Deserialize(mistream2);

                dt2 = ds2.Tables[0];

                

 mistream2.Close();


 dgvpedidos.ReadOnly = false;
 dgvpedidos.DataSource = dt2;
 dgvpedidos.ReadOnly = true;

 this.dgvpedidos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
 this.dgvpedidos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
 this.dgvpedidos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
 this.dgvpedidos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
 this.dgvpedidos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


}
catch (Exception ex)
{

 MessageBox.Show(ex.Message);
}


}
}
}

