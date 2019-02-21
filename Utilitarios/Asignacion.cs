using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Asignacion
/// </summary>
public class Asignacion: IEquatable<Asignacion>
{
    public Asignacion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idAsignacion;
    private string referencia;
    private int cantidad;
    private double talla;
    private string sede;
    private string fecha;
    private bool estado;
    

    public string Referencia { get => referencia; set => referencia = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }
    public double Talla { get => talla; set => talla = value; }
    public int IdAsignacion { get => idAsignacion; set => idAsignacion = value; }
    public string Sede { get => sede; set => sede = value; }
    public string Fecha { get => fecha; set => fecha = value; }
    public bool Estado { get => estado; set => estado = value; }

    bool IEquatable<Asignacion>.Equals(Asignacion other)
    {
        if (this.Referencia == other.Referencia && this.Talla == other.Talla &&
            this.Cantidad == other.Cantidad)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}