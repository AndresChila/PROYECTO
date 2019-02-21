using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Sede
/// </summary>
public class Sede
{
    public Sede()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private int idSede;
    private string nombreSede;
    private string ciudad;
    private string direccion;

    public int IdSede { get => idSede; set => idSede = value; }
    public string NombreSede { get => nombreSede; set => nombreSede = value; }
    public string Ciudad { get => ciudad; set => ciudad = value; }
    public string Direccion { get => direccion; set => direccion = value; }
}