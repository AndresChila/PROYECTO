using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;

public partial class View_Tienda_VerPedidos : System.Web.UI.Page
{
    
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                DataSet reporte_multas = ObtenerInforme();
                CrystalReportSource1.ReportDocument.SetDataSource(reporte_multas);
                CrystalReportViewer1.ReportSource = CrystalReportSource1;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected DataSet ObtenerInforme()
        {
            DataRow fila;
            DataTable multasInformacion = new DataTable();
            DataSet datos = new DataSet();

            multasInformacion = datos.Tables["Pedidos"];
            DAOUsuario dao = new DAOUsuario();
            DataTable intermedio = dao.verPedido();

            for (int i = 0; i < intermedio.Rows.Count; i++)
            {
                fila = multasInformacion.NewRow();
                fila["idpedido"] = int.Parse(intermedio.Rows[i]["idpedido"].ToString());
                fila["sede"] = intermedio.Rows[i]["sede"].ToString();
                fila["fecha"] = DateTime.Parse(intermedio.Rows[i]["fecha"].ToString());
                fila["estado"] = Convert.ToString(intermedio.Rows[i]["estado"]);
                

                multasInformacion.Rows.Add(fila);
            }

            return datos;
        }
    }
