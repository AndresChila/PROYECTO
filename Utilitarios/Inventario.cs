using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Inventario
/// </summary>
public class Inventario
{
    public Inventario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idInventario;
    private string referencia;
    private double talla;
    private int cantidad;
    private string sede;

    public int IdInventario { get => idInventario; set => idInventario = value; }
    public string Referencia { get => referencia; set => referencia = value; }
    public double Talla { get => talla; set => talla = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public string Sede { get => sede; set => sede = value; }
}