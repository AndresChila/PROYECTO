using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Abono
/// </summary>
public class Abono
{
    public Abono()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    private int idabono;
    private int idcliente;
    private int idvendedor;
    private List<Producto> producto;
    private string sede;
    private string fecha;
    private double precio;

    public int Idabono { get => idabono; set => idabono = value; }
    public int Idcliente { get => idcliente; set => idcliente = value; }
    public List<Producto> Producto { get => producto; set => producto = value; }
    public string Sede { get => sede; set => sede = value; }
    public string Fecha { get => fecha; set => fecha = value; }
    public double Precio { get => precio; set => precio = value; }
    public int Idvendedor { get => idvendedor; set => idvendedor = value; }
}