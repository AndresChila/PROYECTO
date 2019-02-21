using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EUsuario
/// </summary>
public class EUsuario
{
    public EUsuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private Int32 userId;
    private String session;
    private String ip;
    private String mac;
    private String clave;
    private int rolId;

    
    public string Session { get => session; set => session = value; }
    public string Ip { get => ip; set => ip = value; }
    public string Mac { get => mac; set => mac = value; }
    public int UserId { get => userId; set => userId = value; }
    public string Clave { get => clave; set => clave = value; }
    public int RolId { get => rolId; set => rolId = value; }
}