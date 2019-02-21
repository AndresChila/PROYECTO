using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class LlenarGridViews
    {
        public DataTable llenarGridViewVenta(string sede, bool pstbk)
        {
            
            DAOUsuario dao = new DAOUsuario();
            DataTable gri = new DataTable();
            gri = dao.verInventario(Convert.ToString(sede));
            List<Producto> llenarprimera = new List<Producto>();
            foreach (DataRow ro in gri.Rows)
            {
                Producto p = new Producto();
                p.Referencia = Convert.ToString(ro["referencia"]);
                p.Talla = Convert.ToDouble(ro["talla"]);
                llenarprimera.Add(p);
            }
            return gri;
        }
    }
}
