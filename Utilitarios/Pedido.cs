using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Pedido
/// </summary>
public class Pedido
{
    public Pedido()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idpedido;
    private string sede;
    private string fecha;
    private bool estado;

    public int Idpedido { get => idpedido; set => idpedido = value; }
    public string Sede { get => sede; set => sede = value; }
    public string Fecha { get => fecha; set => fecha = value; }
    public bool Estado { get => estado; set => estado = value; }
}