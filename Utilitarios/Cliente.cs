using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Cliente
{
    public Cliente()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    int cedula;
    string nombre;
    string apellido;
    string direccion;
    long telefono;
    string sexo;

    public int Cedula { get => cedula; set => cedula = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public long Telefono { get => telefono; set => telefono = value; }
    public string Sexo { get => sexo; set => sexo = value; }
}